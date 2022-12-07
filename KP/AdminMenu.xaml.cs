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
using System.Windows.Shapes;

namespace KP
{
    /// <summary>
    /// Логика взаимодействия для AdminMenu.xaml
    /// </summary>
    public partial class AdminMenu : Window
    {
        public AdminMenu()
        {
            InitializeComponent();
        }

        private void Tovar_Click(object sender, RoutedEventArgs e)
        {
            KladovTovar Tovar = new KladovTovar();
            Tovar.Show();
            this.Close();
        }

        private void Sklad_Click(object sender, RoutedEventArgs e)
        {
            KladovSklad Sklad = new KladovSklad();
            Sklad.Show();
            this.Close();
        }

        private void Emp_Click(object sender, RoutedEventArgs e)
        {
            AdminEmployee Empl = new AdminEmployee();
            Empl.Show();
            this.Close();
        }

        private void Kasir_Click(object sender, RoutedEventArgs e)
        {
            Kasir Zak = new Kasir();
            Zak.Show();
            this.Close();
        }

        private void Client_Click(object sender, RoutedEventArgs e)
        {
            KasirAddClient Client = new KasirAddClient();
            Client.Show();
            this.Close();
        }

        private void User_Click(object sender, RoutedEventArgs e)
        {
            AdminUsers Users = new AdminUsers();
            Users.Show();
            this.Close();
        }

        private void Fil_Click(object sender, RoutedEventArgs e)
        {
            AdminFil Fil = new AdminFil();
            Fil.Show();
            this.Close();
        }

        private void Dolz_Click(object sender, RoutedEventArgs e)
        {
            AdminDolz Dolz = new AdminDolz();
            Dolz.Show();
            this.Close();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Login Log = new Login();
            Log.Show();
            this.Close();
        }
    }
}
