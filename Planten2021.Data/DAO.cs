using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Text;
using System.Linq;
//using Planten2021.Data.Models;
using Planten2021.Domain.Models;
using System.Reflection.Emit;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
/*comments kenny*/
//using System.Windows.Controls;

namespace Planten2021.Data
{
    public class DAO
    {
        //Robin: opzetten DAO, singleton pattern

        //1.een statische private instantie instatieren die enkel kan gelezen worden.
        //deze wordt altijd teruggegeven wanneer de Instance method wordt opgeroepen
        private static readonly DAO instance = new DAO();

        /*Niet noodzakelijk voor de singletonpattern waar wel voor de DAO*/
        private readonly _Planten2021Context context;

        //2. private contructor
        private DAO()
        {
            /*Niet noodzakelijk voor de singletonpattern waar wel voor de DAO*/
            this.context = new _Planten2021Context();
        }
        //3.publieke methode instance die altijd kan aangeroepen worden
        //door zijn statische eigenschappen kan hij altijd aangeroepen worden 
        //zonder er een instantie van te maken
        public static DAO Instance()
        {
            return instance;
        }
        /* 4.gebruik: var example = DAO.Instance();
}

         */


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
        ///Kenny
        ///
        //public IQueryable<Plant> GetPlantWithId(int id)
        //{
        //    var plant = context.Plant.Where(p => p.PlantId == id);
        //    return plant;
        //}
        public Plant GetPlantWithId(int id)
        {
            var plant = context.Plant.SingleOrDefault(p => p.PlantId == id);
            return plant;
        }

        //get a list of all the plants.
       

        public List<Plant> getAllPlants()
        {
            // kijken hoeveel er zijn geselecteerd

            var plants = context.Plant.ToList();
            return plants;
        }
        ///Owen
        public string GetImages(long id, string ImageCategorie)
        {
            var foto = context.Foto.Where(s => s.Eigenschap == ImageCategorie).SingleOrDefault(s => s.Plant == id);


            if (foto != null)
            {
                var location = foto;
                return location.UrlLocatie;
            }

            return null;
        }
        ///Robin
        #region Lists of all the plant properties with multiple values, used to display plant details

        //Get a list of all the Abiotiek types
        public List<Abiotiek> GetAllAbiotieks()
        {
            var abiotiek = context.Abiotiek.ToList();
            return abiotiek;
        }

        //Get a list of all the AbiotiekMulti types
        public List<AbiotiekMulti> GetAllAbiotieksMulti()
        {
            //List is unfiltered, a plantId can be present multiple times
            //The aditional filteren will take place in the ViewModel

            var abioMultiList = context.AbiotiekMulti.ToList();

            return abioMultiList;
        }
        //Get a list of all the Beheermaand types
        public List<BeheerMaand> GetBeheerMaanden()
        {
            var beheerMaanden = context.BeheerMaand.ToList();
            return beheerMaanden;
        }

        public List<Commensalisme> GetAllCommensalisme()
        {
            var commensalisme = context.Commensalisme.ToList();
            return commensalisme;
        }
        public List<CommensalismeMulti> GetAllCommensalismeMulti()
        {
            //List is unfiltered, a plantId can be present multiple times
            //The aditional filtering will take place in the ViewModel

            var commensalismeMulti = context.CommensalismeMulti.ToList();
            return commensalismeMulti;
        }
        public List<ExtraEigenschap> GetAllExtraEigenschap()
        {
            var extraEigenschap = context.ExtraEigenschap.ToList();
            return extraEigenschap;
        }

        public List<Fenotype> GetAllFenoTypes()
        {
            var fenoTypes = context.Fenotype
                .ToList();
            return fenoTypes;
        }
        public List<Foto> GetAllFoto()
        {
            var foto = context.Foto.ToList();
            return foto;
        }
        public List<UpdatePlant> GetAllUpdatePlant()
        {
            var updatePlant = context.UpdatePlant.ToList();
            return updatePlant;
        }



        #endregion

