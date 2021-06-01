using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PlantenApplicatie.Viewmodel;

namespace PlantenApplicatie.View.Home
{/*written by kenny*/
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            DataContext = GalaSoft.MvvmLight.Ioc.SimpleIoc.Default.GetInstance<ViewModelLogin>();
            InitializeComponent();
        }
    }
}
