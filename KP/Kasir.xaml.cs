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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Kasir : Window
    {
        public Kasir()
        {
            InitializeComponent();
            RefreshData();
        }
        public void RefreshData()
        {
            ChekTableAdapter adapter = new ChekTableAdapter();
            CondDataSet.ChekDataTable table = new CondDataSet.ChekDataTable();
            adapter.Fill(table);
            db_uslugi.ItemsSource = table;

            EmployeeTableAdapter adapt = new EmployeeTableAdapter();
            CondDataSet.EmployeeDataTable table1 = new CondDataSet.EmployeeDataTable();
            adapt.Fill(table1);
            Login.ItemsSource = table1;
            Login.DisplayMemberPath = "Логин";
            Login.SelectedValuePath = "Код";

            TovarTableAdapter adapt2 = new TovarTableAdapter();
            CondDataSet.TovarDataTable table2 = new CondDataSet.TovarDataTable();
            adapt2.Fill(table2);
            Tov.ItemsSource = table2;
            Tov.DisplayMemberPath = "Имя товара";
            Tov.SelectedValuePath = "Код";

            ClientTableAdapter adapt3 = new ClientTableAdapter();
            CondDataSet.ClientDataTable table3 = new CondDataSet.ClientDataTable();
            adapt3.Fill(table3);
            Client.ItemsSource = table3;
            Client.DisplayMemberPath = "Почта";
            Client.SelectedValuePath = "Код";

            UslugiTableAdapter adapt4 = new UslugiTableAdapter();
            CondDataSet.UslugiDataTable table4 = new CondDataSet.UslugiDataTable();
            adapt4.Fill(table4);
            Usluga.ItemsSource = table4;
            Usluga.DisplayMemberPath = "Наименование";
            Usluga.SelectedValuePath = "Код";
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
        

        private void Add_sklad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(Cost.Text) && !String.IsNullOrWhiteSpace(Kol_vo.Text) && !String.IsNullOrWhiteSpace(Usluga.Text) && !String.IsNullOrWhiteSpace(Login.Text) && !String.IsNullOrWhiteSpace(Tov.Text) && !String.IsNullOrWhiteSpace(Client.Text))
                {
                    new ChekTableAdapter().InsertQuery(Convert.ToInt32(Cost.Text), Convert.ToInt32(Kol_vo.Text), Convert.ToInt32(Usluga.SelectedValue), Convert.ToInt32(Tov.SelectedValue), Convert.ToInt32(Client.SelectedValue), Convert.ToInt32(Login.SelectedValue));
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
                if (!String.IsNullOrWhiteSpace(Cost.Text) && !String.IsNullOrWhiteSpace(Kol_vo.Text) && !String.IsNullOrWhiteSpace(Usluga.Text) && !String.IsNullOrWhiteSpace(Login.Text) && !String.IsNullOrWhiteSpace(Tov.Text) && !String.IsNullOrWhiteSpace(Client.Text))
            {
                new ChekTableAdapter().UpdateQuery(Convert.ToInt32(Cost.Text), Convert.ToInt32(Kol_vo.Text), Convert.ToInt32(Usluga.SelectedValue), Convert.ToInt32(Tov.SelectedValue), Convert.ToInt32(Client.SelectedValue), Convert.ToInt32(Login.SelectedValue), Convert.ToInt32((db_uslugi.SelectedItems[0] as DataRowView).Row.ItemArray[0]));
                    Kol_vo.Text = "";
                Cost.Text = "";
                Login.Text = "";
                Tov.Text = "";
                Client.Text = "";
                Usluga.Text = "";    
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
                new ChekTableAdapter().DeleteQuery(Convert.ToInt32((db_uslugi.SelectedItems[0] as DataRowView).Row.ItemArray[0]));
                Error.Text = "";
                Acess.Text = "✔ Данные успешно удалены";
                RefreshData();
                Kol_vo.Text = "";
                Cost.Text = "";
                Usluga.Text = "";
                Login.Text = "";
                Tov.Text = "";
                Client.Text = "";

            }
            catch
            {
                Acess.Text = "";
                Error.Text = "⚠ Выберите строку из таблицы для удаления";
            }
        }

        private void db(object sender, SelectionChangedEventArgs e)
        {
            if (db_uslugi.SelectedItem != null)
            {
                if (Kol_vo.Text != null & Cost.Text != null & Login.Text != null & Tov.Text != null & Client.Text != null & Usluga.Text != null)
                {
                    if (db_uslugi.SelectedItem != null) Kol_vo.Text = (db_uslugi.SelectedItem as DataRowView).Row.ItemArray[2].ToString();
                    if (db_uslugi.SelectedItem != null) Cost.Text = (db_uslugi.SelectedItem as DataRowView).Row.ItemArray[1].ToString();
                    if (db_uslugi.SelectedItem != null) Usluga.Text = (db_uslugi.SelectedItem as DataRowView).Row.ItemArray[3].ToString();
                    if (db_uslugi.SelectedItem != null) Login.Text = (db_uslugi.SelectedItem as DataRowView).Row.ItemArray[6].ToString();
                    if (db_uslugi.SelectedItem != null) Tov.Text = (db_uslugi.SelectedItem as DataRowView).Row.ItemArray[4].ToString();
                    if (db_uslugi.SelectedItem != null) Client.Text = (db_uslugi.SelectedItem as DataRowView).Row.ItemArray[5].ToString();
                }
                else { }
            }
            else { }
        }
    }
}
