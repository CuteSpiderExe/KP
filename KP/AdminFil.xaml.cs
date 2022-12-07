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
    /// Логика взаимодействия для AdminFil.xaml
    /// </summary>
    public partial class AdminFil : Window
    {
        public AdminFil()
        {
            InitializeComponent();
            RefreshData();
        }
        public void RefreshData()
        {
            CondTableAdapter adapter = new CondTableAdapter();
            CondDataSet.CondDataTable table = new CondDataSet.CondDataTable();
            adapter.Fill(table);
            db_fil.ItemsSource = table;
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
                if (!String.IsNullOrWhiteSpace(Adress.Text) && !String.IsNullOrWhiteSpace(Plosh.Text) && !String.IsNullOrWhiteSpace(Time.Text))
                {
                    new CondTableAdapter().InsertQuery(Convert.ToString(Adress.Text), Convert.ToString(Plosh.Text),Convert.ToString(Time.Text));
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
                if (!String.IsNullOrWhiteSpace(Adress.Text) && !String.IsNullOrWhiteSpace(Plosh.Text) && !String.IsNullOrWhiteSpace(Time.Text))
                {
                    new CondTableAdapter().UpdateQuery(Convert.ToString(Adress.Text), Convert.ToString(Plosh.Text), Convert.ToString(Time.Text), Convert.ToInt32((db_fil.SelectedItems[0] as DataRowView).Row.ItemArray[0]));
                    Adress.Text = "";
                    Plosh.Text = "";
                    Time.Text = "";
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
                new CondTableAdapter().DeleteQuery(Convert.ToInt32((db_fil.SelectedItems[0] as DataRowView).Row.ItemArray[0]));
                Error.Text = "";
                Acess.Text = "✔ Данные успешно удалены";
                RefreshData();
                Adress.Clear();
                Plosh.Clear();
                Time.Clear();
            }
            catch
            {
                Acess.Text = "";
                Error.Text = "⚠ Выберите строку из таблицы для удаления";
            }
        }
        private void db(object sender, SelectionChangedEventArgs e)
        {
            if (db_fil.SelectedItem != null)
            {
                if (Adress.Text != null & Plosh.Text != null & Time.Text != null)
                {
                    if (db_fil.SelectedItem != null) Adress.Text = (db_fil.SelectedItem as DataRowView).Row.ItemArray[1].ToString();
                    if (db_fil.SelectedItem != null) Plosh.Text = (db_fil.SelectedItem as DataRowView).Row.ItemArray[2].ToString();
                    if (db_fil.SelectedItem != null) Time.Text = (db_fil.SelectedItem as DataRowView).Row.ItemArray[3].ToString();
                }
                else { }
            }
            else { }
        }
    }
}
