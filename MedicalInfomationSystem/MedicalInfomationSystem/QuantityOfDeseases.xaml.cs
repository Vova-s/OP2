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
    /// Interaction logic for QuantityOfDeseases.xaml
    /// </summary>
    public partial class QuantityOfDeseases : Window
    {

        string connectionString = null;
        SqlConnection connection = null;
        SqlCommand command;
        SqlDataAdapter adapter;
        public QuantityOfDeseases()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            GetQuery();
            combobox1.Items.Add("Вакцинація");
            combobox1.Items.Add("Дитячі хвороби ");
            combobox1.Items.Add("Проблеми з тиском");
            combobox1.Items.Add("Проблеми з серцем");
            combobox1.Items.Add("Проблеми із судинами");
            combobox1.Items.Add("Проблеми з суглобами");
            combobox1.Items.Add("Проблеми з судинами");
            combobox1.Items.Add("Проблеми з нирками");
            combobox1.Items.Add("Проблеми з простатою");
            combobox1.Items.Add("Проблеми з щитовидною залозою");
            combobox1.Items.Add("Проблеми з цукровим діабетом");
            combobox1.Items.Add("Проблеми з наднирниками");
            combobox1.Items.Add("Проблеми з гіпофізом");
            combobox1.Items.Add("Проблеми з легенями");
            combobox1.Items.Add("Захворювання бронхів");
            combobox1.Items.Add("Рак");
            combobox1.Items.Add("Біль у животі");
            combobox1.Items.Add("Проблеми з венами");
            combobox1.Items.Add("Проблеми з артеріями");
            combobox1.Items.Add("Проблеми з маткою і придатками");
            combobox1.Items.Add("Вагітність");
            combobox1.Items.Add("Проблеми з вухом");
            combobox1.Items.Add("Проблеми з горлом");
            combobox1.Items.Add("Проблеми з носом");
            combobox1.Items.Add("Проблеми з очима");
            combobox1.Items.Add("Проблеми з прямою кишкою");
            combobox1.Items.Add("Травми");
            combobox1.Items.Add("Проблеми з суглобами внаслідок травми");
            combobox1.Items.Add("Проблеми з хребтом");
            combobox1.Items.Add("Кровотечі");
            combobox1.Items.Add("Шок");
            combobox1.Items.Add("Новоутворення");
            combobox1.Items.Add("Проблеми з молочними залозами");
            combobox1.Items.Add("Проблеми з грудними  залозами");
            combobox1.Items.Add("Проблеми з кров'ю");
            combobox1.Items.Add("Проблеми з лімфовузлами");
            combobox1.Items.Add("Проблеми з нервами");
            combobox1.Items.Add("Розлади мозкового кровообігу");
            combobox1.Items.Add("Алергії");
            combobox1.Items.Add("Астма");
            combobox1.Items.Add("Депресія");
            combobox1.Items.Add("Психози");
            combobox1.Items.Add("Алкоголізм");
            combobox1.Items.Add("Накроманія");
            combobox1.Items.Add("Проблеми із зубами ");
            combobox1.Items.Add("Стоматит");
            combobox1.Items.Add("Ожиріння");
            combobox1.Items.Add("Проблеми з ШКТ");
        }
        private void GetQuery()
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
                GetAndShowData(SQlQuery, Query2);
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
            string sql = combobox1.Text;
            GetQuery2(sql);
        }
        private void GetQuery2(string s)
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
                "WHERE Symptom like '" + s + "'; ";
            try
            {
                GetAndShowData(SQlQuery, Query2);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
