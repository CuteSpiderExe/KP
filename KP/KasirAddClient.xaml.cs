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
    /// Логика взаимодействия для KasirAddClient.xaml
    /// </summary>
    public partial class KasirAddClient : Window
    {
        public KasirAddClient()
        {
            InitializeComponent();
            RefreshData();
        }
        public void RefreshData()
        {
            ClientTableAdapter adapter = new ClientTableAdapter();
            CondDataSet.ClientDataTable table = new CondDataSet.ClientDataTable();
            adapter.Fill(table);
            db_client.ItemsSource = table;
        }
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Login Log = new Login();
            Log.Show();
            this.Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            KasirMenu Kas = new KasirMenu();
            Kas.Show();
            this.Close();
        }
        private void db(object sender, SelectionChangedEventArgs e)
        {
            if (db_client.SelectedItem != null)
            {
                if (Fam.Text != null & Name.Text != null & Otch.Text != null & Mail.Text != null & Number.Text != null)
                {
                    if (db_client.SelectedItem != null) Fam.Text = (db_client.SelectedItem as DataRowView).Row.ItemArray[1].ToString();
                    if (db_client.SelectedItem != null) Name.Text = (db_client.SelectedItem as DataRowView).Row.ItemArray[2].ToString();
                    if (db_client.SelectedItem != null) Otch.Text = (db_client.SelectedItem as DataRowView).Row.ItemArray[3].ToString();
                    if (db_client.SelectedItem != null) Mail.Text = (db_client.SelectedItem as DataRowView).Row.ItemArray[4].ToString();
                    if (db_client.SelectedItem != null) Number.Text = (db_client.SelectedItem as DataRowView).Row.ItemArray[5].ToString();
                }
                else { }
            }
            else { }
        }

        private void Add_sklad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(Fam.Text) && !String.IsNullOrWhiteSpace(Name.Text) && !String.IsNullOrWhiteSpace(Mail.Text) && !String.IsNullOrWhiteSpace(Number.Text))
                {
                    new ClientTableAdapter().InsertQuery(Convert.ToString(Fam.Text), Convert.ToString(Name.Text), Convert.ToString(Otch.Text), Convert.ToString(Mail.Text), Convert.ToString(Number.Text));
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
                if (!String.IsNullOrWhiteSpace(Fam.Text) && !String.IsNullOrWhiteSpace(Name.Text) && !String.IsNullOrWhiteSpace(Mail.Text) && !String.IsNullOrWhiteSpace(Number.Text))
                {
                    new ClientTableAdapter().UpdateQuery(Convert.ToString(Fam.Text), Convert.ToString(Name.Text), Convert.ToString(Otch.Text), Convert.ToString(Mail.Text), Convert.ToString(Number.Text), Convert.ToInt32((db_client.SelectedItems[0] as DataRowView).Row.ItemArray[0]));
                    Fam.Text = "";
                    Name.Text = "";
                    Otch.Text = "";
                    Mail.Text = "";
                    Number.Text = "";
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
                new CondTableAdapter().DeleteQuery(Convert.ToInt32((db_client.SelectedItems[0] as DataRowView).Row.ItemArray[0]));
                Error.Text = "";
                Acess.Text = "✔ Данные успешно удалены";
                RefreshData();
                Fam.Clear();
                Name.Clear();
                Otch.Clear();
                Mail.Clear();
                Number.Clear();
            }
            catch
            {
                Acess.Text = "";
                Error.Text = "⚠ Выберите строку из таблицы для удаления";
            }
        }
    }
}
