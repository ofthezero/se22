using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Uwu2.Session1DataSetTableAdapters;

namespace Uwu2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {              

            SqlConnection con = new SqlConnection();
            Session1DataSet Session1DataSet;
            UsersTableAdapter usersTableAdapter;
        

            public Login()
            {
                InitializeComponent();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["KP.Properties.Settings.Session1ConnectionString"].ConnectionString.ToString();
                Session1DataSet = new Session1DataSet(); usersTableAdapter = new UsersTableAdapter(); usersTableAdapter.Fill(Session1DataSet.Users);
            }
        

        private void Log_Click(object sender, RoutedEventArgs e)
        {
            string importEmail = Login.Text;
            string importPassword = Pass.Password;

            for (int i = 0; i < Session1DataSet.Tables["User"].Rows.Count; i++)
            {
                if (importEmail == Session1DataSet.Tables["Users"].Rows[i]["Email"].ToString() && importPassword == Session1DataSet.Tables["Users"].Rows[i]["Password"].ToString())
                {
                    string roleID = Session1DataSet.Tables["Users"].Rows[i]["Role_ID"].ToString();

                    switch (roleID)
                    {
                        case "1":
                            {
                                Admin adm = new Admin();
                                adm.Show();
                                this.Close();
                                break;
                            }
                        case "2":
                            {
                                Rab rab = new Rab();
                                rab.Show();
                                this.Close();
                                break;
                            }                      
                        default: break;
                    }
                }
                else { error.Text = "⚠  Проверьте правильность введенных данных"; }
            }
        }
    }
}
