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

namespace PlantenApplicatie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Frame_Navigated();
         //   BtnbackgroundColor();
        }
        
        private void Frame_Navigated()
        {
            // deze functie nog naar een class doen
            CvsZoeken.Visibility = Visibility.Hidden;           
        }

        private void BtnbackgroundColor() 
        {
            btnNaam.Background = Brushes.Transparent;
            // deze functie nog naar een class doen
        }

        private void btnNaam_Click(object sender, RoutedEventArgs e)
        {
            Frame_Navigated();
            btnNaam.Background = Brushes.Red;
            CvsZoeken.Visibility = Visibility.Visible;
        }

        private void btnFilterOpslaanZoeken_Click(object sender, RoutedEventArgs e)
        {
            Frame_Navigated();
            BtnbackgroundColor();
        }

        
    }
}
