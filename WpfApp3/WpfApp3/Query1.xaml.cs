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
    /// Interaction logic for Window5.xaml
    /// </summary>
    public partial class Window5 : Window
    {
        string connectionString = null;
        SqlConnection connection = null;
        SqlCommand command;
        SqlDataAdapter adapter;
        public Window5()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            GetQuery1();
            GetQuery2();
            GetQuery3();
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
        private void GetQuery1()
        {
            string SQlQuery = "SELECT * FROM Appointmentt WHERE TimeOfAppointment like '%" + "2022-02-07" + "%';";
            try
            {
                GetAndShowData(SQlQuery, Query1);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void GetQuery2()
        {
            string SQlQuery = "SELECT * FROM Appointmentt WHERE Symptom like '%" + "Проблеми з суглобами" + "%'; ";
            try
            {
                GetAndShowData(SQlQuery, Query2);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void GetQuery3()
        {
            string SQlQuery = "SELECT NameOfMedicine as [назва]," + " OtherSideEffect as [побічний ефект] " + "FROM Medicine WHERE NameOfMedicine like '%" + "Тизин" + "%';";
            try
            {
                GetAndShowData(SQlQuery, Query3);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow(); 
            mw.Show();
            this.Close();
        }
    }
}
