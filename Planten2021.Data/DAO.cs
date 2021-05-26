using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
//using Planten2021.Data.Models;
using Planten2021.Domain.Models;
using System.Reflection.Emit;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

//using System.Windows.Controls;

namespace Planten2021.Data
{
    public class DAO
    {
        private static readonly DAO instance = new DAO();
        private readonly _Planten2021Context context;

        public static DAO Instance()
        {
            return instance;
        }
        //private contructor
        private DAO()
        {
            this.context = new _Planten2021Context();
        }

        //search functions

        /* NARROW DOWN FUNCTIONS */

        #region Kenny's first search

        //DIT IS KENNY ZIJN CODE KAN ZIJN DAT WE DIT NOG GEBRUIKEN IN HET VOLGEND KWARTAAL.

        //A function that looks if the given list of plants contains the given string in plant.type .
        //if this is the case the plant will stay in the list.
        //if this is not the case, the plant will be deleted out of the list.
        //public void narrowDownOnType(List<Plant> listPlants, string type)
        //{
        //    foreach (Plant plant in listPlants.ToList())
        //    {           
        //        if (plant.Type != null)
        //        {
        //            var simplifyString = Simplify(plant.Geslacht.ToString());
        //            if (simplifyString.Contains(Simplify(type)) != true)
        //            {
        //                listPlants.Remove(plant);
        //            }
        //        }
        //    }
        //}

        ////A function that looks if the given list of plants contains the given string in plant.geslacht .
        ////if this is the case the plant will stay in the list.
        ////if this is not the case, the plant will be deleted out of the list.

        //public void narrowDownOnGeslacht(List<Plant> listPlants, string geslacht)
        //{
        //    foreach (Plant plant in listPlants.ToList())
        //    {
        //        if (plant.Geslacht != null)
        //        {
        //            var simplifyString = Simplify(plant.Geslacht.ToString());
        //            if (simplifyString.Contains(Simplify(geslacht)) != true)
        //            {
        //                listPlants.Remove(plant);
        //            }
        //        }
        //    }
        //}
        ////A function that looks if the given list of plants contains the given string in plant.Family .
        ////if this is the case the plant will stay in the list.
        ////if this is not the case, the plant will be deleted out of the list.
        //public void narrowDownOnFamily(List<Plant> listPlants, string Familie)
        //{
        //    foreach (Plant plant in listPlants.ToList())
        //    {
        //        if (plant.Familie != null)
        //        {
        //            var simplifyString = Simplify(plant.Familie.ToString());
        //            if (simplifyString.Contains(Simplify(Familie)) != true)
        //            {
        //                listPlants.Remove(plant);
        //            }
        //        }
        //    }
        //}
        ////A function that looks if the given list of plants contains the given string in plant.soort .
        ////if this is the case the plant will stay in the list.
        ////if this is not the case, the plant will be deleted out of the list.
        //public void narrowDownOnSoort(List<Plant> listPlants, string soort)
        //{
        //    foreach (Plant plant in listPlants.ToList())
        //    {
        //        if (plant.Soort != null)
        //        {
        //            var simplifyString = Simplify(plant.Soort.ToString());
        //            if (simplifyString.Contains(Simplify(soort)) != true)
        //            {
        //                listPlants.Remove(plant);
        //            }
        //        }
        //    }
        //}
        ////A function that looks if the given list of plants contains the given string in plant.naam .
        ////if this is the case the plant will stay in the list.
        ////if this is not the case, the plant will be deleted out of the list.
        //public void narrowDownOnName(List<Plant> listPlants, string naam)
        //{
        //    foreach (Plant plant in listPlants.ToList())
        //    {
        //        if (plant.Fgsv != null)
        //        {
        //            var simplifyString = Simplify(plant.Fgsv.ToString());
        //            if (simplifyString.Contains(Simplify(naam)) != true)
        //            {
        //                listPlants.Remove(plant);
        //            }
        //        }
        //    }
        //}
        ////A function that looks if the given list of plants contains the given string in plant.variant .
        ////if this is the case the plant will stay in the list.
        ////if this is not the case, the plant will be deleted out of the list.
        //public void narrowDownOnVariant(List<Plant> listPlants, string variant)
        //{
        //    foreach (Plant plant in listPlants.ToList())
        //    {
        //        if (plant.Variant != null)
        //        {
        //            var simplifyString = Simplify(plant.Variant.ToString());
        //            if (simplifyString.Contains(Simplify(variant)) != true)
        //            {
        //                listPlants.Remove(plant);
        //            }
        //        }
        //    }
        //}
        //A function that returns a list of plants
        //the returned list are all the plants that contain the given string in their geslacht



