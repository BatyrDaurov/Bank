using Bank.Model;
using Bank.View;
using System;
using System.Collections.Generic;
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

namespace Bank
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Auth : Window
    {
        public Auth()
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

        /// <summary>
        /// Отправка и проверка данных о пользователе
        /// </summary>
        /// <param name="sender">Что то хранит</param>
        /// <param name="e"></param>
        private void auth_btn_Click(object sender, RoutedEventArgs e)
        {
            int userId = File.CheckUser(File.GetUsers(), name_tb.Text, pass_tb.Text);

            if (userId != 0)
            {
                UserSingleton.User = File.GetUser(File.GetUsers(), userId);
                UserSingleton.isAuth = true;

                Profile profile = new Profile();
                profile.Show();
                Close();
            }else
            {
                MessageBox.Show("Нет такого пользователя 😐");
            }
        }
    }
}
