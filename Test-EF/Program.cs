using Planten2021.Domain.Models;
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
            _readObjectProperties<Plant>(45);
        }

        private static void _readObjectProperties<T>(int Plantid)
        {

            Type t = typeof(T);
            var objectTypeProperties = t.GetProperties();

            var objectToRead = context.Plant.SingleOrDefault(p => p.PlantId == Plantid);

            foreach (var p in objectTypeProperties)
            {
                if (_CheckIfProperyIsObject(p))
                {
                    Console.WriteLine(p.Name);
                  Console.WriteLine("Here we should read the propery seperatly but it does not work yet.");
                }
                else
                {
                    var propertyText = p.GetValue(objectToRead);
                    Console.WriteLine($"{p.Name}: {propertyText} ");
                }
                
            }
        }

        private static void _readObjectPropertiesInside(PropertyInfo type)
        {
            Type t = (Type)type.PropertyType;
            var objectTypeProperties = t.GetProperties();
            foreach (var p in objectTypeProperties)
            {
                var propertyText = p.GetValue(type);
                Console.WriteLine($"{p.Name}: {propertyText} " + "\r\n");
            }
        }

        private static bool _CheckIfProperyIsObject(PropertyInfo info)
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
