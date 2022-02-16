using System;
using static System.Console;
using System.IO;
using System.Text;
using System.Collections.Generic;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Hide();
            mw.Show();
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
        static StreamReader DataFile;
        static StreamWriter MyFileA;
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
    }
}
