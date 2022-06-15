using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Prac3
{
    /// <summary>
    /// Interaction logic for UserFormWPF.xaml
    /// </summary>
    public partial class UserFormWPF : Window
    {
        string connectionString = null;
        SqlConnection connection = null;
        SqlCommand command;
        SqlDataAdapter adapter;
        DataTable dT;
        string login;
        public UserFormWPF()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        private void Close_User_Mode_but_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new MainWindow().Show();
        }
        private void RegUser(string firstName, string lastName, string login, string password)
        {
            string strQ = "";
            connection = new SqlConnection(connectionString);
            connection.Open();

            strQ = $"Insert into MainTable (Name, Surname, Login, Password, Status, Restriction) VALUES ('{firstName}', '{lastName}', '{login}', '{password}', {1}, {1})";

            try
            {
                command = new SqlCommand(strQ, connection);
                command.ExecuteNonQuery();

                MessageBox.Show("User registered");
            }
            catch (Exception e)
            {

                MessageBox.Show("A user with this login already exists \n" + e.Message);
            }

            connection.Close();

            FirstName_For_Reg_Field.Text = "";
            LastName_For_Reg_Field.Text = "";
            Log_For_Reg_Field.Text = "";
            Pass_For_Reg_Field.Password = "";
            Pass_For_Reg_Repeat_Field.Password = "";

        }

        int c = 0;
        private void AutorBtn_Click(object sender, RoutedEventArgs e)
        {
            
            string login = loginField.Text;
            string passwd = passwdField.Password;
            connection = new SqlConnection(connectionString);
            connection.Open();
            if (connection.State == System.Data.ConnectionState.Open)
            {
                String strQ = "SELECT * FROM MainTable WHERE Login='" + login + "';";
                adapter = new SqlDataAdapter(strQ, connection);
                dT = new DataTable("Користувачі системи");
                adapter.Fill(dT);
                if (dT.Rows.Count == 0)
                    MessageBox.Show("No such user found");
                else
                {
                    bool Status = Convert.ToBoolean(dT.Rows[0][4]);
                    if (!Status)
                        MessageBox.Show("User Blocked by System Administrator");

                    else
                    {
                        if ((dT.Rows[0][2].ToString() == login) && (dT.Rows[0][3].ToString() == passwd))
                        {
                            NewNameField.Text = dT.Rows[0][0].ToString();
                            NewSurnameField.Text = dT.Rows[0][1].ToString();
                            NewPasswdField.Password = "";
                            NewPasswdField2.Password = "";
                            NewNameField.IsEnabled = true;
                            NewSurnameField.IsEnabled = true;
                            NewPasswdField.IsEnabled = true;
                            NewPasswdField2.IsEnabled = true;
                            UpdateDataBtn.IsEnabled = true;

                        }
                        else
                        {
                            c++;

                            String s = "Incorrect password entered!" + "Attempts left:" + (3 - c).ToString();

                            MessageBox.Show(s);

                            if (c == 3)
                                System.Windows.Application.Current.Shutdown();
                        }
                    }
                }
            }
            connection.Close();
        }
        
        private void Exit_System_But_Click(object sender, RoutedEventArgs e)
        {
            loginField.Text = "";
            passwdField.Password = "";
            NewPasswdField.Password = "";
            NewPasswdField2.Password = "";
            NewNameField.Text = "";
            NewSurnameField.Text = "";
            Exit_System_But.IsEnabled = false;
            UpdateDataBtn.IsEnabled = false;
        }

        private void UpdateDataBtn_Click(object sender, RoutedEventArgs e)
        {
            Check_Data(NewNameField.Text, NewSurnameField.Text, NewPasswdField.Password, NewPasswdField2.Password, false,loginField.Text);
        }
        private void Change_Data(string New_FirstName, string New_LastName, string NewPassword, string NewPassword_Repeat)
        {
            string strQ = "";

            connection = new SqlConnection(connectionString);
            connection.Open();

            if (connection.State == ConnectionState.Open)
            {
                strQ = "UPDATE MainTable SET Name='" + New_FirstName + "', ";
                strQ += "Surname='" + New_LastName + "', ";
                strQ += "Password='" + NewPassword + "' ";
                strQ += "WHERE Login='" + login + "';";

                command = new SqlCommand(strQ, connection);
                command.ExecuteNonQuery();

                MessageBox.Show("Дані змінено!");

            }

            connection.Close();

            NewPasswdField.Password = "";
            NewPasswdField2.Password = "";
            NewNameField.Text = "";
            NewSurnameField.Text = "";
        }
        private Boolean RestrictionCheck(String Pass)
        {
            Byte Count1, Count2, Count3, Count4;
            Byte LenPass = (Byte)Pass.Length;
            Count1 = Count2 = Count3 = Count4 = 0;
            for (Byte i = 0; i < LenPass; i++)
            {
                if ((Convert.ToInt32(Pass[i]) >= 65) && (Convert.ToInt32(Pass[i]) <= 90))

                    Count1++;

                if ((Convert.ToInt32(Pass[i]) >= 97) && (Convert.ToInt32(Pass[i]) <= 122))

                    Count2++;

                if ((Convert.ToInt32(Pass[i]) >= 48) && (Convert.ToInt32(Pass[i]) <= 57))

                    Count4++;

                if ((Pass[i] == '#') || (Pass[i] == '$') || (Pass[i] == '&') || (Pass[i] == '*'))

                    Count3++;
            }
            return Count1 * Count2 * Count3 * Count4 != 0;
        }
        private void Check_Data(string FirstName, string LastName, string Password, string RepeatPassword, bool reg, string Login )
        {
            bool correctpass;

            connection = new SqlConnection(connectionString);
            connection.Open();

            if (FirstName.Length > 20)
            {
                MessageBox.Show("Ім'я не може містити більше 20 символів");
            }

            if (LastName.Length > 20)
            {
                MessageBox.Show("Прізвище не може містити більше 20 символів");
            }

            for (int i = 0; i < FirstName.Length; i++)
            {
                if ((int)FirstName[i] < 65 || ((int)FirstName[i] > 90 && (int)FirstName[i] < 97) || (int)FirstName[i] > 122)
                {
                    MessageBox.Show("В полі Ім'я повинні бути лише латинські літери!");
                }
            }

            for (int i = 0; i < LastName.Length; i++)
            {
                if ((int)LastName[i] < 65 || ((int)LastName[i] > 90 && (int)LastName[i] < 97) || (int)LastName[i] > 122)
                {
                    MessageBox.Show("В полі Прізвище повинні бути лише латинські літери!");
                }
            }

            if (reg)
            {
                if (Login.Length == 0)
                {
                    MessageBox.Show("Логін не може бути пустим рядком!");
                }
                if (Login.Length > 20)
                {
                    MessageBox.Show("Логін не повинен містити більше 20 символів");
                }
            }

            if (Password == RepeatPassword && Password != "")
            {
                if (reg == false)
                {
                    string strQ = $"SELECT * FROM MainTable WHERE Login= '{loginField.Text}';";

                    adapter = new SqlDataAdapter(strQ, connection);

                    dT = new DataTable("Користувачі системи");

                    adapter.Fill(dT);
                    MessageBox.Show(strQ);
                    if ((bool)dT.Rows[0][5] == true)
                    {
                        correctpass = RestrictionCheck(Password);

                        if (correctpass == true)
                        {
                            Change_Data(FirstName, LastName, Password, RepeatPassword);
                        }
                        else
                        {
                            MessageBox.Show("В паролі повинні бути лише латинські літери, мінімум одна Велика літера та службовий символ (#, $, & або *)");
                        }
                    }
                    else
                    {
                        Change_Data(FirstName, LastName, Password, RepeatPassword);
                    }

                    connection.Close();
                }
                else
                {
                    correctpass = RestrictionCheck(Password);

                    if (correctpass)
                    {
                        RegUser(FirstName, LastName, Login, Password);
                    }
                    else
                    {
                        MessageBox.Show("В паролі повинні бути лише латинські літери, мінімум одна Велика літера та службовий символ (#, $, & або *)");
                    }
                }
            }
            else
            {
                MessageBox.Show("Введено пустий пароль або новий пароль повторно введено некоректно!");
            }
        }

        private void Reg_User_But_Click(object sender, RoutedEventArgs e)
        {
            Check_Data(FirstName_For_Reg_Field.Text, LastName_For_Reg_Field.Text, Pass_For_Reg_Field.Password, Pass_For_Reg_Repeat_Field.Password, true, Log_For_Reg_Field.Text);
        }
    }
}
