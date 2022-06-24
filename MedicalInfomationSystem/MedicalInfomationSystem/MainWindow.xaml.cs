using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace MedicalInfomationSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool b = true;
        bool flag = true;
        string connectionString = null;
        SqlConnection connection = null;
        SqlCommand command;
        SqlDataAdapter adapter;
        DataTable dT;
        static int c = 0;
        public MainWindow()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            string Loginbox = NameBox.Text;
            string Password = PasswordBox.Text;
            IsDoctor();
            IsFamDoctor();
            if (Loginbox == "ADMIN" && Password == "AdminPass1")
            {
                AdminWindow ad = new AdminWindow();
                this.Hide();
                ad.Show();
            }
            else if (Loginbox == "ADMIN" && Password != "AdminPass1")
            {
                NameBox.Text = "";
                PasswordBox.Text = "";
                MessageBox.Show("Incorrect password");
            }
            else if (b)
            {
                Med md = new Med();
                this.Close();
                md.Show();
            }
            else if (flag)
            {
                FamDoc fd = new FamDoc();
                this.Close();
                fd.Show();

            }
            else 
            {
                MessageBox.Show("incorrect Login or password");
            }
            
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private bool IsDoctor() 
        {
            
            string Loginbox = NameBox.Text;
            string Password = PasswordBox.Text;
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    String strQ = "SELECT * FROM Doctorsauthentificator WHERE DoctorsLogin='" + Loginbox + "';";

                    adapter = new SqlDataAdapter(strQ, connection);

                    dT = new DataTable("Користувачі системи");

                    adapter.Fill(dT);

                    if (dT.Rows[0][2].ToString() != Password)
                    {

                        c++;

                        String s = "Incorrect password entered!" + "Attempts left:" + (3 - c).ToString();

                        MessageBox.Show(s);

                        if (c == 3)
                            System.Windows.Application.Current.Shutdown();
                    }
                    
                }
            }
            catch (Exception n)
            {
                b = false;
            }
            return b;
        }

        private bool IsFamDoctor()
        {

            string Loginbox = NameBox.Text;
            string Password = PasswordBox.Text;
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    String strQ = "SELECT * FROM FamDocAuthentificator WHERE FAMDoctorsLogin='" + Loginbox + "';";

                    adapter = new SqlDataAdapter(strQ, connection);

                    dT = new DataTable("Користувачі системи");

                    adapter.Fill(dT);

                    if (dT.Rows[0][2].ToString() != Password)
                    {

                        c++;

                        String s = "Incorrect password entered!" + "Attempts left:" + (3 - c).ToString();

                        MessageBox.Show(s);

                        if (c == 3)
                            System.Windows.Application.Current.Shutdown();
                    }

                }
            }
            catch (Exception n)
            {
                flag = false;
            }
            return flag;
        }
    }
}
