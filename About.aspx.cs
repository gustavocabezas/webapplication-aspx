using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.UI;
using webapplication_aspx.Models;
using webapplication_aspx.Services;

namespace webapplication_aspx
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(LoadDataAsync));
        }

        private async Task LoadDataAsync()
        {
            UserService userService = new UserService();
            int userId = 1;
            User user = await userService.GetUserById(userId);
            var x = user;


            List<User> users = await userService.GetAllUsers();
            var y = users;
        }

    }
}
