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
    /// Interaction logic for Administration.xaml
    /// </summary>
    public partial class Administration : Window
    {
        string connectionString = null;
        SqlConnection connection = null;
        SqlCommand command;
        SqlDataAdapter adapter;
        DataTable dT;
        int index = 0;
        int Length;
        public Administration()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        private void Close_Help_Admin_mode_but_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new MainWindow().Show();
        }


        private void Exit_System_But_Click(object sender, RoutedEventArgs e)
        {
            RealAdminPasswd.Password = ""; RealAdminPasswd.IsEnabled = false;
            NewAdminPasswd.Password = ""; NewAdminPasswd.IsEnabled = false;
            NewAdminPasswd2.Password = ""; NewAdminPasswd2.IsEnabled = false;
            Prev.IsEnabled = false; Next.IsEnabled = false;
            UpdatePasswd.IsEnabled = false;
            AddUser.IsEnabled = false;
            CorrectStatusBtn.IsEnabled = false;
            CorrectRestrictionBtn.IsEnabled = false;
            dT.Clear();
            dataGrid.ItemsSource = dT.DefaultView;
            AdminPasswd.Password = "";
            UsersLogins.ItemsSource = "";
        }
        private void Set_ComboBox_Data()
        {
            List<ListBoxItem> items = new List<ListBoxItem>();

            Length = GetLength();

            for (int i = 0; i < Length; i++)
            {
                ListBoxItem temp = new ListBoxItem();
                temp.Content = dT.Rows[i][2].ToString();
                items.Add(temp);
            }

            UsersLogins.ItemsSource = items;
            UsersLogins.SelectedIndex = index;
        }
        private void Set_Data()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            string strQ = "SELECT Name, Surname, Login, Status, Restriction FROM MainTable";

            adapter = new SqlDataAdapter(strQ, connection);

            dT = new DataTable("Користувачі системи");

            adapter.Fill(dT);

            UserNameSelected.Content = dT.Rows[index][0].ToString();
            UserSurnameSelected.Content = dT.Rows[index][1].ToString();
            UserLoginSelected.Content = dT.Rows[index][2].ToString();
            UserStatusSelected.Content = dT.Rows[index][3].ToString();
            UserRestrictionSelected.Content = dT.Rows[index][4].ToString();

            Activity_box.IsChecked = (bool)dT.Rows[index][3];
            Restriction_Box.IsChecked = (bool)dT.Rows[index][4];

            connection.Close();
        }
        private int GetLength()
        {

            connection = new SqlConnection(connectionString);
            connection.Open();

            string strQ = "SELECT Name, Surname, Login, Status, Restriction FROM MainTable";

            adapter = new SqlDataAdapter(strQ, connection);

            dT = new DataTable("Користувачі системи");

            adapter.Fill(dT);

            connection.Close();

            return dT.Rows.Count;
        }
        private void GetAndShowUsersData()
        {
            string SQLQuery = "Select Name as [Ім'я], Surname as [Прізвище], Login as [Логін], Status as [Статус], Restriction as [Обмеження на пароль] From MainTable";

            connection = new SqlConnection(connectionString);
            connection.Open();
            command = new SqlCommand(SQLQuery, connection);
            adapter = new SqlDataAdapter(command);
            DataTable Table = new DataTable();
            adapter.Fill(Table);
            dataGrid.ItemsSource = Table.DefaultView;
            connection.Close();
        }
        private void Is_User_Admin()
        {
            if (UserLoginSelected.Content.ToString() == "ADMIN")
            {
                CorrectStatusBtn.IsEnabled = false;
                CorrectRestrictionBtn.IsEnabled = false;
            }
            else
            {
                CorrectStatusBtn.IsEnabled = true;
                CorrectRestrictionBtn.IsEnabled = true;
            }
        }

        private void AuthentificationAdmin_Click(object sender, RoutedEventArgs e)
        {
            int c = 0;
            string pass = AdminPasswd.Password;
            connection = new SqlConnection(connectionString);
            connection.Open();
            if (connection.State == System.Data.ConnectionState.Open)
            {
                String strQ = "SELECT * FROM MainTable WHERE Login= 'ADMIN';";

                adapter = new SqlDataAdapter(strQ, connection);

                dT = new DataTable("Користувачі системи");

                adapter.Fill(dT);

                if (dT.Rows[0][3].ToString() == pass)
                {
                    AuthentificationAdmin.IsEnabled = false;
                    AdminPasswd.Password = "";
                    RealAdminPasswd.IsEnabled = true;
                    NewAdminPasswd.IsEnabled = true;
                    NewAdminPasswd2.IsEnabled = true;
                    UpdatePasswd.IsEnabled = true;
                    Next.IsEnabled = true;
                    AddUser.IsEnabled = true;
                    UsersLogins1.IsEnabled = true;
                    Exit_System_But.IsEnabled = true;
                    GetAndShowUsersData();

                }
                else
                {
                    c++;

                    String s = "Incorrect password entered!" + "Attempts left:" + (3 - c).ToString();

                    MessageBox.Show(s);

                    if (c == 3)
                        System.Windows.Application.Current.Shutdown();
                }

                Set_ComboBox_Data();
            }

            connection.Close();
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            String strQ;
            String UserLogin = UsersLogins1.Text;

            if (UserLogin != "")
            {
                try
                {
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        strQ = "INSERT INTO MainTable (Name, Surname, Login, Password, Status,Restriction) values('', '', '" + UserLogin + "','', 1, 1); ";

                        command = new SqlCommand(strQ, connection);
                        command.ExecuteNonQuery();

                        connection.Close();

                        Set_ComboBox_Data();

                        MessageBox.Show("User added");

                        UsersLogins1.Text = "";
                    }

                    GetAndShowUsersData();
                }
                catch
                {
                    MessageBox.Show("User not added! Maybe this already exists in this database");
                }

            }
            else
            {
                MessageBox.Show("Login field cannot be empty!");
            }
        }
        private void Check_And_Update_Pass(string Current_Pass, string New_Pass, string New_Pass_Repeat)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            if (connection.State == System.Data.ConnectionState.Open)
            {
                String strQ = "SELECT * FROM MainTable WHERE Login= 'ADMIN';";

                adapter = new SqlDataAdapter(strQ, connection);

                dT = new DataTable("Користувачі системи");

                adapter.Fill(dT);

                if (dT.Rows[0][3].ToString() == Current_Pass)
                {
                    if (New_Pass == New_Pass_Repeat && New_Pass != "")
                    {
                        bool correctpass = RestrictionCheck(New_Pass);

                        if (correctpass)
                        {
                            strQ = "Update MainTable Set Password='" + New_Pass + "' ";
                            strQ += "WHERE Login='ADMIN';";

                            command = new SqlCommand(strQ, connection);
                            command.ExecuteNonQuery();

                            MessageBox.Show("Password changed");
                        }
                        else
                        {
                            MessageBox.Show("The new password must contain only Latin letters, at least one uppercase letter, one digit, and the official character (#, $, &, or *)");
                        }

                    }
                    else
                    {
                        MessageBox.Show("An empty password was entered or a new password was re-entered incorrectly!");
                    }
                }
                else
                {
                    MessageBox.Show("The current password was entered incorrectly!");
                }
            }

            RealAdminPasswd.Password = "";
            NewAdminPasswd.Password = "";
            NewAdminPasswd2.Password = "";

            connection.Close();
        }
        
        private Boolean RestrictionCheck(String Pass)
        {
            Byte Count1, Count2, Count3, Count4;
            Byte LenPass = (Byte)Pass.Length;
            Count1 = Count2 = Count3 = Count4 = 0;
            for (Byte i = 0; i < LenPass; i++)
            {
                if ((Convert.ToInt32(Pass[i]) >= 65) &&(Convert.ToInt32(Pass[i]) <= 90))

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

        private void UpdatePasswd_Click(object sender, RoutedEventArgs e)
        {
            Check_And_Update_Pass(RealAdminPasswd.Password, NewAdminPasswd.Password, NewAdminPasswd2.Password);
        }
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (Prev.IsEnabled == false)
            {
                Prev.IsEnabled = true;
            }

            Length = GetLength();

            if (index < Length - 1)
            {
                index++;

                if (index == Length - 1)
                {
                    Next.IsEnabled = false;
                }

                UsersLogins.SelectedIndex = index;

                Set_Data();

                Is_User_Admin();

                Change_Content_Set_Stop_But();

            }
        }

        private void Prev_Click(object sender, RoutedEventArgs e)
        {

            if (Next.IsEnabled == false)
            {
                Next.IsEnabled = true;
            }

            if (index > 0)
            {
                index--;

                UsersLogins.SelectedIndex = index;

                if (index == 0)
                {
                    Prev.IsEnabled = false;
                }

                Set_Data();

                Is_User_Admin();

                Change_Content_Set_Stop_But();
            }
        }
        private void Change_Content_Set_Stop_But()
        {
            if (UserStatusSelected.Content.ToString() == "True")
            {
                CorrectStatusBtn.Content = "Stop activity";
            }
            else
            {
                CorrectStatusBtn.Content = "Set activity";
            }

            if (UserRestrictionSelected.Content.ToString() == "True")
            {
                CorrectRestrictionBtn.Content = "Delete restriction";
            }
            else
            {
                CorrectRestrictionBtn.Content = "Set restriction";
            }
        }
        private void Log_Users_Box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UsersLogins.SelectedIndex == -1)
            {
                index = 0;
            }
            else
            {
                index = UsersLogins.SelectedIndex;
            }

            Length = GetLength();

            if (index == 0)
            {
                Prev.IsEnabled = false;
            }
            if (index == Length - 1)
            {
                Next.IsEnabled = false;
            }
            if (index > 0 && Prev.IsEnabled == false)
            {
                Prev.IsEnabled = true;
            }
            if (index < Length - 1 && Next.IsEnabled == false)
            {
                Next.IsEnabled = true;
            }

            Set_Data();


            Is_User_Admin();

            Change_Content_Set_Stop_But();

        }

        private void CorrectStatusBtn_Click(object sender, RoutedEventArgs e)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            string strQ;

            if ((string)((Button)e.OriginalSource).Content == "Set activity")
            {
                Activity_box.IsChecked = true;
                ((Button)e.OriginalSource).Content = "Stop activity";
                strQ = "Update MainTable Set Status = 1 ";
                strQ += $"WHERE Login='{UserLoginSelected.Content}';";

                command = new SqlCommand(strQ, connection);
                command.ExecuteNonQuery();
            }
            else
            {
                Activity_box.IsChecked = false;
                ((Button)e.OriginalSource).Content = "Set activity";

                strQ = "Update MainTable Set Status= 0 ";
                strQ += $"WHERE Login='{UserLoginSelected.Content}';";

                command = new SqlCommand(strQ, connection);
                command.ExecuteNonQuery();

            }

            GetAndShowUsersData();

            connection.Close();
        }

        private void CorrectRestrictionBtn_Click(object sender, RoutedEventArgs e)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            string strQ;

            if ((string)((Button)e.OriginalSource).Content == "Set restriction")
            {
                Restriction_Box.IsChecked = true;

                ((Button)e.OriginalSource).Content = "Delete restriction";
                strQ = "Update MainTable Set  Restriction = 1 ";
                strQ += $"WHERE Login='{UserLoginSelected.Content}';";

                command = new SqlCommand(strQ, connection);
                command.ExecuteNonQuery();
            }
            else
            {
                Restriction_Box.IsChecked = false;

                ((Button)e.OriginalSource).Content = "Set restriction";

                strQ = "Update MainTable Set Restriction = 0 ";
                strQ += $"WHERE Login='{UserLoginSelected.Content}';";

                command = new SqlCommand(strQ, connection);
                command.ExecuteNonQuery();
            }

            GetAndShowUsersData();

            connection.Close();
        }
    }
    
}
