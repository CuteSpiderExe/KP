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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        SqlConnection con = new SqlConnection();
        CondDataSet CondDataSet;
        UserTableAdapter userTableAdapter;

        public Login()
        {
            InitializeComponent();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["KP.Properties.Settings.CondConnectionString"].ConnectionString.ToString();
            CondDataSet = new CondDataSet(); userTableAdapter = new UserTableAdapter(); userTableAdapter.Fill(CondDataSet.User);
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch
            {
            }
        }

        private void Avt_Click(object sender, RoutedEventArgs e)
        {
            string importEmail = Log.Text;
            string importPassword = Pass.Password;

            for (int i = 0; i < CondDataSet.Tables["User"].Rows.Count; i++)
            {
                if (importEmail == CondDataSet.Tables["User"].Rows[i]["Логин"].ToString() && importPassword == CondDataSet.Tables["User"].Rows[i]["Password"].ToString())
                {
                    string roleID = CondDataSet.Tables["User"].Rows[i]["Роль"].ToString();

                    switch (roleID)
                    {
                        case "Касир":
                            {
                                Kasir Kas = new Kasir();
                                Kas.Show();
                                this.Close();
                                break;
                            }
                        case "Кладовщик":
                            {
                                Kladov Klad = new Kladov();
                                Klad.Show();
                                this.Close();
                                break;
                            }
                        case "Администратор":
                            {
                                AdminMenu AdmM = new AdminMenu();
                                AdmM.Show();
                                this.Close();
                                break;
                            }
                        case "АдминистраторБД":
                            {
                                Admin AdmDB = new Admin();
                                AdmDB.Show();
                                this.Close();
                                break;
                            }
                        default: break;
                    }
                }
                else { error.Text =  "⚠  Проверьте правильность введенных данных"; }
            }
        }
    }
}


//private void Log_PreviewTextInput(object sender, TextCompositionEventArgs e)
//{
//    e.Handled = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1.".IndexOf(e.Text) < 0;
//}

//private void Pass_PreviewTextInput(object sender, TextCompositionEventArgs e)
//{
//    e.Handled = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!.".IndexOf(e.Text) < 0;
//}
 


