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
    /// Логика взаимодействия для Kladov.xaml
    /// </summary>
    public partial class Kladov : Window
    {
        public Kladov()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Login Log = new Login();
            Log.Show();
            this.Close();
        }

        private void Sklad_Click(object sender, RoutedEventArgs e)
        {
            KladovSklad Sklad = new KladovSklad();
            Sklad.Show();
            this.Close();
        }

        private void Tovar_Click(object sender, RoutedEventArgs e)
        {
            KladovTovar Tovar = new KladovTovar();
            Tovar.Show();
            this.Close();
        }
    }
}
