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
            if (txtNaam.Text != string.Empty)
            {
                lstResultSearch.Items.Add("ZOEKRESULTATEN WAAR " + txtNaam.Text.ToUpper() + " IN VOORKOMT IN DE NAAM." );
                var list = Search.OnName(txtNaam.Text.ToString());
                printInfo(list);
            }

            if (txtFamilie.Text != string.Empty)
            {
                lstResultSearch.Items.Add("ZOEKRESULTATEN WAAR DE PLANT AAN DE FAMILLIE " + txtFamilie.Text.ToUpper() + " TOEBEHOORD.");
                var list = Search.OnFamily(txtFamilie.Text.ToString());
                printInfo(list);
            }

            if (txtCultivar.Text != string.Empty)
            {
                lstResultSearch.Items.Add("ZOEKRESULTATEN WAAR DE PLANT AAN DE VARIANT " + txtCultivar.Text.ToUpper() + " TOEBEHOORD.");
                var list = Search.OnVariant(txtCultivar.Text.ToString());
                printInfo(list);
            }

            if (txtSoort.Text != string.Empty)
            {
                lstResultSearch.Items.Add("ZOEKRESULTATEN WAAR DE PLANT AAN DE SOORT " + txtSoort.Text.ToUpper() + " TOEBEHOORD.");
                var list = Search.OnVariant(txtSoort.Text.ToString());
                printInfo(list);
            }

            if (txtGeslacht.Text != string.Empty)
            {
                lstResultSearch.Items.Add("ZOEKRESULTATEN WAAR DE PLANT AAN HET GESLACHT " + txtGeslacht.Text.ToUpper() + " TOEBEHOORD.");
                var list = Search.OnVariant(txtGeslacht.Text.ToString());
                printInfo(list);
            }

        }


        //this function will print the result in the listbox
        public void printInfo(List<Plant> listPlants)
        {

            foreach (Plant plant in listPlants)
            {
            lstResultSearch.Items.Add
                                 ("Plantnaam = " + plant.Fgsv + Environment.NewLine
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
