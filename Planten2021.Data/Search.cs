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
        
        public static Planten2021Context context = new Planten2021Context();


        //A function that takes a string, puts it to lowercase, 
        //changes all the ' and " chars and replaces them by a space
        //next it deletes al the spaces and returns the string.
        public static string Simplify(string stringToSimplify)
        {
            string answer = stringToSimplify.ToLower().Replace("\'", " ").Replace("\"", " ");
            answer = String.Concat(answer.Where(c => !Char.IsWhiteSpace(c)));
            return answer;
        }

        //A function that returns a list of plants
        //the returned list are all the plants that contain the given string in their geslacht
        public static List<Plant> OnGeslacht(string geslacht)
        {
            var listPlants = context.Plant.Where(p => p.Geslacht.Contains(geslacht)).ToList();
            return listPlants;
        }

        //A function that returns a list of plants
        //the returned list are all the plants that contain the given string in their soort
        public static List<Plant> OnSoort(string soort)
        {
            var listPlants = context.Plant.Where(p => p.Soort.Contains(soort)).ToList();
            return listPlants;
        }

        //A function that returns a list of plants
        //the returned list are all the plants that contain the given string in their latin name
        public static List<Plant> OnName(string name)
        {
            var listPlants = context.Plant.Where(p => p.Fgsv.Contains(name)).ToList();
            return listPlants;
        }

        //A function that returns a list of plants
        //the returned list are al the plants that contain the given string in their variant
        public static List<Plant> OnVariant(string variant)
        {
            var listPlants = context.Plant.Where(p => p.Variant.Contains(variant)).ToList();
            return listPlants;
        }

        //A function that returns a list of plants
        //the returned list are al the plants that contain the given string in their family
        public static List<Plant> OnFamily(string family)
        {
            var listPlants = context.Plant.Where(p => p.Familie.Contains(family)).ToList();
            return listPlants;
        }

        //This function prints all the info of the plants in the given list.


        //get a list of all the plants.
        public static List<Plant> getAllPlants()
        {
            var plants = context.Plant.ToList();
            return plants;
        }
    }

}
