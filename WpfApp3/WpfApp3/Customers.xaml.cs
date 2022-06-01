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

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        string connectionString = null;
        SqlConnection connection = null;
        SqlCommand command;
        SqlDataAdapter adapter;
        public Window4()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            GetCustomerData();
        }
        public void GetAndShowData(string SQLQuery, DataGrid dataGrid)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            command = new SqlCommand(SQLQuery, connection);
            adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGrid.ItemsSource = table.DefaultView;
            connection.Close();
        }
        private void GetCustomerData()
        {
            string SQlQuery = "SELECT IDCustomer as [№],"+
                "CustName as [Ім'я пацієнта],"+
                "CustSurname as [Прізвище пацієнта],"+
                "Gender as [Стать],"+
                "FORMAT(DateOfBirthday,'d') as [Дата народження],"+
                "AreaOfLliving as [Область проживання],"+
                "City as [Місто],"+
                "Street as [Вулиця],"+
                "NuberOfHouse as [Номер будинку] "+
                "FROM Customer;";
            try
            {
                GetAndShowData(SQlQuery, CustomersDB);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void Insert_Click(object sender, RoutedEventArgs e)
        {            

            connection.Open();
            SqlCommand cmd = new SqlCommand("INSERT into Customer values (@IDCustomer,@CustName,@CustSurname,@Gender,@DateOfBirthday,@AreaOfLliving,@City,@Street,@NuberOfHouse)", connection);
            cmd.Parameters.AddWithValue("@IDCustomer", int.Parse(TB1.Text));
            cmd.Parameters.AddWithValue("@CustName", TB2.Text);
            cmd.Parameters.AddWithValue("@CustSurname", TB3.Text);
            cmd.Parameters.AddWithValue("@Gender", TB4.Text);
            cmd.Parameters.AddWithValue("@DateOfBirthday", DateTime.Parse(this.datapicker1.Text));
            cmd.Parameters.AddWithValue("@AreaOfLliving", TB6.Text);
            cmd.Parameters.AddWithValue("@City", TB7.Text);
            cmd.Parameters.AddWithValue("@Street", TB8.Text);
            cmd.Parameters.AddWithValue("@NuberOfHouse", int.Parse(TB9.Text));
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Successfully Saved");
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            DateTime aDate = DateTime.Now;
            connection.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Customer set CustName=@CustName,CustSurname=@CustSurname, Gender =@Gender, DateOfBirthday=@DateOfBirthday, AreaOfLliving=@AreaOfLliving, City=@City, Street=@Street, NuberOfHouse = @NuberOfHouse  where IDCustomer=@IDCustomer", connection);
            cmd.Parameters.AddWithValue("@IDCustomer", int.Parse(TB1.Text));
            cmd.Parameters.AddWithValue("@CustName", TB2.Text);
            cmd.Parameters.AddWithValue("@CustSurname", TB3.Text);
            cmd.Parameters.AddWithValue("@Gender", TB4.Text);
            cmd.Parameters.AddWithValue("@DateOfBirthday", DateTime.Parse( this.datapicker1.Text));
            cmd.Parameters.AddWithValue("@AreaOfLliving", TB6.Text);
            cmd.Parameters.AddWithValue("@City", TB7.Text);
            cmd.Parameters.AddWithValue("@Street", TB8.Text);
            cmd.Parameters.AddWithValue("@NuberOfHouse", int.Parse(TB9.Text));
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Successfully Updated");
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("DELETE Customer where IDCustomer=@IDCustomer", connection);
            cmd.Parameters.AddWithValue("@IDCustomer", int.Parse(TB1.Text));
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Successfully Deleted");
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            GetCustomerData();
                
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
              MainWindow mw = new MainWindow(); 
            mw.Show();
            this.Close();
        }
    }
}
