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
    public partial class Info : Window
    {
        public Info()
        {
            Initialization();
        }
        Button ReturnToMain;
        Label label1;
        Label label2;
        public void Initialization()
        {
            Height = 450;
            Width = 800;
            Grid grid = new Grid();
            Brush newColor1 = Brushes.White;
            FontWeight FW = FontWeights.Normal;
            FontWeight FW1 = FontWeights.Bold;
            ReturnToMain = CreateElements.CreateButton(grid, "ReturnToMain", "MainWindow", HorizontalAlignment.Left, VerticalAlignment.Top, 600,330,115,40, newColor1, ReturnToMain_Click);
            label1 = CreateElements.CreateLabel(grid, "Симчич Володимир Антонович", HorizontalAlignment.Left, VerticalAlignment.Top, 360, 55, newColor1, "Tw Cen MT Condensed", FW1, 24);
            label2 = CreateElements.CreateLabel(grid, "Дякую за увагу", HorizontalAlignment.Left, VerticalAlignment.Top, 395, 205, newColor1, "Tw Cen MT Condensed", FW1, 20);


            Ellipse el = new Ellipse();
            el.Width = 200;
            el.Height = 200;
            el.Margin = new Thickness(30, 70, 562, 149);
            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = new BitmapImage(new Uri(@"C:\Users\VOVAN\source\repos\WpfApp1\WpfApp1\78002.JPG", UriKind.Relative));
            el.Fill = imageBrush;
            grid.Children.Add(el);

            Content = grid;

        }

        private void ReturnToMain_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new MainWindow().Show();
        }
    }
}