using System;
using System.Xml.Serialization;

namespace webapplication_aspx.Models
{
    [Serializable]
    public class User
    {
        [XmlElement("Id")]
        public int Id { get; set; }

        [XmlElement("ProfileId")]
        public int ProfileId { get; set; } = 1;

        [XmlElement("Username")]
        public string Username { get; set; } = String.Empty;

        [XmlElement("Password")]
        public string Password { get; set; } = String.Empty;

        [XmlElement("TempPassword")]
        public string TempPassword { get; set; } = String.Empty;

        [XmlElement("LastLogin")]
        public DateTime? LastLogin { get; set; } = DateTime.Now;

        [XmlElement("StatusId")]
        public int StatusId { get; set; }

        [XmlElement("DateCreated")]
        public DateTime? DateCreated { get; set; } = DateTime.Now;

        [XmlElement("DateUpdated")]
        public DateTime? DateUpdated { get; set; } = DateTime.Now;

        [XmlElement("CreatedBy")]
        public int CreatedBy { get; set; }

        [XmlElement("UpdatedBy")]
        public int UpdatedBy { get; set; }
    }
}