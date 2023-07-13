using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

public abstract class BaseService
{

    protected string _baseUrl = "http://localhost:61478/WebService1.asmx/";

    protected async Task<bool> Post<T>(string url, T obj)
    {
        try
        {
            string jsonContent = JsonConvert.SerializeObject(obj);
            var parameters = new Dictionary<string, string>
         {
             { "entity", jsonContent }
         };

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.PostAsync(_baseUrl + url, new FormUrlEncodedContent(parameters));
                response.EnsureSuccessStatusCode();
                return true;
            }
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    protected async Task<T> PostAuthentication<T>(string url, T obj)
    {
        try
        {
            string jsonContent = JsonConvert.SerializeObject(obj);
            var parameters = new Dictionary<string, string>
         {
             { "entity", jsonContent }
         };

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.PostAsync(_baseUrl + url, new FormUrlEncodedContent(parameters));
                response.EnsureSuccessStatusCode();

                using (Stream responseStream = await response.Content.ReadAsStreamAsync())
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(responseStream);

                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    using (XmlNodeReader reader = new XmlNodeReader(xmlDoc.DocumentElement))
                    {
                        return (T)serializer.Deserialize(reader);
                    }
                }
            }
        }
        catch (Exception ex) { return default(T); }
    }

    protected async Task<T> Get<T>(string url)
    {
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(_baseUrl + url);
            response.EnsureSuccessStatusCode();

            using (Stream responseStream = await response.Content.ReadAsStreamAsync())
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(responseStream);

                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using (XmlNodeReader reader = new XmlNodeReader(xmlDoc.DocumentElement))
                {
                    return (T)serializer.Deserialize(reader);
                }
            }
        }
    }

    protected async Task<List<T>> GetList<T>(string url)
    {
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(_baseUrl + url);
            response.EnsureSuccessStatusCode();

            using (Stream responseStream = await response.Content.ReadAsStreamAsync())
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(responseStream);

                XmlNodeList itemNodes = xmlDoc.GetElementsByTagName(typeof(T).Name);
                List<T> items = new List<T>();

                XmlSerializer serializer = new XmlSerializer(typeof(T));

                foreach (XmlNode itemNode in itemNodes)
                {
                    using (XmlNodeReader reader = new XmlNodeReader(itemNode))
                    {
                        T item = (T)serializer.Deserialize(reader);
                        items.Add(item);
                    }
                }

                return items;
            }
        }
    }

    protected async Task<bool> Delete(string url, int id)
    {
        try
        {
            var parameters = new Dictionary<string, string>
        {
            { "id", id.ToString() }
        };

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.PostAsync(_baseUrl + url, new FormUrlEncodedContent(parameters));
                response.EnsureSuccessStatusCode();
                return true;
            }
        }
        catch (Exception ex)
        {
            return false;
        }
    }

}
