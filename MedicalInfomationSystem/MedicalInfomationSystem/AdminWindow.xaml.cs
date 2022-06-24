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

namespace MedicalInfomationSystem
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void QuantityOfCalls_Click(object sender, RoutedEventArgs e)
        {
            QuantityOfCalls qc = new QuantityOfCalls();
            this.Close();
            qc.Show();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Medicine med = new Medicine();
            this.Close();
            med.Show();
        }

        private void btnBack_Copy2_Click(object sender, RoutedEventArgs e)
        {
            OtherSideEfeect ot = new OtherSideEfeect();
            this.Close();
            ot.Show();
        }

        private void btnBack_Copy_Click(object sender, RoutedEventArgs e)
        {
            QuantityOfDeseases qd = new QuantityOfDeseases();
            this.Close();
            qd.Show();
        }

        private void btnBack_Copy2Click(object sender, RoutedEventArgs e)
        {
            DoctorsWindow dw = new DoctorsWindow();
            this.Close();
            dw.Show();
        }
    }
}
