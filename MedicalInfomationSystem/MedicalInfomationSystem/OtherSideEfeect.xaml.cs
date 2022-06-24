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

    public partial class OtherSideEfeect : Window
    {
        string connectionString = null;
        SqlConnection connection = null;
        SqlCommand command;
        SqlDataAdapter adapter;
        DataTable dT;
        public OtherSideEfeect()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            GetMedicineData();
            connection = new SqlConnection(connectionString);
            connection.Open();
            String strQ = "SELECT NameOfMedicine FROM Medicine;";

            adapter = new SqlDataAdapter(strQ, connection);

            dT = new DataTable("Користувачі системи");


            adapter.Fill(dT);
            for (int i = 0; i < dT.Rows.Count; i++)
            {
                combobox1.Items.Add(dT.Rows[i]["NameOfMedicine"].ToString());
            }

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
            string SQlQuery = "SELECT IDMedicine as [№]," +
                "NameOfMedicine as [Назва лікарства]," +
                "TypeOfUsage as [Спосіб прийняття лікарства]," +
                "Quantity as [Кількість на складі]," +
                "Usage as [Показання]," +
                "OtherSideEffect as [Побічний ефект]" +
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string sql = combobox1.Text;
            string SQlQuery = "SELECT NameOfMedicine as [назва]," + " OtherSideEffect as [побічний ефект] " + "FROM Medicine WHERE NameOfMedicine like '" + sql + "'; ";
            try
            {
                GetAndShowData(SQlQuery, MedicineDB);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            this.Close();
            mw.Show();
        }
    }
}

            
        
    

