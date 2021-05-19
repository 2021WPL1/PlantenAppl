using Planten2021.Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;

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
            _readObjectProperties<Plant>(10);

        }

        private static void _readObjectProperties<T>(int Plantid)
        {

            Type t = typeof(T);
            var objectTypeProperties = t.GetProperties();

            var objectToRead = context.Plant.SingleOrDefault(p => p.PlantId == Plantid);

            //foreach (var p in objectTypeProperties)
            //{
            //    if (_checkIfProperyIsObject(p))
            //    {
            //        Console.WriteLine("this is a type itself and should be read out separately.");
            //    }
            //    else
            //    {
            //        var propertyText = p.GetValue(objectToRead);
            //        Console.WriteLine($"{p.Name}: {propertyText} " + "\r\n");
            //    }

            //}

            //ROBINTEST CODE KENNY
            //voor elke propertyinfo in het object
            //check of het een hastable is
            //zowel, apart ook nog eens uitlezen

            foreach (var p in objectTypeProperties)
            {
                if (_checkIfProperyIsObject(p))
                {

                    Console.WriteLine("this is a type itself and should be read out separately.");

                }
                else
                {
                    var propertyText = p.GetValue(objectToRead);
                    Console.WriteLine($"{p.Name}: {propertyText} " + "\r\n");
                    _check(p);

                }

            }

        }

        private static bool _checkIfProperyIsObject(PropertyInfo info)
        {
            //Kenny
            return info.PropertyType.GetInterface(nameof(ICollection)) != null;
        }

        private static void _check(PropertyInfo info)
        {
            info.PropertyType.GetGenericTypeDefinition().ToString();
        }
    }
}
