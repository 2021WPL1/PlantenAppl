using Planten2021.Data;
using Planten2021.Domain.Models;
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

namespace Join_test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DAO dao;
        public MainWindow()
        {
            InitializeComponent();
            dao = DAO.Instance();
        }

        private void List1() 
        {
               
          

            lbxLijst1.Items.Clear();
            //generates a list with all plants.
            var listPlants = dao.TestContext();






        }

        private void btnList1_Click(object sender, RoutedEventArgs e)
        {
            List1();
        }

        private void btnList2_Click(object sender, RoutedEventArgs e)
        {
            List2();
        }
       
    }
}
