using KP.CondDataSetTableAdapters;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace KP
{
    /// <summary>
    /// Логика взаимодействия для AdminDolz.xaml
    /// </summary>
    public partial class AdminDolz : Window
    {
        public AdminDolz()
        {
            InitializeComponent();
            RefreshData();
        }
        public void RefreshData()
        {
            DolzTableAdapter adapter = new DolzTableAdapter();
            CondDataSet.DolzDataTable table = new CondDataSet.DolzDataTable();
            adapter.Fill(table);
            db_dolz.ItemsSource = table;
        }
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Login Log = new Login();
            Log.Show();
            this.Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AdminMenu AdmM = new AdminMenu();
            AdmM.Show();
            this.Close();
        }

        private void Add_sklad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(Name.Text) && !String.IsNullOrWhiteSpace(Oklad.Text))
                {
                    new DolzTableAdapter().InsertQuery(Convert.ToString(Name.Text), Convert.ToInt32(Oklad.Text));
                    Error.Text = ""; Acess.Text = "✔ Данные успешно добавлены";
                    RefreshData();
                }
                else { Acess.Text = ""; Error.Text = "⚠ Проверьте правильность  введенных данных"; }
            }
            catch { Acess.Text = ""; Error.Text = "⚠ Проверьте правильность  введенных данных"; }
        }

        private void Edit_sklad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(Name.Text) && !String.IsNullOrWhiteSpace(Oklad.Text))
                {
                    new DolzTableAdapter().UpdateQuery(Convert.ToString(Name.Text), Convert.ToInt32(Oklad.Text), Convert.ToInt32((db_dolz.SelectedItems[0] as DataRowView).Row.ItemArray[0]));
                    Name.Text = "";
                    Oklad.Text = "";
                    Error.Text = "";
                    Acess.Text = "✔ Данные успешно изменены";
                    RefreshData();
                }
                else
                {
                    Acess.Text = "";
                    Error.Text = "⚠ Выберите строку из таблицы или измените данные";
                }
            }
            catch
            {
                Acess.Text = "";
                Error.Text = "⚠ Выберите строку из таблицы или измените данные";
            }
        }

        private void Del_sklad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                new DolzTableAdapter().DeleteQuery(Convert.ToInt32((db_dolz.SelectedItems[0] as DataRowView).Row.ItemArray[0]));
                Error.Text = "";
                Acess.Text = "✔ Данные успешно удалены";
                RefreshData();
                Name.Clear();
                Oklad.Clear();                
            }
            catch
            {
                Acess.Text = "";
                Error.Text = "⚠ Выберите строку из таблицы для удаления";
            }
        }
        private void db(object sender, SelectionChangedEventArgs e)
        {
            if (db_dolz.SelectedItem != null)
            {
                if (Name.Text != null & Oklad.Text != null)
                {
                    if (db_dolz.SelectedItem != null) Name.Text = (db_dolz.SelectedItem as DataRowView).Row.ItemArray[1].ToString();
                    if (db_dolz.SelectedItem != null) Oklad.Text = (db_dolz.SelectedItem as DataRowView).Row.ItemArray[2].ToString();                    
                }
                else { }
            }
            else { }
        }
    }
}
