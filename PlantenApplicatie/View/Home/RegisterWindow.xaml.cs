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
using PlantenApplicatie.ViewModel;

namespace PlantenApplicatie.View.Home
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            DataContext = GalaSoft.MvvmLight.Ioc.SimpleIoc.Default.GetInstance<ViewModelRegister>();
            InitializeComponent();
        }
    }
}