        //Robin: removed "static", couldn't reach context
        //public List<Plant> OnGeslacht(string geslacht)
        //{
        //    var listPlants = context.Plant.Where(p => p.Geslacht.Contains(geslacht)).ToList();
        //    return listPlants;
        //}
        ////A function that returns a list of plants
        ////the returned list are all the plants that contain the given string in their latin name
        //public List<Plant> OnName(string name)
        //{
        //    var listPlants = context.Plant.Where(p => p.Fgsv.Contains(name)).ToList();
        //    return listPlants;
        //}
        //public List<Plant> OnVariant(string variant)
        //{
        //    var listPlants = context.Plant.Where(p => p.Variant.Contains(variant)).ToList();
        //    return listPlants;
        //}
        ////A function that returns a list of plants
        ////the returned list are al the plants that contain the given string in their family
        //public List<Plant> OnFamily(string family)
        //{
        //    var listPlants = context.Plant.Where(p => p.Familie.Contains(family)).ToList();
        //    return listPlants;
        //}
        #endregion
        /* HELP FUNCTIONS */

        //get a list of all the plants.
        public List<Plant> getAllPlants()
        {
            // kijken hoeveel er zijn geselecteerd

            var plants = context.Plant.ToList();
            return plants;
        }

        //A function that takes a string, puts it to lowercase, 
        //changes all the ' and " chars and replaces them by a space
        //next it deletes al the spaces and returns the string.
        public string Simplify(string stringToSimplify)
        {
            string answer = stringToSimplify.Replace("\'", " ").Replace("\"", " ");
            answer = String.Concat(answer.Where(c => !Char.IsWhiteSpace(c)));
            return answer;
        }

        //public IQueryable<T> DuplicationCheck<T>(IQueryable<T> selection)
        //{
        //    //This is to check for duplication that got through the distinct
        //    //Initialize IQueryable
        //    IQueryable<T> duplicationcheck= Enumerable.Empty<T>().AsQueryable();

        //    foreach (var item in selection)
        //    {
        //        if (!duplicationcheck.Contains(item))
        //        {
        //            duplicationcheck.Append(item);
        //        }
        //    }
        //    return duplicationcheck;
        //}
        public Dictionary<long, string> DuplicationCheck(Dictionary<long, string> selection)
        {
            // this is to check for duplication that got through the distinct

            Dictionary<long, string> Duplicationcheck = new Dictionary<long, string>();
            foreach (var item in selection)
            {
                if (!Duplicationcheck.ContainsValue(item.Value))
                {
                    Duplicationcheck.Add(item.Key, item.Value);
                }
            }

            return Duplicationcheck;
        }

        /// <summary>
        ///                            FILL COMBOBOX
        ///            Deze functies zijn voor het cascade systeem.
        /// </summary>
        /// <returns></returns>


        public IQueryable<TfgsvType> fillTfgsvType()
        {
            // lijst type opvragen.
            // distinct om meerdere van de zelfde tegen te gaan.
            // Here we use IQueryable<T>, it makes it easier for us to use our search queries and find the objects that we need.
            // This will also make it possible for us to use all the properties instead of only a selection of an object in our ViewModels.
            // Good way to interact with our datacontext
            var selection = context.TfgsvType.Distinct();
            return selection;
        }

