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
    /// Логика взаимодействия для KasirMenu.xaml
    /// </summary>
    public partial class KasirMenu : Window
    {
        public KasirMenu()
        {
            InitializeComponent();
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Login Log = new Login();
            Log.Show();
            this.Close();
        }

        private void Kasir_Click(object sender, RoutedEventArgs e)
        {
            Kasir kasir = new Kasir();
            kasir.Show();
            this.Close();
        }

        private void Client_Click(object sender, RoutedEventArgs e)
        {
            KasirAddClient Client = new KasirAddClient();
            Client.Show();
            this.Close();
        }
    }
}
