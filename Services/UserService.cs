using System.Collections.Generic;
using System.Threading.Tasks;
using webapplication_aspx.Models;

namespace webapplication_aspx.Services
{
    public class UserService : BaseService
    {
        public async Task<User> AuthenticationUser(User entity)
        {
            string url = $"AuthenticationUser";
            return await PostAuthentication<User>(url, entity);
        }

        public async Task<bool> CreateUser(User entity)
        {
            string url = $"CreateUser";
            return await Post(url, entity);
        }

        public async Task<bool> UpdateUser(User entity)
        {
            string url = $"UpdateUser";
            return await Post(url, entity);
        }

        public async Task<User> GetUserById(int id)
        {
            string url = $"GetUserById?id={id}";
            return await Get<User>(url);
        }

        public async Task<List<User>> GetAllUsers()
        {
            string url = $"GetAllUsers";
            return await GetList<User>(url);
        }

        public async Task<bool> DeleteUser(int id)
        {
            string url = $"DeleteUserById";
            return await Delete(url, id);
        }
    }

}