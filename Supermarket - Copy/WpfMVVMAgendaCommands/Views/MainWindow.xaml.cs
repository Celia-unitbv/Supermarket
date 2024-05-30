using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfMVVMAgendaCommands.Models;
using WpfMVVMAgendaCommands.ViewModels;

namespace WpfMVVMAgendaCommands.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LoginViewModel loginViewModel;

        public MainWindow()
        {
            InitializeComponent();

            loginViewModel = new LoginViewModel();
        }


        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            string userType = loginViewModel.AuthenticateAndGetUserType(username, password);

            if (!string.IsNullOrEmpty(userType))
            {
                MessageBox.Show("Autentificare reușită!");
                MainViewModel mainViewModel = new MainViewModel
                {
                    CurrentUserId = loginViewModel.UserId
                };

                if (userType == "Administrator")
                {
                    AdminWindow adminWindow = new AdminWindow(mainViewModel);
                    adminWindow.Show();
                    this.Close();
                }
                else if (userType == "Casier")
                {
                    CashierWindow cashierWindow = new CashierWindow(mainViewModel);
                    cashierWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tip de utilizator necunoscut!");
                }
            }
            else
            {
                MessageBox.Show("Nume de utilizator sau parolă incorectă!");
            }
        }
    }
}
