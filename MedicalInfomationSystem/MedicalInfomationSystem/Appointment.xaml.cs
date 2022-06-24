using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.ComponentModel;
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
    /// Interaction logic for Appointment.xaml
    /// </summary>
    public partial class Appointment : Window
    {
        string connectionString = null;
        SqlConnection connection = null;
        SqlCommand command;
        SqlDataAdapter adapter;
        public Appointment()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            GetAppointmentData();
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
        private void GetAppointmentData()
        {
            string SQlQuery = "SELECT AppID as [№]," +
                "CustSurname as [Прізвище пацієнта]," +
                "CustName as [Ім'я пацієнта]," +
                "FORMAT(TimeOfAppointment,'d') as [Дата прийому]," +
                "FamDocSurname as [Прізвище сімейного лікаря]," +
                "FamDocName as [Ім'я сімейного лікаря]," +
                "FamDocSpec as [Спеціалізація]," +
                "Symptom as [Симптоми]," +
                "DocSurname as [Прізвище спеціаліста]," +
                "DocName as [Ім'я спеціаліста]," +
                "DocSpec as [Спеціалізація]," +
                "MedicineName as [Назва лікарства]," +
                "UsageOfMedicine as [Спосіб прийняття лікарства]," +
                "BacksideEffect as [Побічний ефект] " +
                "FROM Apointment " +
                "ORDER by AppID;";
            try
            {
                GetAndShowData(SQlQuery, Appointmen);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void Insert_Click(object sender, RoutedEventArgs e)
        {

            connection.Open();
            SqlCommand cmd = new SqlCommand("INSERT into Apointment values (@AppID,@CustID,@CustSurname,@CustName,@TimeOfAppointment,@FamDocID,@FamDocSurname,@FamDocName,@FamDocSpec,@IDSymptom,@Symptom,@DocID,@DocSurname,@DocName,@DocSpec,@MedicineID,@MedicineName,@UsageOfMedicine,@BacksideEffect)", connection);
            cmd.Parameters.AddWithValue("@AppID", int.Parse(TB18.Text));
            cmd.Parameters.AddWithValue("@CustID", int.Parse(TB1.Text));
            cmd.Parameters.AddWithValue("@CustSurname", TB2.Text);
            cmd.Parameters.AddWithValue("@CustName", TB3.Text);
            cmd.Parameters.AddWithValue("@TimeOfAppointment", DateTime.Parse(this.datapicker1.Text));
            cmd.Parameters.AddWithValue("@FamDocID", int.Parse(TB4.Text));
            cmd.Parameters.AddWithValue("@FamDocSurname", TB5.Text);
            cmd.Parameters.AddWithValue("@FamDocName", TB6.Text);
            cmd.Parameters.AddWithValue("@FamDocSpec", TB7.Text);
            cmd.Parameters.AddWithValue("@IDSymptom", int.Parse(TB8.Text));
            cmd.Parameters.AddWithValue("@Symptom", TB9.Text);
            cmd.Parameters.AddWithValue("@DocID", int.Parse(TB11.Text));
            cmd.Parameters.AddWithValue("@DocSurname", TB10.Text);
            cmd.Parameters.AddWithValue("@DocName", TB12.Text);
            cmd.Parameters.AddWithValue("@DocSpec", TB13.Text);
            cmd.Parameters.AddWithValue("@MedicineID", int.Parse(TB14.Text));
            cmd.Parameters.AddWithValue("@MedicineName", TB15.Text);
            cmd.Parameters.AddWithValue("@UsageOfMedicine", TB16.Text);
            cmd.Parameters.AddWithValue("@BacksideEffect", TB17.Text);
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Successfully Saved");
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            DateTime aDate = DateTime.Now;
            connection.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Apointment set CustID=@CustID,CustSurname=@CustSurname, CustName=@CustName, TimeOfAppointment=@TimeOfAppointment, FamDocID=@FamDocID, FamDocSurname=@FamDocSurname, FamDocName=@FamDocName, FamDocSpec=@FamDocSpec, IDSymptom=@IDSymptom,Symptom=@Symptom, DocID=@DocID, DocSurname@DocSurname, DocName=@DocName, DocSpec=@DocSpec,MedicineID=@MedicineID, MedicineName=@MedicineName,UsageOfMedicine=@UsageOfMedicine,BacksideEffect=@BacksideEffect where AppID=@AppID", connection);
            cmd.Parameters.AddWithValue("@AppID", int.Parse(TB18.Text));
            cmd.Parameters.AddWithValue("@CustID", int.Parse(TB1.Text));
            cmd.Parameters.AddWithValue("@CustSurname", TB2.Text);
            cmd.Parameters.AddWithValue("@CustName", TB3.Text);
            cmd.Parameters.AddWithValue("@TimeOfAppointment", DateTime.Parse(this.datapicker1.Text));
            cmd.Parameters.AddWithValue("@FamDocID", int.Parse(TB4.Text));
            cmd.Parameters.AddWithValue("@FamDocSurname", TB5.Text);
            cmd.Parameters.AddWithValue("@FamDocName", TB6.Text);
            cmd.Parameters.AddWithValue("@FamDocSpec", TB7.Text);
            cmd.Parameters.AddWithValue("@IDSymptom", int.Parse(TB8.Text));
            cmd.Parameters.AddWithValue("@Symptom", TB9.Text);
            cmd.Parameters.AddWithValue("@DocID", int.Parse(TB11.Text));
            cmd.Parameters.AddWithValue("@DocSurname", TB10.Text);
            cmd.Parameters.AddWithValue("@DocName", TB12.Text);
            cmd.Parameters.AddWithValue("@DocSpec", TB13.Text);
            cmd.Parameters.AddWithValue("@MedicineID", int.Parse(TB14.Text));
            cmd.Parameters.AddWithValue("@MedicineName", TB15.Text);
            cmd.Parameters.AddWithValue("@UsageOfMedicine", TB16.Text);
            cmd.Parameters.AddWithValue("@BacksideEffect", TB17.Text);
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Successfully Updated");
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("DELETE Apointment where AppID=@AppID", connection);
            cmd.Parameters.AddWithValue("@AppID", int.Parse(TB18.Text));
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Successfully Deleted");
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            GetAppointmentData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            this.Close();
            mw.Show();
        }
    }
}
