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
    /// Логика взаимодействия для AdminEmployee.xaml
    /// </summary>
    public partial class AdminEmployee : Window
    {
        public AdminEmployee()
        {
            InitializeComponent();
            RefreshData();
        }
        public void RefreshData()
        {
            EmployeeTableAdapter adapter = new EmployeeTableAdapter();
            CondDataSet.EmployeeDataTable table = new CondDataSet.EmployeeDataTable();
            adapter.Fill(table);
            db_empl.ItemsSource = table;

            UserTableAdapter adapt = new UserTableAdapter();
            CondDataSet.UserDataTable table1 = new CondDataSet.UserDataTable();
            adapt.Fill(table1);
            Login.ItemsSource = table1;
            Login.DisplayMemberPath = "Логин";
            Login.SelectedValuePath = "Код";

            DolzTableAdapter adapt2 = new DolzTableAdapter();
            CondDataSet.DolzDataTable table2 = new CondDataSet.DolzDataTable();
            adapt2.Fill(table2);
            Dolz.ItemsSource = table2;
            Dolz.DisplayMemberPath = "Должность";
            Dolz.SelectedValuePath = "Код";

            CondTableAdapter adapt3 = new CondTableAdapter();
            CondDataSet.CondDataTable table3 = new CondDataSet.CondDataTable();
            adapt3.Fill(table3);
            Fil.ItemsSource = table3;
            Fil.DisplayMemberPath = "Адресс";
            Fil.SelectedValuePath = "Код";
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AdminMenu AdmM = new AdminMenu();
            AdmM.Show();
            this.Close();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            AdminMenu AdmM = new AdminMenu();
            AdmM.Show();
            this.Close();
        }

        private void Add_sklad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(Fam.Text) && !String.IsNullOrWhiteSpace(Name.Text) && !String.IsNullOrWhiteSpace(Mail.Text) && !String.IsNullOrWhiteSpace(Number.Text) && !String.IsNullOrWhiteSpace(Login.Text) && !String.IsNullOrWhiteSpace(Dolz.Text) && !String.IsNullOrWhiteSpace(Fil.Text))
                {
                    new EmployeeTableAdapter().InsertQuery(Convert.ToString(Fam.Text), Convert.ToString(Name.Text), Convert.ToString(Otch.Text), Convert.ToString(Mail.Text), Convert.ToString(Number.Text), Convert.ToInt32(Login.SelectedValue), Convert.ToInt32(Dolz.SelectedValue), Convert.ToInt32(Fil.SelectedValue));
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
                if (!String.IsNullOrWhiteSpace(Fam.Text) && !String.IsNullOrWhiteSpace(Name.Text) && !String.IsNullOrWhiteSpace(Mail.Text) && !String.IsNullOrWhiteSpace(Number.Text) && !String.IsNullOrWhiteSpace(Login.Text) && !String.IsNullOrWhiteSpace(Dolz.Text) && !String.IsNullOrWhiteSpace(Fil.Text))
                {
                    new EmployeeTableAdapter().UpdateQuery(Convert.ToString(Fam.Text), Convert.ToString(Name.Text), Convert.ToString(Otch.Text), Convert.ToString(Mail.Text), Convert.ToString(Number.Text), Convert.ToInt32(Login.SelectedValue), Convert.ToInt32(Dolz.SelectedValue), Convert.ToInt32(Fil.SelectedValue), Convert.ToInt32((db_empl.SelectedItems[0] as DataRowView).Row.ItemArray[0]));
                    Fam.Text = "";
                    Name.Text = "";
                    Otch.Text = "";
                    Mail.Text = "";
                    Number.Text = "";
                    Login.Text = "";
                    Dolz.Text = "";
                    Fil.Text = "";
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
                new EmployeeTableAdapter().DeleteQuery(Convert.ToInt32((db_empl.SelectedItems[0] as DataRowView).Row.ItemArray[0]));
                Error.Text = "";
                Acess.Text = "✔ Данные успешно удалены";
                RefreshData();
                Fam.Text = "";
                Name.Text = "";
                Otch.Text = "";
                Mail.Text = "";
                Number.Text = "";
                Login.Text = "";
                Dolz.Text = "";
                Fil.Text = "";

            }
            catch
            {
                Acess.Text = "";
                Error.Text = "⚠ Выберите строку из таблицы для удаления";
            }
        }
        private void db(object sender, SelectionChangedEventArgs e)
        {
            if (db_empl.SelectedItem != null)
            {
                if (Fam.Text != null & Name.Text != null & Otch.Text != null & Mail.Text != null & Number.Text != null & Login.Text != null & Dolz.Text != null & Fil.Text != null) 
                {
                    if (db_empl.SelectedItem != null) Fam.Text = (db_empl.SelectedItem as DataRowView).Row.ItemArray[1].ToString();
                    if (db_empl.SelectedItem != null) Name.Text = (db_empl.SelectedItem as DataRowView).Row.ItemArray[2].ToString();
                    if (db_empl.SelectedItem != null) Otch.Text = (db_empl.SelectedItem as DataRowView).Row.ItemArray[3].ToString();
                    if (db_empl.SelectedItem != null) Mail.Text = (db_empl.SelectedItem as DataRowView).Row.ItemArray[4].ToString();
                    if (db_empl.SelectedItem != null) Number.Text = (db_empl.SelectedItem as DataRowView).Row.ItemArray[5].ToString();
                    if (db_empl.SelectedItem != null) Login.Text = (db_empl.SelectedItem as DataRowView).Row.ItemArray[6].ToString();
                    if (db_empl.SelectedItem != null) Dolz.Text = (db_empl.SelectedItem as DataRowView).Row.ItemArray[7].ToString();
                    if (db_empl.SelectedItem != null) Fil.Text = (db_empl.SelectedItem as DataRowView).Row.ItemArray[8].ToString();
                }
                else { }
            }
            else { }
        }
    }
}
