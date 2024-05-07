using Bank.Model;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace Bank.View
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }
        private void MenuItem_login(object sender, RoutedEventArgs e)
        {
            if (!UserSingleton.isAuth)
            {
                Auth window = new Auth();
                window.Show();
                Close();
            }
        }
        private void MenuItem_registr(object sender, RoutedEventArgs e)
        {
            if (!UserSingleton.isAuth)
            {
                Registration window = new Registration();
                window.Show();
                Close();
            }
        }

        private void auth_btn_Click(object sender, RoutedEventArgs e)
        {
            File.WriteUser($"{name_tb.Text}:{pass_tb.Text}");

            UserSingleton.isAuth = true;
            UserSingleton.User = new UserModel{
                Id = 1488,
                email = name_tb.Text,
                password = pass_tb.Text
            };

            Profile profile = new Profile();
            profile.Show();
            Close();
        }
    }
}
