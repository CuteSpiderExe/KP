using KP.CondDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для KladovSklad.xaml
    /// </summary>
    public partial class KladovSklad : Window
    {
        SqlConnection con = new SqlConnection();
        CondDataSet CondDataSet;
        SkladTableAdapter skladTableAdapter;
        public KladovSklad()
        {
            InitializeComponent();
            RefreshData();
        }
        public void RefreshData()
        {
            SkladTableAdapter adapter = new SkladTableAdapter();
            CondDataSet.SkladDataTable table = new CondDataSet.SkladDataTable();
            adapter.Fill(table);
            db_sklad.ItemsSource = table;
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

        private void Add_sklad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(Adress.Text) && !String.IsNullOrWhiteSpace(Uachei.Text))
                {
                    new SkladTableAdapter().InsertQuery(Convert.ToString(Adress.Text), Convert.ToInt32(Uachei.Text));
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
                if (!String.IsNullOrWhiteSpace(Adress.Text) && !String.IsNullOrWhiteSpace(Uachei.Text))
                {
                    new SkladTableAdapter().UpdateQuery(Adress.Text, Convert.ToInt32(Uachei.Text), Convert.ToInt32((db_sklad.SelectedItems[0] as DataRowView).Row.ItemArray[0]));
                    Adress.Text = "";
                    Uachei.Text = "";
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
                new SkladTableAdapter().DeleteQuery(Convert.ToInt32((db_sklad.SelectedItems[0] as DataRowView).Row.ItemArray[0]));
                Error.Text = "";
                Acess.Text = "✔ Данные успешно удалены";
                RefreshData();
                Adress.Clear();
                Uachei.Clear();               
            }
            catch
            {
                Acess.Text = "";
                Error.Text = "⚠ Выберите строку из таблицы для удаления";
            }
        }
        private void db(object sender, SelectionChangedEventArgs e)
        {
            if (db_sklad.SelectedItem != null)
            {
                if (Adress.Text != null & Uachei.Text != null)
                {
                    if (db_sklad.SelectedItem != null) Adress.Text = (db_sklad.SelectedItem as DataRowView).Row.ItemArray[1].ToString();
                    if (db_sklad.SelectedItem != null) Uachei.Text = (db_sklad.SelectedItem as DataRowView).Row.ItemArray[2].ToString();
                }
                else { }
            }
            else { }
        }
    }
    } 



    
   
