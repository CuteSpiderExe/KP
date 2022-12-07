using KP.CondDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для KladovTovar.xaml
    /// </summary>
    public partial class KladovTovar : Window
    {
        SqlConnection con = new SqlConnection();
        CondDataSet CondDataSet;
        TovarTableAdapter TovarTableAdapter;

        public KladovTovar()
        {
            InitializeComponent();
            RefreshData();
        }
        public void RefreshData()
        {
            TovarTableAdapter adapter = new TovarTableAdapter();
            CondDataSet.TovarDataTable table = new CondDataSet.TovarDataTable();
            adapter.Fill(table);
            db_tovar.ItemsSource = table;

            SkladTableAdapter adapt = new SkladTableAdapter();
            CondDataSet.SkladDataTable table1 = new CondDataSet.SkladDataTable();
            adapt.Fill(table1);
            Adress_skl.ItemsSource = table1;
            Adress_skl.DisplayMemberPath = "Адрес";
            Adress_skl.SelectedValuePath = "Код";
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Login Log = new Login();
            Log.Show();
            this.Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Kladov Klad = new Kladov();
            Klad.Show();
            this.Close();
        }

        private void Add_tovar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(Tovar.Text) && !String.IsNullOrWhiteSpace(Adress_skl.Text))
                {
                    new TovarTableAdapter().InsertQuery(Convert.ToString(Tovar.Text), Convert.ToInt32(Adress_skl.SelectedValue));
                    Error.Text = ""; Acess.Text = "✔ Данные успешно добавлены";
                    RefreshData();
                }
            else { Acess.Text = ""; Error.Text = "⚠ Проверьте правильность  введенных данных"; }
        }
            catch { Acess.Text = ""; Error.Text = "⚠ Проверьте правильность  введенных данных"; }
}

        private void Edit_tovar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(Tovar.Text) && !String.IsNullOrWhiteSpace(Adress_skl.Text))
                {
                    new TovarTableAdapter().UpdateQuery(Tovar.Text, Convert.ToInt32(Adress_skl.SelectedValue), Convert.ToInt32((db_tovar.SelectedItems[0] as DataRowView).Row.ItemArray[0]));
                    Tovar.Text = "";
                    Adress_skl.Text = "";
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

        private void Del_tovar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                new TovarTableAdapter().DeleteQuery(Convert.ToInt32((db_tovar.SelectedItems[0] as DataRowView).Row.ItemArray[0]));
                Error.Text = "";
                Acess.Text = "✔ Данные успешно удалены";
                RefreshData();
                Tovar.Clear();
                Adress_skl.Text="";
            }
            catch
            {
                Acess.Text = "";
                Error.Text = "⚠ Выберите строку из таблицы для удаления";
            }
        }
        private void db(object sender, SelectionChangedEventArgs e)
        {
            if (db_tovar.SelectedItem != null)
            {
                if (Tovar.Text != null & Adress_skl.Text != null)
                {
                    if (db_tovar.SelectedItem != null) Tovar.Text = (db_tovar.SelectedItem as DataRowView).Row.ItemArray[1].ToString();
                    if (db_tovar.SelectedItem != null) Adress_skl.Text = (db_tovar.SelectedItem as DataRowView).Row.ItemArray[2].ToString();
                }
                else { }
            }
            else { }
        }
    }
}
