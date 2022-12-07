using Microsoft.Win32;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;

namespace KP 
{
    public partial class Admin : Window
    {
        SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-DS4KH2V; Initial Catalog = Cond; Integrated Security = True");

        public Admin()
        {
            InitializeComponent();

            con.ConnectionString = ConfigurationManager.ConnectionStrings["KP.Properties.Settings.CondConnectionString"].ConnectionString.ToString();


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

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Close();
        }


        private static void BckpBrao(string connection, string cond, string fileCond)
        {
            try
            {
                var cmd = "BACKUP DATABASE @Cond TO DISK = @FileCond";

                using (var con = new SqlConnection(connection))
                using (var cmmd = new SqlCommand(cmd, con))
                {
                    con.Open();

                    cmmd.Parameters.AddWithValue("@Cond", cond);
                    cmmd.Parameters.AddWithValue("@FileCond", fileCond);

                    cmmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show($"{e}");
            }
        }

        private void Puti_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog().ToString().Equals("OK"))
            {
                Puti.Text = dialog.SelectedPath;
            }
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            //if (pyti.Text == string.Empty)
            //{
            //}
            //else
            //{

            BckpBrao(@"Server=DESKTOP-DS4KH2V;Database=Cond;Trusted_Connection=True;MultipleActiveResultSets=true", "Cond", Puti.Text + "\\" + "Cond" + " " + DateTime.Now.ToString("dd.MM.yyyy--HH-mm-ss") + ".bak");
            //System.Windows.MessageBox.Show("hhhnhhhh");
            //}
        }

        private void brow3_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog odialog = new OpenFileDialog();

            odialog.Filter = "files (.bak)|.bak";
            odialog.Title = "Database restore";

            if (odialog.ShowDialog().ToString().Equals("OK"))
            {
                Puti.Text = odialog.FileName;
            }
        }

        private void wost_Click(object sender, RoutedEventArgs e)
        {
            string database = con.Database.ToString();
            con.Open();

            try
            {
                string str1 = string.Format("ALTER DATABASE [" + database + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                SqlCommand cmd1 = new SqlCommand(str1, con);
                cmd1.ExecuteNonQuery();

                string str2 = "USE MASTER RESTORE DATABASE [" + database + "] FROM DISK= '" + Puti.Text + "' WITH REPLACE;";
                SqlCommand cmd2 = new SqlCommand(str2, con);
                cmd2.ExecuteNonQuery();

                string str3 = "ALTER DATABASE [" + database + "] SET MULTI_USER";
                SqlCommand cmd3 = new SqlCommand(str3, con);
                cmd3.ExecuteNonQuery();
                con.Close();
            }
            catch
            {

            }
        }
    }
}