        ///Owen, Robin, Christophe
        #region Fill Tfgsv
        public IQueryable<TfgsvType> fillTfgsvType()
        {
            // request List of wanted type
            // distinct to prevrent more than one of each type
            // Here we use IQueryable<T>, it makes it easier for us to use our search queries and find the objects that we need.
            // This will also make it possible for us to use all the properties instead of only a selection of an object in our ViewModels.
            // Good way to interact with our datacontext
            var selection = context.TfgsvType.Distinct();
            return selection;
        }

        public IQueryable<TfgsvFamilie> fillTfgsvFamilie(int selectedItem)
        {
            // request List of wanted type
            // distinct to prevrent more than one of each type
            // The if else is to check if something is selected in the previous combobox. if its not he doesn't filter
            // Here we use IQueryable<T>, it makes it easier for us to use our search queries and find the objects that we need.
            // This will also make it possible for us to use all the properties instead of only a selection of an object in our ViewModels.
            // Good way to interact with our datacontext

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
            // request List of wanted type
            // distinct to prevrent more than one of each type
            // The if else is to check if something is selected in the previous combobox. if its not he doesn't filter
            // Here we use IQueryable<T>, it makes it easier for us to use our search queries and find the objects that we need.
            // This will also make it possible for us to use all the properties instead of only a selection of an object in our ViewModels.
            // Good way to interact with our datacontext
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
            // request List of wanted type
            // distinct to prevrent more than one of each type
            // The if else is to check if something is selected in the previous combobox. if its not he doesn't filter
            // Here we use IQueryable<T>, it makes it easier for us to use our search queries and find the objects that we need.
            // This will also make it possible for us to use all the properties instead of only a selection of an object in our ViewModels.
            // Good way to interact with our datacontext
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

        public IQueryable<TfgsvVariant> fillTfgsvVariant()
        {
            // request List of wanted type
            // distinct to prevrent more than one of each type
            // The if else is to check if something is selected in the previous combobox. if its not he doesn't filter
            // Here we use IQueryable<T>, it makes it easier for us to use our search queries and find the objects that we need.
            // This will also make it possible for us to use all the properties instead of only a selection of an object in our ViewModels.
            // Good way to interact with our datacontext

            var selection = context.TfgsvVariant.Distinct().OrderBy(s => s.Variantnaam);
            return selection;

        }
        public IQueryable<Fenotype> fillFenoTypeRatioBloeiBlad()
        {
            // this is NOT part of the cascade function and wil not be added as it is not needed 
            // request List of wanted type
            // distinct to prevrent more than one of each type
            // The if else is to check if something is selected in the previous combobox. if its not he doesn't filter.
            // Here we use IQueryable<T>, it makes it easier for us to use our search queries and find the objects that we need.
            // This will also make it possible for us to use all the properties instead of only a selection of an object in our ViewModels.
            // Good way to interact with our datacontext

            var selection = context.Fenotype.Distinct().OrderBy(s => s.RatioBloeiBlad);
            return selection;

        }


        #endregion

        #region FilterFromPlant
        ///Owen: op basis van basiscode Kenny, Christophe
        #region FilterFenoTypeFromPlant 

        public IQueryable<Fenotype> filterFenoTypeFromPlant(int selectedItem)
        {

            var selection = context.Fenotype.Distinct().Where(s => s.PlantId == selectedItem);
            return selection;
        }

        public IQueryable<FenotypeMulti> FilterFenotypeMultiFromPlant(int selectedItem)
        {

            var selection = context.FenotypeMulti.Distinct().Where(s => s.PlantId == selectedItem);
            return selection;
        }
        #endregion

        #region FilterAbiotiekFromPlant
        public IQueryable<Abiotiek> filterAbiotiekFromPlant(int selectedItem)
        {

            var selection = context.Abiotiek.Distinct().Where(s => s.PlantId == selectedItem);
            return selection;
        }

        public IQueryable<AbiotiekMulti> filterAbiotiekMultiFromPlant(int selectedItem)
        {

            var selection = context.AbiotiekMulti.Distinct().Where(s => s.PlantId == selectedItem);
            return selection;
        }


        #endregion

        #region FilterBeheerMaandFromPlant
        public IQueryable<BeheerMaand> FilterBeheerMaandFromPlant(int selectedItem)
        {

            var selection = context.BeheerMaand.Distinct().Where(s => s.PlantId == selectedItem);
            return selection;
        }


        #endregion

        #region FilterCommensalismeFromPlant
        public IQueryable<Commensalisme> FilterCommensalismeFromPlant(int selectedItem)
        {

            var selection = context.Commensalisme.Distinct().Where(s => s.PlantId == selectedItem);
            return selection;
        }

        public IQueryable<CommensalismeMulti> FilterCommensalismeMulti(int selectedItem)
        {

            var selection = context.CommensalismeMulti.Distinct().Where(s => s.PlantId == selectedItem);
            return selection;
        }


        #endregion

        #region FilterExtraEigenschapFromPlant
        public IQueryable<ExtraEigenschap> FilterExtraEigenschapFromPlant(int selectedItem)
        {

            var selection = context.ExtraEigenschap.Distinct().Where(s => s.PlantId == selectedItem);
            return selection;
        }


        #endregion

        #endregion
        //Christophe: Op basis van basiscode Owen
        #region Fill Combobox Pollenwaarde en Nectarwaarde

        public List<ExtraPollenwaarde> FillExtraPollenwaardes()
        {
            var selection = context.ExtraPollenwaarde.ToList();
            return selection;
        }

        public List<ExtraNectarwaarde> FillExtraNectarwaardes()
        {
            var selection = context.ExtraNectarwaarde.ToList();
            return selection;
        }

        #endregion

        public List<BeheerMaand> FillBeheerdaad()
        {
            var selection = context.BeheerMaand.ToList();
            return selection;
        }


        //written by kenny
        public Gebruiker GetGebruikerWithEmail(string userEmail)
        {
            var gebruiker = context.Gebruiker.SingleOrDefault(g => g.Emailadres == userEmail);
            return gebruiker;

        }

        //written by kenny
        public void RegisterUser(string vivesNr, string firstName, string lastName, string emailadres, string password, string rol)
        {
            var passwordBytes = Encoding.ASCII.GetBytes(password);
            var md5Hasher = new MD5CryptoServiceProvider();
            var passwordHashed = md5Hasher.ComputeHash(passwordBytes);

            var gebruiker = new Gebruiker()
            {
                Vivesnr = vivesNr,
                Voornaam = firstName,
                Achternaam = lastName,
                Emailadres = emailadres,
                Rol = rol,
                HashPaswoord = passwordHashed
            };
            context.Gebruiker.Add(gebruiker);
            context.SaveChanges();
        }
        //written by kenny
        public List<Gebruiker> getAllGebruikers()
        {
            var gebruiker = context.Gebruiker.ToList();
            return gebruiker;
        }

        //public List<Gebruiker> getAllOudstudenten()
        //{
        //    var oudstudent = context.Gebruiker.ToList();
        //    return oudstudent;
        //}
        //written by kenny
        public bool CheckIfEmailAlreadyExists(string email)
        {
            bool result = false;
            if (GetGebruikerWithEmail(email) == null)
            {
                result = true;
            }

            return result;
        }

        public List<FenotypeMulti> GetFenotypeMultis(long plantId)
        {
            //var fenoTypeList = context.FenotypeMulti.ToList();
            List<FenotypeMulti> fenoTypeList = context.FenotypeMulti.Where(F => F.PlantId == plantId).ToList();
            return fenoTypeList;
        }
        //public FenotypeMulti GetFenoMultiByPlantId(long plantId)
        //{
        //    var neededFenoMulti = context.FenotypeMulti.SingleOrDefault(p => p.PlantId == plantId);

        //    return neededFenoMulti;
        //}

        public List<FenoBloeiwijze> GetFenoBloeiwijze()
        {
            var fenoBloeiwijze = context.FenoBloeiwijze.ToList();

            return fenoBloeiwijze;
        }

        public List<FenoBladvorm> GetFenoBladvormen()
        {
            var fenoBladvormen = context.FenoBladvorm.ToList();

            return fenoBladvormen;
        }

        public List<FenoLevensvorm> GetFenoLevensvormen()
        {
            var fenoLevensvormen = context.FenoLevensvorm.ToList();

            return fenoLevensvormen;
        }
    }


}
