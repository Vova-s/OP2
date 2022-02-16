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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Hide();
            mw.Show();
        }
    }
}

