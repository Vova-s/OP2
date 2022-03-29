using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Lab2_sem2
{
    public partial class Calculator : Window
    {
        public Calculator()
        {
            Initialization();
        }
        TextBox tb;
        Button ReturnToMain;
        Button Result;
        Button Off;
        Button Del;
        Button Clear;
        Button button0;
        Button button1;
        Button button2;
        Button button3;
        Button button4;
        Button button5;
        Button button6;
        Button button7;
        Button button8;
        Button button9;
        Button buttonPlus;
        Button buttonMinus;
        Button buttonMultiplication;
        Button buttonDivision;




        public void Initialization()
        {
            Height = 450;
            Width = 800;
            FontWeight FW = FontWeights.Bold; 
            Title = "Calculator";
            Grid grid = new Grid();
            Brush newcolor1 = Brushes.Gray;
            Brush newcolor2 = Brushes.White;
            Brush newcolor3 = Brushes.Black;
            grid.Background = newcolor1;
            tb = CreateElements.CreateTextBox(grid, "tb", HorizontalAlignment.Left, VerticalAlignment.Top, 0, 0, 792, 72, "", newcolor2, newcolor1);
            tb.FontSize = 18;
            tb.FontWeight = FW;
            button0 = CreateElements.CreateButton1(grid, "button0", "0", HorizontalAlignment.Left, VerticalAlignment.Top, 192, 348, 200, 70,FW,18, newcolor2,newcolor3, Button_Click_1);
            button1 = CreateElements.CreateButton1(grid, "button1", "1", HorizontalAlignment.Left, VerticalAlignment.Top, 0, 278, 192, 70, FW, 18, newcolor2, newcolor3, Button_Click_1);
            button2 = CreateElements.CreateButton1(grid, "button2", "2", HorizontalAlignment.Left, VerticalAlignment.Top, 192, 278, 200, 70, FW, 18, newcolor2, newcolor3, Button_Click_1);
            button3 = CreateElements.CreateButton1(grid, "button3", "3", HorizontalAlignment.Left, VerticalAlignment.Top, 392, 278, 200, 70, FW, 18, newcolor2, newcolor3, Button_Click_1);
            button4 = CreateElements.CreateButton1(grid, "button4", "4", HorizontalAlignment.Left, VerticalAlignment.Top, 0, 208, 192, 70, FW, 18, newcolor2, newcolor3, Button_Click_1);
            button5 = CreateElements.CreateButton1(grid, "button5", "5", HorizontalAlignment.Left, VerticalAlignment.Top, 192, 208, 200, 70, FW, 18, newcolor2, newcolor3, Button_Click_1);
            button6 = CreateElements.CreateButton1(grid, "button6", "6", HorizontalAlignment.Left, VerticalAlignment.Top, 392, 208, 200, 70, FW, 18, newcolor2, newcolor3, Button_Click_1);
            button7 = CreateElements.CreateButton1(grid, "button7", "7", HorizontalAlignment.Left, VerticalAlignment.Top, 0,142, 192, 70, FW, 18, newcolor2, newcolor3, Button_Click_1);
            button8 = CreateElements.CreateButton1(grid, "button8", "8", HorizontalAlignment.Left, VerticalAlignment.Top, 192, 142, 200, 70, FW, 18, newcolor2, newcolor3, Button_Click_1);
            button9 = CreateElements.CreateButton1(grid, "button9", "9", HorizontalAlignment.Left, VerticalAlignment.Top, 392, 142, 200, 70, FW, 18, newcolor2, newcolor3, Button_Click_1);
            buttonPlus = CreateElements.CreateButton1(grid, "buttonPlus", "+", HorizontalAlignment.Left, VerticalAlignment.Top, 592, 278, 200, 70, FW, 18, newcolor2, newcolor3, Button_Click_1);
            buttonMinus = CreateElements.CreateButton1(grid, "buttonMinus", "-", HorizontalAlignment.Left, VerticalAlignment.Top, 592, 212, 200, 70, FW, 18, newcolor2, newcolor3, Button_Click_1);
            buttonMultiplication = CreateElements.CreateButton1(grid, "buttonMultiplication", "/", HorizontalAlignment.Left, VerticalAlignment.Top, 592, 142, 200, 70, FW, 18, newcolor2, newcolor3, Button_Click_1);
            buttonDivision = CreateElements.CreateButton1(grid, "buttonDivision", "*", HorizontalAlignment.Left, VerticalAlignment.Top, 592, 72, 200, 70, FW, 18, newcolor2, newcolor3, Button_Click_1);
            ReturnToMain = CreateElements.CreateButton1(grid, "ReturnToMain", "ToMain", HorizontalAlignment.Left, VerticalAlignment.Top, 0, 72,392, 70, FW, 18, newcolor2, newcolor3, ReturnToMain_Click);
            Result = CreateElements.CreateButton1(grid, "Result", "=", HorizontalAlignment.Left, VerticalAlignment.Top, 392, 348, 200, 70, FW, 18, newcolor2, newcolor3, Result_click);
            Off = CreateElements.CreateButton1(grid, "Off", "Off", HorizontalAlignment.Left, VerticalAlignment.Top, 592, 348, 200, 70, FW, 18, newcolor2, newcolor3, Off_Click_1);
            Del = CreateElements.CreateButton1(grid, "Del", "Del", HorizontalAlignment.Left, VerticalAlignment.Top, 392, 72, 200, 70, FW, 18, newcolor2, newcolor3, Del_Click);
            Clear = CreateElements.CreateButton1(grid, "Clear", "Clear", HorizontalAlignment.Left, VerticalAlignment.Top, 0, 348, 192, 70, FW, 18, newcolor2, newcolor3, Clear_Click);
            Content = grid;
        }
      
        private void ReturnToMain_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new MainWindow().Show();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            tb.Text += b.Content.ToString();
        }
        private void Result_click(object sender, RoutedEventArgs e)
        {
            try
            {
                result();
            }
            catch (Exception a)
            {
                tb.Text = "Error!";
            }
        }
        private void result()
        {
            String action;
            int IndexAction = 0;
            if (tb.Text.Contains("+"))
            {
                IndexAction = tb.Text.IndexOf("+");
            }
            else if (tb.Text.Contains("-"))
            {
                IndexAction = tb.Text.IndexOf("-");
            }
            else if (tb.Text.Contains("*"))
            {
                IndexAction = tb.Text.IndexOf("*");
            }
            else if (tb.Text.Contains("/"))
            {
                IndexAction = tb.Text.IndexOf("/");
            }
            else
            {
                tb.Text = "Error!";
            }

            action = tb.Text.Substring(IndexAction, 1);
            double part1 = Convert.ToDouble(tb.Text.Substring(0, IndexAction));
            double part2 = Convert.ToDouble(tb.Text.Substring(IndexAction + 1, tb.Text.Length - IndexAction - 1));

            if (action == "+")
            {
                tb.Text += "=" + (part1 + part2);
            }
            else if (action == "-")
            {
                tb.Text += "=" + (part1 - part2);
            }
            else if (action == "*")
            {
                tb.Text += "=" + (part1 * part2);
            }
            else
            {
                tb.Text += "=" + (part1 / part2);
            }
        }

        private void Off_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            tb.Text = "";
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            if (tb.Text.Length > 0)
            {
                tb.Text = tb.Text.Substring(0, tb.Text.Length - 1);
            }
        }

    }
}
