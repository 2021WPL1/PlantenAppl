using Planten2021.Data.Models;
using Planten2021.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Planten2021.Data
{
    public static class Search
    {

        // public static Planten2021Context context = new Planten2021Context();

                /* NARROW DOWN FUNCTIONS */


        //A function that looks if the given list of plants contains the given string in plant.type .
        //if this is the case the plant will stay in the list.
        //if this is not the case, the plant will be deleted out of the list.
        public static void narrowDownOnType(List<Plant> listPlants, string type)
        {
            foreach (Plant plant in listPlants.ToList())
            {
                if (plant.Type != null)
                {
                    if (plant.Type.Contains(type) != true)
                    {
                        listPlants.Remove(plant);
                    }
                }
            }
        }

        //A function that looks if the given list of plants contains the given string in plant.geslacht .
        //if this is the case the plant will stay in the list.
        //if this is not the case, the plant will be deleted out of the list.
        //public static void narrowDownOnGeslacht(List<Plant> listPlants, string geslacht)
        //{
        //    foreach (Plant plant in listPlants.ToList())
        //    {
        //        if (plant.Geslacht!=null)
        //        {
        //            if (plant.Geslacht.Contains(geslacht) != true)
        //            {
        //                listPlants.Remove(plant);
        //            }
        //        }
        //    }     
        //}//DONE

        //A function that looks if the given list of plants contains the given string in plant.Family .
        //if this is the case the plant will stay in the list.
        //if this is not the case, the plant will be deleted out of the list.
        //public static void narrowDownOnFamily(List<Plant> listPlants, string Familie)
        //{
        //    foreach (Plant plant in listPlants.ToList())
        //    {
        //        if (plant.Familie!=null)
        //        {
        //            if (plant.Familie.Contains(Familie) != true)
        //            {
        //                listPlants.Remove(plant);
        //            }
        //        }
        //    }
        //}//DONE

        //A function that looks if the given list of plants contains the given string in plant.soort .
        //if this is the case the plant will stay in the list.
        //if this is not the case, the plant will be deleted out of the list.
        //public static void narrowDownOnSoort(List<Plant> listPlants, string soort)
        //{
        //    foreach (Plant plant in listPlants.ToList())
        //    {
        //        if (plant.Soort!=null)
        //        {
        //            if (plant.Soort.Contains(soort) != true)
        //            {
        //                listPlants.Remove(plant);
        //            }
        //        }
        //    }
        //}

        //A function that looks if the given list of plants contains the given string in plant.naam .
        //if this is the case the plant will stay in the list.
        //if this is not the case, the plant will be deleted out of the list.
        //public static void narrowDownOnName(List<Plant> listPlants, string naam)
        //{
        //    foreach (Plant plant in listPlants.ToList())
        //    {
        //        if (plant.Fgsv!=null)
        //        {
        //            if (plant.Fgsv.Contains(naam) != true)
        //            {
        //                listPlants.Remove(plant);
        //            }
        //        }
        //    }
        //}

        ////A function that looks if the given list of plants contains the given string in plant.variant .
        ////if this is the case the plant will stay in the list.
        ////if this is not the case, the plant will be deleted out of the list.
        //public static void narrowDownOnVariant(List<Plant> listPlants, string variant)
        //{
        //    foreach (Plant plant in listPlants.ToList())
        //    {
        //        if (plant.Variant!=null)
        //        {
        //            if (plant.Variant.Contains(variant) != true)
        //            {
        //                listPlants.Remove(plant);
        //            }
        //        }
        //    }
        //}

        /* SEARCH ON PARAM FUNCTIONS */

        ////A function that returns a list of plants
        ////the returned list are all the plants that contain the given string in their geslacht
        //public static List<Plant> OnGeslacht(string geslacht)
        //{
        //    var listPlants = context.Plant.Where(p => p.Geslacht.Contains(geslacht)).ToList();
        //    return listPlants;
        //}

        ////A function that returns a list of plants
        ////the returned list are all the plants that contain the given string in their soort
        //public static List<Plant> OnSoort(string soort)
        //{
        //    var listPlants = context.Plant.Where(p => p.Soort.Contains(soort)).ToList();
        //    return listPlants;
        //}

        //A function that returns a list of plants
        //the returned list are all the plants that contain the given string in their latin name
        //public static List<Plant> OnName(string name)
        //{
        //    var listPlants = context.Plant.Where(p => p.Fgsv.Contains(name)).ToList();
        //    return listPlants;
        //}

        ////A function that returns a list of plants
        ////the returned list are al the plants that contain the given string in their variant
        //public static List<Plant> OnVariant(string variant)
        //{
        //    var listPlants = context.Plant.Where(p => p.Variant.Contains(variant)).ToList();
        //    return listPlants;
        //}

        ////A function that returns a list of plants
        ////the returned list are al the plants that contain the given string in their family
        //public static List<Plant> OnFamily(string family)
        //{
        //    var listPlants = context.Plant.Where(p => p.Familie.Contains(family)).ToList();
        //    return listPlants;
        //}

        /* HELP FUNCTIONS */

        ////get a list of all the plants.
        //public static List<Plant> getAllPlants()
        //{
        //    var plants = context.Plant.ToList();
        //    return plants;
        //}

        ////A function that takes a string, puts it to lowercase, 
        ////changes all the ' and " chars and replaces them by a space
        ////next it deletes al the spaces and returns the string.
        //public static string Simplify(string stringToSimplify)
        //{
        //    string answer = stringToSimplify.ToLower().Replace("\'", " ").Replace("\"", " ");
        //    answer = String.Concat(answer.Where(c => !Char.IsWhiteSpace(c)));
        //    return answer;
        //}
    }

}
