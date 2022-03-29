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
    public partial class tic_tac_toe : Window
    {
        public tic_tac_toe()
        {
            Initialization();
        }
        Button ReturnToMain;
        Button StartNewGame;
        ComboBox CB1;
        ComboBox CB2;
        ComboBox CB3;
        ComboBox CB4;
        ComboBox CB5;
        ComboBox CB6;
        ComboBox CB7;
        ComboBox CB8;
        ComboBox CB9;
        ComboBox CB10;
        ComboBox CB11;
        ComboBox CB12;
        ComboBox CB13;
        ComboBox CB14;
        ComboBox CB15;
        ComboBox CB16;
        ComboBox CB17;
        ComboBox CB18;
        ComboBox CB19;
        ComboBox CB20;
        ComboBox CB21;
        ComboBox CB22;
        ComboBox CB23;
        ComboBox CB24;
        ComboBox CB25;
        public void Initialization()
        {
            Height = 450;
            Width = 800;
            Brush newColor1 = Brushes.Black;
            Brush newColor2 = Brushes.Gray;
            Border myBorder = new Border();
            myBorder.BorderBrush =newColor1;
            myBorder.Margin = new Thickness(245, 99, 0, 0);
            myBorder.BorderThickness = new Thickness(1);
            myBorder.Height = 224;
            myBorder.Width = 290;
            myBorder.VerticalAlignment = VerticalAlignment.Top;
            myBorder.HorizontalAlignment = HorizontalAlignment.Left;
            myBorder.Background = Brushes.AliceBlue;
           
            Grid grid = new Grid();
            grid.Children.Add(myBorder);
            ReturnToMain = CreateElements.CreateButton(grid, "ReturnToMain", "MainWindow", HorizontalAlignment.Left, VerticalAlignment.Top, 45, 356, 145, 42, newColor2, ReturnToMain_Click);
            StartNewGame = CreateElements.CreateButton(grid, "StartNewGame", "New Game", HorizontalAlignment.Left, VerticalAlignment.Top, 623, 356, 145, 42, newColor2, Button_Click);
            CB1 = CreateElements.CreateComboBox(grid, "CB1", new string[] { "X", "O" }, HorizontalAlignment.Left, VerticalAlignment.Top, 251, 104, 55, 42, CB_SelectionChanged);
            CB2 = CreateElements.CreateComboBox(grid, "CB2", new string[] { "X", "O" }, HorizontalAlignment.Left, VerticalAlignment.Top, 307, 104, 55, 42, CB_SelectionChanged);
            CB3 = CreateElements.CreateComboBox(grid, "CB3", new string[] { "X", "O" }, HorizontalAlignment.Left, VerticalAlignment.Top, 363, 104, 55, 42, CB_SelectionChanged);
            CB4 = CreateElements.CreateComboBox(grid, "CB4", new string[] { "X", "O" }, HorizontalAlignment.Left, VerticalAlignment.Top, 419, 104, 55, 42, CB_SelectionChanged);
            CB5 = CreateElements.CreateComboBox(grid, "CB5", new string[] { "X", "O" }, HorizontalAlignment.Left, VerticalAlignment.Top, 476, 104, 55, 42, CB_SelectionChanged);
            CB6 = CreateElements.CreateComboBox(grid, "CB6", new string[] { "X", "O" }, HorizontalAlignment.Left, VerticalAlignment.Top, 251, 147, 55, 42, CB_SelectionChanged);
            CB7 = CreateElements.CreateComboBox(grid, "CB7", new string[] { "X", "O" }, HorizontalAlignment.Left, VerticalAlignment.Top, 307, 147, 55, 42, CB_SelectionChanged);
            CB8 = CreateElements.CreateComboBox(grid, "CB8", new string[] { "X", "O" }, HorizontalAlignment.Left, VerticalAlignment.Top, 363, 147, 55, 42, CB_SelectionChanged);
            CB9 = CreateElements.CreateComboBox(grid, "CB9", new string[] { "X", "O" }, HorizontalAlignment.Left, VerticalAlignment.Top, 419, 147, 55, 42, CB_SelectionChanged);
            CB10 = CreateElements.CreateComboBox(grid, "CB10", new string[] { "X", "O" }, HorizontalAlignment.Left, VerticalAlignment.Top, 476, 147, 55, 42, CB_SelectionChanged);
            CB11 = CreateElements.CreateComboBox(grid, "CB11", new string[] { "X", "O" }, HorizontalAlignment.Left, VerticalAlignment.Top, 251, 190, 55, 42, CB_SelectionChanged);
            CB12 = CreateElements.CreateComboBox(grid, "CB12", new string[] { "X", "O" }, HorizontalAlignment.Left, VerticalAlignment.Top, 307, 190, 55, 42, CB_SelectionChanged);
            CB13 = CreateElements.CreateComboBox(grid, "CB13", new string[] { "X", "O" }, HorizontalAlignment.Left, VerticalAlignment.Top, 363, 190, 55, 42, CB_SelectionChanged);
            CB14 = CreateElements.CreateComboBox(grid, "CB14", new string[] { "X", "O" }, HorizontalAlignment.Left, VerticalAlignment.Top, 419, 190, 55, 42, CB_SelectionChanged);
            CB15 = CreateElements.CreateComboBox(grid, "CB15", new string[] { "X", "O" }, HorizontalAlignment.Left, VerticalAlignment.Top, 476, 190, 55, 42, CB_SelectionChanged);
            CB16 = CreateElements.CreateComboBox(grid, "CB16", new string[] { "X", "O" }, HorizontalAlignment.Left, VerticalAlignment.Top, 251, 233, 55, 42, CB_SelectionChanged);
            CB17 = CreateElements.CreateComboBox(grid, "CB17", new string[] { "X", "O" }, HorizontalAlignment.Left, VerticalAlignment.Top, 307, 233, 55, 42, CB_SelectionChanged);
            CB18 = CreateElements.CreateComboBox(grid, "CB18", new string[] { "X", "O" }, HorizontalAlignment.Left, VerticalAlignment.Top, 363, 233, 55, 42, CB_SelectionChanged);
            CB19 = CreateElements.CreateComboBox(grid, "CB19", new string[] { "X", "O" }, HorizontalAlignment.Left, VerticalAlignment.Top, 419, 233, 55, 42, CB_SelectionChanged);
            CB20 = CreateElements.CreateComboBox(grid, "CB20", new string[] { "X", "O" }, HorizontalAlignment.Left, VerticalAlignment.Top, 476, 233, 55, 42, CB_SelectionChanged);
            CB21 = CreateElements.CreateComboBox(grid, "CB21", new string[] { "X", "O" }, HorizontalAlignment.Left, VerticalAlignment.Top, 251, 276, 55, 42, CB_SelectionChanged);
            CB22 = CreateElements.CreateComboBox(grid, "CB22", new string[] { "X", "O" }, HorizontalAlignment.Left, VerticalAlignment.Top, 307, 276, 55, 42, CB_SelectionChanged);
            CB23 = CreateElements.CreateComboBox(grid, "CB23", new string[] { "X", "O" }, HorizontalAlignment.Left, VerticalAlignment.Top, 363, 276, 55, 42, CB_SelectionChanged);
            CB24 = CreateElements.CreateComboBox(grid, "CB24", new string[] { "X", "O" }, HorizontalAlignment.Left, VerticalAlignment.Top, 419, 276, 55, 42, CB_SelectionChanged);
            CB25 = CreateElements.CreateComboBox(grid, "CB25", new string[] { "X", "O" }, HorizontalAlignment.Left, VerticalAlignment.Top, 476, 276, 55, 42, CB_SelectionChanged);
            Content = grid;
        }
        private void ReturnToMain_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new MainWindow().Show();
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
                if (!arrD.Contains(-1) && !arrD.Contains(0) || !arrD1.Contains(-1) && !arrD1.Contains(0))
                {
                    MessageBox.Show("nyluku win");
                }

                else if (!arrD.Contains(-1) && !arrD.Contains(1) || !arrD1.Contains(-1) && !arrD1.Contains(1))
                {
                    MessageBox.Show("tic win");

                }
            }
        }
        private void CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox clicked = (ComboBox)sender;
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
    }
}
