using Planten2021.Data;
using PlantenMVVM.ViewModels;
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

namespace PlantenMVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class BasicWindow : Window
    {
        private MainViewModel viewModel;


        public BasicWindow()
        {
          
            InitializeComponent();
            viewModel = new MainViewModel();
            DataContext = viewModel;

            //methods om de comboboxen te vullen met info uit de databank
            //type
            viewModel.fillTypeInComboBox();
            //cascade type->family
            viewModel.fillComboBoxFamilie();
        }


    }
}
