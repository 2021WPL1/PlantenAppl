﻿using System;
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
            BtnbackgroundColor();
        }

        private void Frame_Navigated()
        {
            CvsZoeken.Visibility = Visibility.Hidden;           
        }

        private void BtnbackgroundColor() 
        {
            btnZoeken.Background = Brushes.Transparent;
        }

        private void btnZoeken_Click(object sender, RoutedEventArgs e)
        {
            Frame_Navigated();
            btnZoeken.Background = Brushes.Red;
            CvsZoeken.Visibility = Visibility.Visible;
        }

        private void btnFilterOpslaanZoeken_Click(object sender, RoutedEventArgs e)
        {
            Frame_Navigated();
            BtnbackgroundColor();
        }
    }
}
