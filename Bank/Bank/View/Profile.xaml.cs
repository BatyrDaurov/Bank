using Bank.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        public Profile()
        {
            InitializeComponent();
            email_tb.Content = $"Ваша почта: {UserSingleton.User.email}";
            role_tb.Content = $"Ваша роль: {UserSingleton.User.role}";

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (UserSingleton.User.role == "Admin")
            {
                phonesGrid.ItemsSource = File.GetCloths();
                cloths_dg.Visibility = Visibility.Hidden;
            }
            else
            {
                cloths_info_dg.Width = 0;
                cloths_info_dg.Visibility = Visibility.Hidden;
                cloths_dg.Visibility = Visibility.Visible;
            }
        }

        private void MenuItem_exit(object sender, RoutedEventArgs e)
        {
            Auth auth = new Auth();
            auth.Show();
            Close();
        }

    }
}
