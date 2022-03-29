using System;
using static System.Console;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace Lab2_sem2
{
    public partial class add_delete_student : Window
    {
        public add_delete_student()
        {
            Initialization();
        }
        TextBox TB;
        TextBox TB1;
        TextBox TB2;
        TextBox TB3;
        TextBox TB4;
        TextBox TB_Copy;
        Button ReturnToMain;
        Button Button_1;
        Button Button_2;
        Label label1;
        Label label2;
        Label label3;
        Label label4;
        Label label5;
        Label label6;
        Label label7;
        static StreamReader DataFile;
        static StreamWriter MyFileA;
       
        struct Student
        {
            private string ID;
            private string Surname;
            private string Name;
            private string last_name;
            private string gender;

            public Student(string ID, string Surname, string Name, string last_name, string gender)
            {
                this.ID = ID;
                this.Surname = Surname;
                this.Name = Name;
                this.last_name = last_name;
                this.gender = gender;
            }
            public string getID() => ID;
            public string getSurname() => Surname;
            public string getName() => Name;
            public string getlast_name() => last_name;
            public string getgender() => gender;
            public void printEmployee()
            {
                MyFileA.Write($"{ID},");
                MyFileA.Write($"{Surname},");
                MyFileA.Write($"{Name},");
                MyFileA.Write($"{last_name},");
                MyFileA.Write($"{gender}");
                MyFileA.WriteLine();
            }
        }
        
        public void Initialization()
        {
            Height = 450;
            Width = 800;
            Brush newColor1 = Brushes.Gray;
            Brush newColor2 = Brushes.Black;
            Background = newColor1;
            Grid grid = new Grid();
            FontWeight FW = FontWeights.Normal;
            ReturnToMain = CreateElements.CreateButton(grid, "ReturnToMain", "MainWindow", HorizontalAlignment.Left, VerticalAlignment.Top, 656, 370, 110, 38, newColor1, ReturnToMain_Click);
            Button_1 = CreateElements.CreateButton(grid, "Button_1", "Add new student", HorizontalAlignment.Left, VerticalAlignment.Top, 108, 320, 110, 38, newColor1, Button_Click_1);
            Button_2 = CreateElements.CreateButton(grid, "Button_2", "Delete student", HorizontalAlignment.Left, VerticalAlignment.Top, 492, 180, 110, 38, newColor1, Button_Click_2);
            label1 = CreateElements.CreateLabel(grid, "Info about student", HorizontalAlignment.Left, VerticalAlignment.Top, 93, 31, newColor1, "SimSun", FW, 36);
            label2 = CreateElements.CreateLabel(grid, "ID :", HorizontalAlignment.Left, VerticalAlignment.Top, 15, 129, newColor1, "Tw Cen MT Condensed", FW, 22);
            label3 = CreateElements.CreateLabel(grid, "Surname :", HorizontalAlignment.Left, VerticalAlignment.Top, 15, 161, newColor1, "Tw Cen MT Condensed", FW, 22);
            label4 = CreateElements.CreateLabel(grid, "First name :", HorizontalAlignment.Left, VerticalAlignment.Top, 15, 195, newColor1, "Tw Cen MT Condensed", FW, 22);
            label5 = CreateElements.CreateLabel(grid, "Last name :", HorizontalAlignment.Left, VerticalAlignment.Top, 15, 230, newColor1, "Tw Cen MT Condensed", FW, 22);
            label6 = CreateElements.CreateLabel(grid, "Gender :", HorizontalAlignment.Left, VerticalAlignment.Top, 15, 265, newColor1, "Tw Cen MT Condensed", FW, 22);
            label7 = CreateElements.CreateLabel(grid, "ID :", HorizontalAlignment.Left, VerticalAlignment.Top, 442, 130, newColor1, "Tw Cen MT Condensed", FW, 22);
            TB = CreateElements.CreateTextBox(grid, "TB", HorizontalAlignment.Left, VerticalAlignment.Top, 100, 137, 120, 23, "", newColor1, newColor2);
            TB1 = CreateElements.CreateTextBox(grid, "TB1", HorizontalAlignment.Left, VerticalAlignment.Top, 100, 170, 120, 23, "", newColor1, newColor2);
            TB2 = CreateElements.CreateTextBox(grid, "TB2", HorizontalAlignment.Left, VerticalAlignment.Top, 100, 203, 120, 23, "", newColor1, newColor2);
            TB3 = CreateElements.CreateTextBox(grid, "TB3", HorizontalAlignment.Left, VerticalAlignment.Top, 100, 237, 120, 23, "", newColor1, newColor2);
            TB4 = CreateElements.CreateTextBox(grid, "TB4", HorizontalAlignment.Left, VerticalAlignment.Top, 100, 272, 120, 23, "", newColor1, newColor2);
            TB_Copy = CreateElements.CreateTextBox(grid, "TB_Copy", HorizontalAlignment.Left, VerticalAlignment.Top, 482, 137, 120, 23, "", newColor1, newColor2);
          
            Content = grid;
        }
        public void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string ID = TB.Text;
            string Surname = TB1.Text;
            string FirstName = TB2.Text;
            string LastName = TB3.Text;
            string Gender = TB4.Text;
            List<Student> students = new List<Student>();
            students.Add(new Student(ID, Surname, FirstName, LastName, Gender));
            FileStream file1 = new FileStream("d:\\test.txt", FileMode.Append);
            StreamWriter writer = new StreamWriter(file1);
            writer.Write($"{ID},");
            writer.Write($"{Surname},");
            writer.Write($"{FirstName},");
            writer.Write($"{LastName},");
            writer.Write($"{Gender}");
            writer.WriteLine();
            writer.Close();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string ID1 = TB_Copy.Text;
            try
            {
                DataFile = new StreamReader("d:\\test.txt");
                MyFileA = new StreamWriter("d:\\Rez_a.txt");
            }
            catch (Exception a)
            {
                WriteLine(a.Message);
                return;
            }
            while (!DataFile.EndOfStream)
            {
                string[] List = DataFile.ReadLine().Split(',');
                Student c = new Student(List[0], List[1], List[2], List[3], List[4]);
                if (List[0] != ID1)
                {
                    c.printEmployee();
                }
            }
            DataFile.Close();
            MyFileA.Close();
        }
        private void ReturnToMain_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new MainWindow().Show();
        }
    }
}
