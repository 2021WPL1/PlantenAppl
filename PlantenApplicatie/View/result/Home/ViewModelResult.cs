using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Planten2021.Data;
using PlantenApplicatie.View.UserControls;
using PlantenApplicatie.ViewModel;

namespace PlantenApplicatie.Viewmodel
{
    public class ViewModelResult : ViewModelBase
    {
        //private DAO _dao;

        //public ViewModelResult()
        //{
        //    this._dao = DAO.Instance();
        //}

        //private void BtnZoeken_Click(object sender, RoutedEventArgs e)
        //{
        //    Frame_Navigated();
        //    BtnbackgroundColor();
        //    lstResultSearch.Visibility = Visibility.Visible;
        //    lstDetails.Visibility = Visibility.Visible;

        //    // de lijst planten op vragen
        //    var listPlants = dao.getAllPlants();

        //    lstResultSearch.Items.Refresh();


        //    // kijken over er iets in de combobox is aan geduid
        //    if (cmbType.SelectedValue != null)
        //    {
        //        // alle onnodige tekens er uit halen 
        //        var ControlString = Simplify(cmbType.SelectedItem.ToString(), cmbType.SelectedValue.ToString());
        //        // alle items in list plant overlopen
        //        foreach (var item in listPlants.ToList())
        //        {
        //            //als het zoekwoord er niet in voor komt verwijderen.
        //            if (item.Type.Contains(ControlString) == false)
        //            {
        //                listPlants.Remove(item);
        //            }
        //        }
        //    } // Zie commentaar lijn 91

        //    if (cmbFamilie.SelectedValue != null)
        //    {
        //        var ControlString = Simplify(cmbFamilie.SelectedItem.ToString(), cmbFamilie.SelectedValue.ToString());

        //        foreach (var item in listPlants.ToList())
        //        {

        //            if (item.Familie.Contains(ControlString) == false)
        //            {
        //                listPlants.Remove(item);
        //            }
        //        }
        //    } // Zie commentaar lijn 91

        //    if (cmbGeslacht.SelectedValue != null)
        //    {
        //        var ControlString = Simplify(cmbGeslacht.SelectedItem.ToString(), cmbGeslacht.SelectedValue.ToString());

        //        foreach (var item in listPlants.ToList())
        //        {

        //            if (item.Geslacht.Contains(ControlString) == false)
        //            {
        //                listPlants.Remove(item);
        //            }
        //        }
        //    } // Zie commentaar lijn 91

        //    if (cmbSoort.SelectedValue != null)
        //    {
        //        var ControlString = Simplify(cmbSoort.SelectedItem.ToString(), cmbSoort.SelectedValue.ToString());

        //        foreach (var item in listPlants.ToList())
        //        {

        //            if (item.Soort.Contains(ControlString) == false)
        //            {
        //                listPlants.Remove(item);
        //            }
        //        }
        //    } // Zie commentaar lijn 91

        //    if (cmbVariant.SelectedValue != null)
        //    {
        //        var ControlString = Simplify(cmbVariant.SelectedItem.ToString(), cmbVariant.SelectedValue.ToString());

        //        foreach (var item in listPlants.ToList())
        //        {

        //            if (item.Variant != null)
        //            {

        //                if (Simplify(item.Variant, "0") != ControlString)
        //                {

        //                    listPlants.Remove(item);
        //                }
        //            }
        //            else if (item.Variant == null)
        //            {
        //                listPlants.Remove(item);
        //            }

        //        }
        //    }

        //    if (txtNederlandseNaam.Text != "")
        //    {
        //        foreach (var item in listPlants.ToList())
        //        {

        //            if (item.NederlandsNaam != null)
        //            {
        //                if (item.NederlandsNaam.Contains(txtNederlandseNaam.Text) == false)
        //                {
        //                    listPlants.Remove(item);
        //                }

        //            }
        //            else if (item.NederlandsNaam == null)
        //            {
        //                listPlants.Remove(item);
        //            }

        //        }
        //    }

        //    if (cmbRatioBladBloei.SelectedValue != null)
        //    {
        //        var ControlString = Simplify(cmbRatioBladBloei.SelectedItem.ToString(),
        //            cmbRatioBladBloei.SelectedValue.ToString());

        //        foreach (var item in listPlants.ToList())
        //        {
        //            if (item.Fenotype.Count != 0)
        //            {
        //                foreach (var itemFenotype in item.Fenotype)
        //                {

        //                    if (itemFenotype.RatioBloeiBlad != null || itemFenotype.RatioBloeiBlad != String.Empty)
        //                    {

        //                        if (Simplify(itemFenotype.RatioBloeiBlad, "0") != ControlString)
        //                        {

        //                            //listPlants.Remove(item);
        //                            listPlants.Remove(item);
        //                        }
        //                    }
        //                    else
        //                    {
        //                        listPlants.Remove(item);
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                listPlants.Remove(item);
        //            }

        //        }

        //    }

        //}
    }
}
