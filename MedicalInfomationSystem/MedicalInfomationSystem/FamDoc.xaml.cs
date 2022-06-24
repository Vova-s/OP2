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
    /// Interaction logic for FamDoc.xaml
    /// </summary>
    public partial class FamDoc : Window
    {
        string connectionString = null;
        SqlConnection connection = null;
        SqlCommand command;
        SqlDataAdapter adapter;
        DataTable dT;
        public FamDoc()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            GetAppointmentData();
            connection = new SqlConnection(connectionString);
            connection.Open();
            String strQ = "SELECT NameOfsymptom FROM Symptoms;";

            adapter = new SqlDataAdapter(strQ, connection);

            dT = new DataTable("Користувачі системи");


            adapter.Fill(dT);
            for (int i = 0; i < dT.Rows.Count; i++)
            {
                combobox1.Items.Add(dT.Rows[i]["NameOfsymptom"].ToString());
            }
        }
        private void GetAppointmentData()
        {
            String strQ = "SELECT dbo.Symptoms.NameOfsymptom," + "dbo.Doctorr.doctors_surname," + "dbo.Doctorr.doctors_name," + "dbo.Specializations.NameOfSpecialization " +
                              "FROM dbo.[Doctors&Specialization] " +
                              "INNER JOIN dbo.Doctorr " +
                              "ON dbo.[Doctors&Specialization].IDDoctor = dbo.Doctorr.doctor_ID " +
                              "INNER JOIN dbo.Specializations " +
                              "ON dbo.[Doctors&Specialization].SpecializationID = dbo.Specializations.IDSpecialization " +
                              "INNER JOIN dbo.[Specialization&Symptoms] " +
                              "ON dbo.Specializations.IDSpecialization = dbo.[Specialization&Symptoms].IdSpecialization " +
                              "INNER JOIN dbo.Symptoms " + "ON dbo.[Specialization&Symptoms].IDSymptom = dbo.Symptoms.IDSymptom;";
            try
            {
                GetAndShowData(strQ, Query);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
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
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            this.Close();
            mw.Show();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string sql = combobox1.Text.ToString();
            String strQ = "SELECT dbo.Symptoms.NameOfsymptom," + "dbo.Doctorr.doctors_surname," + "dbo.Doctorr.doctors_name," + "dbo.Specializations.NameOfSpecialization " +
                            "FROM dbo.[Doctors&Specialization] " +
                            "INNER JOIN dbo.Doctorr " +
                            "ON dbo.[Doctors&Specialization].IDDoctor = dbo.Doctorr.doctor_ID " +
                            "INNER JOIN dbo.Specializations " +
                            "ON dbo.[Doctors&Specialization].SpecializationID = dbo.Specializations.IDSpecialization " +
                            "INNER JOIN dbo.[Specialization&Symptoms] " +
                            "ON dbo.Specializations.IDSpecialization = dbo.[Specialization&Symptoms].IdSpecialization " +
                            "INNER JOIN dbo.Symptoms " + "ON dbo.[Specialization&Symptoms].IDSymptom = dbo.Symptoms.IDSymptom " + "WHERE NameOfsymptom like '" + sql + "'; ";
            adapter = new SqlDataAdapter(strQ, connection);

            dT = new DataTable("Користувачі системи");
            adapter.Fill(dT);
            MessageBox.Show(dT.ToString());
            label1.Content = dT.Rows[0]["doctors_surname"].ToString();
            label2.Content = dT.Rows[0]["doctors_name"].ToString();
            label3.Content = dT.Rows[0]["NameOfSpecialization"].ToString();
        }
    }
}
