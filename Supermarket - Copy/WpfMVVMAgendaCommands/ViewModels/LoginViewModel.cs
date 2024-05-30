using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVMAgendaCommands.Models.DataAccessLayer;

namespace WpfMVVMAgendaCommands.ViewModels
{
    internal class LoginViewModel
    {
        private UserDAL userDAL;

        public int UserId { get; private set; }
        public string UserType { get; private set; }

        public LoginViewModel()
        {
            userDAL = new UserDAL();
        }

        public string AuthenticateAndGetUserType(string username, string password)
        {
            (string userType, int userId) = userDAL.AuthenticateUser(username, password);
            UserId = userId;
            UserType = userType;
            return userType;
        }
    }
}
