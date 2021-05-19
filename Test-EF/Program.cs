﻿using Planten2021.Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Test_EF
{
    class Program
    {

        private static _Planten2021Context context = new _Planten2021Context();

        public string Simplify(string stringToSimplify)
        {
            string answer = stringToSimplify.Replace("\'", " ").Replace("\"", " ");
            answer = String.Concat(answer.Where(c => !Char.IsWhiteSpace(c)));
            return answer;
        }
        public static void Main(string[] args)
        {
            _readObjectProperties<Plant>(66);
        }

        private static void _readObjectProperties<T>(int plantid)
        {

            Type t = typeof(T);
            var objectTypeProperties = t.GetProperties();

            var objectToRead = context.Plant.SingleOrDefault(p => p.PlantId == plantid);

            foreach (var p in objectTypeProperties)
            {
                if (_CheckIfPropertyIsObject(p))
                {
                    _readPropertyesThatIsType(plantid, p);
                }
                else
                {
                    var propertyText = p.GetValue(objectToRead);
                    Console.WriteLine($"{p.Name}: {propertyText} ");
                }
            }
        }

        #region _readPropertysFunctions
        private static void _readPropertysAbiotiek<T>(int plantId)
        {
            var abitoiek = typeof(T);
            var objectTypeProperties = abitoiek.GetProperties();
            foreach (var p in objectTypeProperties)
            {
                var objectToRead = context.Abiotiek.SingleOrDefault(p => p.PlantId == plantId);
                var propertyText = p.GetValue(objectToRead);
                Console.WriteLine($"{p.Name}: {propertyText} ");
            }
        }

        private static void _readPropertysCommensalisme<T>(int plantId)
        {
            var type = typeof(T);
            var objectTypeProperties = type.GetProperties();
            foreach (var p in objectTypeProperties)
            {
                var objectToRead = context.Commensalisme.SingleOrDefault(p => p.PlantId == plantId);
                var propertyText = p.GetValue(objectToRead);
                Console.WriteLine($"{p.Name}: {propertyText} ");
            }
        }
        private static void _readPropertysBeheerMaand<T>(int plantId)
        {
            var type = typeof(T);
            var objectTypeProperties = type.GetProperties();
            foreach (var p in objectTypeProperties)
            {
                var objectToRead = context.BeheerMaand.SingleOrDefault(p => p.PlantId == plantId);
                var propertyText = p.GetValue(objectToRead);
                Console.WriteLine($"{p.Name}: {propertyText} ");
            }
        }
        private static void _readPropertysCommensalismeMulti<T>(int plantId)
        {
            var type = typeof(T);
            var objectTypeProperties = type.GetProperties();
            foreach (var p in objectTypeProperties)
            {
                var objectToRead = context.BeheerMaand.SingleOrDefault(p => p.PlantId == plantId);
                var propertyText = p.GetValue(objectToRead);
                Console.WriteLine($"{p.Name}: {propertyText} ");
            }
        }
        private static void _readPropertysAbiotiekMulti<T>(int plantId)
        {
            var type = typeof(T);
            var objectTypeProperties = type.GetProperties();
            foreach (var p in objectTypeProperties)
            {
                var objectToRead = context.AbiotiekMulti.SingleOrDefault(p => p.PlantId == plantId);
                var propertyText = p.GetValue(objectToRead);
                Console.WriteLine($"{p.Name}: {propertyText} ");
            }
        }
        private static void _readPropertysFenotype<T>(int plantId)
        {
            var type = typeof(T);
            var objectTypeProperties = type.GetProperties();
            foreach (var p in objectTypeProperties)
            {
                var objectToRead = context.Fenotype.SingleOrDefault(p => p.PlantId == plantId);
                var propertyText = p.GetValue(objectToRead);
                Console.WriteLine($"{p.Name}: {propertyText} ");
            }
        }
        private static void _readPropertysExtraEigenschap<T>(int plantId)
        {
            var type = typeof(T);
            var objectTypeProperties = type.GetProperties();
            foreach (var p in objectTypeProperties)
            {
                var objectToRead = context.ExtraEigenschap.SingleOrDefault(p => p.PlantId == plantId);
                var propertyText = p.GetValue(objectToRead);
                Console.WriteLine($"{p.Name}: {propertyText} ");
            }
        }


        #endregion

        private static void _readPropertyesThatIsType(int plantid, PropertyInfo specialProperty)
        {
            switch (specialProperty.Name)
            {
                case "Abiotiek":
                    Console.WriteLine("---->Abiotiek<----" + "\r\n");
                    _readPropertysAbiotiek<Abiotiek>(plantid);
                    break;
                case "Commensalisme":
                    Console.WriteLine("---->Commensalisme<----" + "\r\n");
                    //_readPropertysCommensalisme<Commensalisme>(plantid);
                    break;
                case "BeheerMaand":
                    Console.WriteLine("---->BeheerMaand<----" + "\r\n");
                    //_readPropertysBeheerMaand<BeheerMaand>(plantid);
                    break;
                case "CommensalismeMulti":
                    Console.WriteLine("---->CommensalismeMulti<----" + "\r\n");
                    //_readPropertysCommensalismeMulti<CommensalismeMulti>(plantid);
                    break;
                case "AbiotiekMulti":
                    Console.WriteLine("---->AbiotiekMulti<----" + "\r\n");
                    //_readPropertysAbiotiekMulti<CommensalismeMulti>(plantid);
                    break;
                case "Fenotype":
                    Console.WriteLine("---->Fenotype<----" + "\r\n");
                    //_readPropertysFenotype<Fenotype>(plantid);
                    break;
                case "Foto":
                    Console.WriteLine("---->Foto<----" + "\r\n");
                    break;
                case "UpdatePlant":
                    Console.WriteLine("---->UpdatePlant<----" + "\r\n");
                    break;
                case "ExtraEigenschap":
                    Console.WriteLine("---->ExtraEigenschap<----" + "\r\n");
                    _readPropertysExtraEigenschap<ExtraEigenschap>(plantid);
                    break;
                default:
                    Console.WriteLine("---->default<----" + "\r\n");
                    break;
            }
        }

        private static bool _CheckIfPropertyIsObject(PropertyInfo info)
        {
            bool result = info.Name == "Abiotiek" ||
                          info.Name == "Commensalisme" ||
                          info.Name == "BeheerMaand" ||
                          info.Name == "CommensalismeMulti" ||
                          info.Name == "AbiotiekMulti" ||
                          info.Name == "Fenotype" ||
                          info.Name == "Foto" ||
                          info.Name == "UpdatePlant" ||
                          info.Name == "ExtraEigenschap";

            return result;
        }

    }
}
