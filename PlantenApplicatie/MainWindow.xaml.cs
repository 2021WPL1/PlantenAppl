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

        private void btnZoeken_Click(object sender, RoutedEventArgs e)
        {
            lstResultSearch.Items.Clear();
            //generates a list with all plants.
            var listPlants = Search.getAllPlants();

            //generate a string to show witch criteria we searched on
            string criteria = "Dit is een gefilterde lijst van planten op onderstaande zoekcriteria. : " + Environment.NewLine + Environment.NewLine;

            if (txtNaam.Text != string.Empty)
            {
                criteria += " naam : " + txtNaam.Text.ToString() + Environment.NewLine;
                Search.narrowDownOnName(listPlants, txtNaam.Text.ToString());
                //lstResultSearch.Items.Add("ZOEKRESULTATEN WAAR " + txtNaam.Text.ToUpper() + " IN VOORKOMT IN DE NAAM." );
                //var list = Search.OnName(txtNaam.Text.ToString());
                //printInfo(list);
            }

            if (txtFamilie.Text != string.Empty)
            {
                criteria += " familie : " + txtFamilie.Text.ToString() + Environment.NewLine;
                Search.narrowDownOnFamily(listPlants, txtFamilie.Text.ToString());
                //lstResultSearch.Items.Add("ZOEKRESULTATEN WAAR DE PLANT AAN DE FAMILLIE " + txtFamilie.Text.ToUpper() + " TOEBEHOORD.");
                //var list = Search.OnFamily(txtFamilie.Text.ToString());
                //printInfo(list);
            }

            if (txtCultivar.Text != string.Empty)
            {
                criteria += " cultivar : " + txtCultivar.Text.ToString() + Environment.NewLine;
                Search.narrowDownOnVariant(listPlants, txtCultivar.Text.ToString());
                //lstResultSearch.Items.Add("ZOEKRESULTATEN WAAR DE PLANT AAN DE VARIANT " + txtCultivar.Text.ToUpper() + " TOEBEHOORD.");
                //var list = Search.OnVariant(txtCultivar.Text.ToString());
                //printInfo(list);
            }

            if (txtSoort.Text != string.Empty)
            {
                criteria += " soort : " + txtSoort.Text.ToString() + Environment.NewLine;
                Search.narrowDownOnSoort(listPlants, txtSoort.Text.ToString());
                //lstResultSearch.Items.Add("ZOEKRESULTATEN WAAR DE PLANT AAN DE SOORT " + txtSoort.Text.ToUpper() + " TOEBEHOORD.");
                //var list = Search.OnVariant(txtSoort.Text.ToString());
                //printInfo(list);
            }

            if (txtGeslacht.Text != string.Empty)
            {
                criteria += " geslacht : " + txtGeslacht.Text.ToString() + Environment.NewLine;
                Search.narrowDownOnGeslacht(listPlants, txtGeslacht.Text.ToString());
                //lstResultSearch.Items.Add("ZOEKRESULTATEN WAAR DE PLANT AAN HET GESLACHT " + txtGeslacht.Text.ToUpper() + " TOEBEHOORD.");
                //var list = Search.OnVariant(txtGeslacht.Text.ToString());
                //printInfo(list);
            }
            printInfo(listPlants);
            lblCriteria.Content = string.Empty;
            lblCriteria.Content += criteria.ToString();

        }


        //this function will print the result in the listbox
        public void printInfo(List<Plant> listPlants)
        {

            foreach (Plant plant in listPlants)
            {
             lstResultSearch.Items.Add
                                 ( "Plantnaam = " + plant.Fgsv + Environment.NewLine
                                 + "type = " + plant.Type + Environment.NewLine
                                 + "famillie = " + plant.Familie + Environment.NewLine
                                 + "geslacht = " + plant.Geslacht + Environment.NewLine
                                 + "soort = " + plant.Soort + Environment.NewLine
                                 + "variant = " + plant.Variant + Environment.NewLine
                                 + "nederlandse naam = " + plant.NederlandsNaam + Environment.NewLine
                                 + "plantendichtheid = Min: " + plant.PlantdichteidMin.ToString() + " Max: " + plant.PlantdichtheidMax.ToString()
                                 + Environment.NewLine
                                 );

            }
        }

    }
}
