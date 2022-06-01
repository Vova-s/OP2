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
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        string connectionString = null;
        SqlConnection connection = null;
        SqlCommand command;
        SqlDataAdapter adapter;
        public Window3()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            GetFamilyDoctorData();
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
        private void GetFamilyDoctorData()
        {
            string SQlQuery = "SELECT ID as [№], " +
                "Surname as [Прізвище сімейного лікаря],"+
                "Name as [Ім'я сімейного лікаря],"+
                "Specialization as [Спеціалізація],"+
                "Experience as [Досвід роботи] "+
                " FROM Family_doctors;";
            try
            {
                GetAndShowData(SQlQuery, FamilyDoctorDB);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("INSERT into Family_doctors values (@ID,@Surname,@Name,@Specialization,@Experience)", connection);
            cmd.Parameters.AddWithValue("@ID", int.Parse(TB1.Text));
            cmd.Parameters.AddWithValue("@Surname", TB2.Text);
            cmd.Parameters.AddWithValue("@Name", TB3.Text);
            cmd.Parameters.AddWithValue("@Specialization", TB4.Text);
            cmd.Parameters.AddWithValue("@Experience", int.Parse(TB6.Text));
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Successfully Saved");
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Family_doctors set Surname=@Surname,Name=@Name, Specialization=@Specialization,Experience=@Experience where ID=@ID", connection);
            cmd.Parameters.AddWithValue("@ID", int.Parse(TB1.Text));
            cmd.Parameters.AddWithValue("@Surname", TB2.Text);
            cmd.Parameters.AddWithValue("@Name", TB3.Text);
            cmd.Parameters.AddWithValue("@Specialization", TB4.Text);
            cmd.Parameters.AddWithValue("@Experience", int.Parse(TB6.Text));
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Successfully Updated");
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("Delete Family_doctors where ID=@ID", connection);
            cmd.Parameters.AddWithValue("@ID", int.Parse(TB1.Text));
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Successfully Deleted");
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            GetFamilyDoctorData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}
