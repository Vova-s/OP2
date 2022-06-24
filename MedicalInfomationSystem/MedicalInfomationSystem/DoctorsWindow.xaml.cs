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
    /// Interaction logic for DoctorsWindow.xaml
    /// </summary>
    public partial class DoctorsWindow : Window
    {
        string connectionString = null;
        SqlConnection connection = null;
        SqlCommand command;
        SqlDataAdapter adapter;
        public DoctorsWindow()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            GetDoctorsData();
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
        private void GetDoctorsData()
        {
            string SQlQuery = "SELECT doctor_ID as [№]," +
                "doctors_surname as [Прізвище спеціаліста]," +
                "doctors_name as [Ім'я спеціаліста]," +
                "specialization as [Спеціалізація]," +
                "degree as [Наукова ступінь]," +
                "experience as [Досвід роботи] " +
                "FROM Doctorr;";
            try
            {
                GetAndShowData(SQlQuery, DoctorsDB);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("INSERT into Doctorr values (@doctor_ID,@doctors_surname,@doctors_name,@specialization,@degree,@experience)", connection);
            cmd.Parameters.AddWithValue("@doctor_ID", int.Parse(TB1.Text));
            cmd.Parameters.AddWithValue("@doctors_surname", TB2.Text);
            cmd.Parameters.AddWithValue("@doctors_name", TB3.Text);
            cmd.Parameters.AddWithValue("@specialization", TB4.Text);
            cmd.Parameters.AddWithValue("@degree", TB5.Text);
            cmd.Parameters.AddWithValue("@experience", int.Parse(TB6.Text));
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Successfully Saved");
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Doctorr set doctors_surname=@doctors_surname,doctors_name=@doctors_name, specialization=@specialization, degree=@degree, experience=@experience where doctor_ID =@doctor_ID", connection);
            cmd.Parameters.AddWithValue("@doctor_ID", int.Parse(TB1.Text));
            cmd.Parameters.AddWithValue("@doctors_surname", TB2.Text);
            cmd.Parameters.AddWithValue("@doctors_name", TB3.Text);
            cmd.Parameters.AddWithValue("@specialization", TB4.Text);
            cmd.Parameters.AddWithValue("@degree", TB5.Text);
            cmd.Parameters.AddWithValue("@experience", int.Parse(TB6.Text));
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Successfully Updated");
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("Delete Doctorr where doctor_ID=@doctor_ID", connection);
            cmd.Parameters.AddWithValue("@doctor_ID", int.Parse(TB1.Text));
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Successfully Deleted");
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            GetDoctorsData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            this.Close();
            mw.Show();
        }
    }
}
