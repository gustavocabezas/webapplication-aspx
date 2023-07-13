using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.UI;
using webapplication_aspx.Models;
using webapplication_aspx.Services;

namespace webapplication_aspx
{
    public partial class Login : Page
    {
        private readonly UserService _userService = new UserService();

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

        protected async void ButtonLogin_Click(object sender, EventArgs e)
        {
            var user = new User();

            user.Username = TextBoxUsername.Text;
            user.Password = TextBoxPassword.Text;
            var result = await _userService.AuthenticationUser(user);
            if (result != null)
            {
                Session["AuthenticationResult"] = result;
                Navigate("users");
            }
        }

        public void Navigate(string page)
        {
            string script = "<script>window.location.href = '" + page + ".aspx';</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "RedirectScript", script);
        }
    }
}