        public IQueryable<TfgsvFamilie> fillTfgsvFamilie(int selectedItem)
        {
            // lijst type opvragen.
            // distinct om meerdere van de zelfde tegen te gaan.
            // 
            // De if else is er voor bij opstarten de comboboxen te vullen en geen error te krijgen omdat er niet geselecteerd is. en gebruikt dan gewoon geen where.

            if (selectedItem > 0)
            {
                var selection = context.TfgsvFamilie.Distinct().OrderBy(s => s.Familienaam).Where(s => s.TypeTypeid == selectedItem);
                return selection;

            }
            else
            {
                var selection = context.TfgsvFamilie.Distinct().OrderBy(s => s.Familienaam);
                return selection;
            }

        }
        public IQueryable<TfgsvGeslacht> fillTfgsvGeslacht(int selectedItem)
        {
            // lijst type opvragen.
            // distinct om meerdere van de zelfde tegen te gaan.
            // 
            // De if else is er voor bij opstarten de comboboxen te vullen en geen error te krijgen omdat er niet geselecteerd is. en gebruikt dan gewoon geen where.
            if (selectedItem > 0)
            {
                var selection = context.TfgsvGeslacht.Distinct().OrderBy(s => s.Geslachtnaam)
                    .Where(s => s.FamilieFamileId == selectedItem);
                return selection;
            }
            else
            {
                var selection = context.TfgsvGeslacht.Distinct().OrderBy(s => s.Geslachtnaam);
                return selection;
            }

        }
        public IQueryable<TfgsvSoort> fillTfgsvSoort(int selectedItem)
        {
            // lijst type opvragen.
            // distinct om meerdere van de zelfde tegen te gaan.
            // 
            // De if else is er voor bij opstarten de comboboxen te vullen en geen error te krijgen omdat er niet geselecteerd is. en gebruikt dan gewoon geen where.
            if (selectedItem > 0)
            {
                var selection = context.TfgsvSoort.Where(s => s.GeslachtGeslachtId == selectedItem).OrderBy(s => s.Soortnaam).Distinct();
                return selection;
            }
            else
            {
                var selection = context.TfgsvSoort.Distinct().OrderBy(s => s.Soortnaam);
                return selection;
            }

        }

        public IQueryable<TfgsvVariant> fillTfgsvVariant(int selectedItem)
        {
            // lijst type opvragen.
            // distinct om meerdere van de zelfde tegen te gaan.
            // 
            // De if else is er voor bij opstarten de comboboxen te vullen en geen error te krijgen omdat er niet geselecteerd is. en gebruikt dan gewoon geen where.
            if (selectedItem > 0)
            {
                var selection = context.TfgsvVariant.Distinct().OrderBy(s => s.Variantnaam).Where(s => s.SoortSoortid == selectedItem);
                return selection;
            }
            else
            {
                var selection = context.TfgsvVariant.Distinct().OrderBy(s => s.Variantnaam);
                return selection;
            }
        }
        public IQueryable<Fenotype> fillFenoTypeRatioBloeiBlad()
        {
            // lijst type opvragen.
            // distinct om meerdere van de zelfde tegen te gaan.
            // 
            // De if else is er voor bij opstarten de comboboxen te vullen en geen error te krijgen omdat er niet geselecteerd is. en gebruikt dan gewoon geen where.

            var selection = context.Fenotype.Distinct().OrderBy(s => s.RatioBloeiBlad);
            return selection;

        }

        public List<Plant> detailsAanvullen(long ID)
        {
            var plants = context.Plant
                .Include(s => s.Abiotiek)
                .Include(s => s.AbiotiekMulti)
                .Include(s => s.BeheerMaand)
                .Include(s => s.Commensalisme)
                .Include(s => s.CommensalismeMulti)
                .Include(s => s.ExtraEigenschap)
                .Include(s => s.Fenotype)
                .Include(s => s.UpdatePlant)
                .Include(s => s.Foto)

                .Where(s => s.PlantId == ID)
                .ToList();
            return plants;
        }

        public Gebruiker GetGebruikerWithEmail(string userEmail)
        {
            Gebruiker gebruiker;
            gebruiker = context.Gebruiker.SingleOrDefault(g => g.Emailadres == userEmail);
            return gebruiker;

        }

        public void RegisterUser(string vivesNr, string firstName, string lastName, string rol, string emailadres, string password)
        {
            var passwordBytes = Encoding.ASCII.GetBytes(password);
            var md5Hasher = new MD5CryptoServiceProvider();
            var passwordHashed = md5Hasher.ComputeHash(passwordBytes);

            var gebruiker = new Gebruiker()
            {
                Vivesnr = vivesNr,
                Voornaam = firstName,
                Achternaam = lastName,
                Rol = rol,
                Emailadres = emailadres,
                HashPaswoord = passwordHashed
            };
            context.Gebruiker.Add(gebruiker);
            context.SaveChanges();
        }

    }
}
