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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
           
        }
        
        private void CB1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Check();
        }
        public void Check() 
        {
            List<int> arr = new List<int>();
            List<ComboBox> ComBox = new List<ComboBox> { CB1, CB2, CB3, CB4, CB5, CB6, CB7, CB8, CB9, CB10, CB11, CB12, CB13, CB14, CB15, CB16, CB17, CB18, CB19, CB20, CB21, CB22, CB23, CB24, CB25 };
            for (int i = 0; i < 25; i++)
            {
                arr.Add((int)ComBox[i].SelectedIndex);

            }
            if (!arr.Contains(-1))
            {
                MessageBox.Show("draw");
            }
            else
            {
                int m = 5;
                int j = 0;
                List<int> arrX = new List<int>();

                for (j = 0; j < m; j++)
                {

                    arrX.Add((int)ComBox[j].SelectedIndex);

                }
                if (!arrX.Contains(-1) && !arrX.Contains(0))
                {
                    MessageBox.Show("nyluku win");
                }
                else if (!arrX.Contains(-1) && !arrX.Contains(1))
                {
                    MessageBox.Show("tic win");

                }
                else
                {
                    m += 5;
                }
                for (int k = 0; k < 5; k++)
                {
                    List<int> arrY = new List<int>();
                    for (j = k; j < 25; j += 5)
                    {

                        arrY.Add((int)ComBox[j].SelectedIndex);

                    }
                    if (!arrY.Contains(-1) && !arrY.Contains(0))
                    {
                        MessageBox.Show("nyluku win");
                    }

                    else if (!arrY.Contains(-1) && !arrY.Contains(1))
                    {
                        MessageBox.Show("tic win");

                    }
                }


                List<int> arrD = new List<int>();
                List<int> arrD1 = new List<int>();
                for (j = 0; j < 25; j += 6)
                {

                    arrD.Add((int)ComBox[j].SelectedIndex);

                }
                for (j = 4; j < 24; j += 4)
                {

                    arrD1.Add((int)ComBox[j].SelectedIndex);

                }
                if (!arrD.Contains(-1) && !arrD.Contains(0)|| !arrD1.Contains(-1) && !arrD1.Contains(0))
                {
                    MessageBox.Show("nyluku win");
                }

                else if (!arrD.Contains(-1) && !arrD.Contains(1)|| !arrD1.Contains(-1) && !arrD1.Contains(1))
                {
                    MessageBox.Show("tic win");

                }


            }
        }

        private void CB2_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            Check();
        }

        private void CB3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Check();
        }

        private void CB4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Check();
        }

        private void CB5_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Check();
        }

        private void CB6_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Check();
        }

        private void CB7_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Check();
        }

        private void CB8_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Check();
        }

        private void CB9_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Check();
        }

        private void CB10_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Check();
        }

        private void CB11_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Check();
        }

        private void CB12_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Check();
        }

        private void CB13_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Check();
        }

        private void CB14_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Check();
        }

        private void CB15_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Check();
        }

        private void CB16_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Check();
        }

        private void CB17_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Check();
        }

        private void CB18_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Check();
        }

        private void CB19_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Check();
        }

        private void CB20_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Check();
        }

        private void CB21_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Check();
        }

        private void CB22_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Check();
        }

        private void CB23_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Check();
        }

        private void CB24_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Check();
        }

        private void CB25_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Check();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<ComboBox> ComBox = new List<ComboBox> { CB1, CB2, CB3, CB4, CB5, CB6, CB7, CB8, CB9, CB10, CB11, CB12, CB13, CB14, CB15, CB16, CB17, CB18, CB19, CB20, CB21, CB22, CB23, CB24, CB25 };
            foreach (var b in ComBox) 
            {
                b.SelectedIndex = -1;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Hide();
            mw.Show();
        }
    }
}
