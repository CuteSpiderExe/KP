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
    /// Логика взаимодействия для AdminUsers.xaml
    /// </summary>
    public partial class AdminUsers : Window
    {
        public AdminUsers()
        {
            InitializeComponent();
            RefreshData();
        }
        public void RefreshData()
        {
            UserTableAdapter adapter = new UserTableAdapter();
            CondDataSet.UserDataTable table = new CondDataSet.UserDataTable();
            adapter.Fill(table);
            db_user.ItemsSource = table;

            RoleTableAdapter adapt = new RoleTableAdapter();
            CondDataSet.RoleDataTable table1 = new CondDataSet.RoleDataTable();
            adapt.Fill(table1);
            Role.ItemsSource = table1;
            Role.DisplayMemberPath = "Роль";
            Role.SelectedValuePath = "Код";
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AdminMenu AdmM = new AdminMenu();
            AdmM.Show();
            this.Close();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Login Log = new Login();
            Log.Show();
            this.Close();
        }

        private void Add_sklad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(Login.Text) && !String.IsNullOrWhiteSpace(Pass.Text) && !String.IsNullOrWhiteSpace(Role.Text))
                {
                    new UserTableAdapter().InsertQuery(Convert.ToString(Login.Text), Convert.ToString(Pass.Text), Convert.ToInt32(Role.SelectedValue));
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
                if (!String.IsNullOrWhiteSpace(Login.Text) && !String.IsNullOrWhiteSpace(Pass.Text) && !String.IsNullOrWhiteSpace(Role.Text))
                {
                    new UserTableAdapter().UpdateQuery(Login.Text, Convert.ToString(Pass.Text), Convert.ToInt32(Role.SelectedValue), Convert.ToInt32((db_user.SelectedItems[0] as DataRowView).Row.ItemArray[0]));
                    Login.Text = "";
                    Pass.Text = "";
                    Role.Text = "";
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
                new UserTableAdapter().DeleteQuery(Convert.ToInt32((db_user.SelectedItems[0] as DataRowView).Row.ItemArray[0]));
                Error.Text = "";
                Acess.Text = "✔ Данные успешно удалены";
                RefreshData();
                Login.Clear();
                Pass.Clear();
                Role.Text = "";

            }
            catch
            {
                Acess.Text = "";
                Error.Text = "⚠ Выберите строку из таблицы для удаления";
            }
        }
        private void db(object sender, SelectionChangedEventArgs e)
        {
            if (db_user.SelectedItem != null)
            {
                if (Login.Text != null & Pass.Text != null & Role.Text != null)
                {
                    if (db_user.SelectedItem != null) Login.Text = (db_user.SelectedItem as DataRowView).Row.ItemArray[1].ToString();
                    if (db_user.SelectedItem != null) Pass.Text = (db_user.SelectedItem as DataRowView).Row.ItemArray[2].ToString();
                    if (db_user.SelectedItem != null) Role.Text = (db_user.SelectedItem as DataRowView).Row.ItemArray[3].ToString();
                }
                else { }
            }
            else { }
        }
    }
}
