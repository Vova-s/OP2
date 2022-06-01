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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        string connectionString = null;
        SqlConnection connection = null;
        SqlCommand command;
        SqlDataAdapter adapter;
        public Window1()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            GetMedicineData();
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
        private void GetMedicineData()
        {
            string SQlQuery = "SELECT IDMedicine as [№],"+
                "NameOfMedicine as [Назва лікарства],"+
                "TypeOfUsage as [Спосіб прийняття лікарства],"+
                "Quantity as [Кількість на складі],"+
                "Usage as [Показання],"+
                "OtherSideEffect as [Побічний ефект]"+
                "FROM Medicine;";

            try
            {
                GetAndShowData(SQlQuery, MedicineDB);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }   
        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("INSERT into Medicine values (@IDMedicine,@NameOfMedicine,@TypeOfUsage,@Quantity,@Usage,@OtherSideEffect)",connection);
            cmd.Parameters.AddWithValue("@IDMedicine", int.Parse(TB1.Text));
            cmd.Parameters.AddWithValue("@NameOfMedicine", TB2.Text);
            cmd.Parameters.AddWithValue("@TypeOfUsage", TB3.Text);
            cmd.Parameters.AddWithValue("@Quantity", int.Parse(TB4.Text));
            cmd.Parameters.AddWithValue("@Usage", TB5.Text);
            cmd.Parameters.AddWithValue("@OtherSideEffect", TB6.Text);
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Successfully Saved");
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Medicine set NameOfMedicine=@NameOfMedicine,TypeOfUsage=@TypeOfUsage, Quantity=@Quantity, Usage=@Usage, OtherSideEffect=@OtherSideEffect where IDMedicine =@IDMedicine", connection);
            cmd.Parameters.AddWithValue("@IDMedicine", int.Parse(TB1.Text));
            cmd.Parameters.AddWithValue("@NameOfMedicine", TB2.Text);
            cmd.Parameters.AddWithValue("@TypeOfUsage", TB3.Text);
            cmd.Parameters.AddWithValue("@Quantity", int.Parse(TB4.Text));
            cmd.Parameters.AddWithValue("@Usage", TB5.Text);
            cmd.Parameters.AddWithValue("@OtherSideEffect", TB6.Text);
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Successfully Updated");
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("Delete Medicine where IDMedicine=@IDMedicine", connection);
            cmd.Parameters.AddWithValue("@IDMedicine", int.Parse(TB1.Text));
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Successfully Deleted");
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            GetMedicineData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }    
    }
}
