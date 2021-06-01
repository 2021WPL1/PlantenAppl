using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight.Ioc;
using planten.desktopUI.Services;
using PlantenApplicatie.Services.Interface;

namespace PlantenApplicatie.HelpClasses
{
    public static class ServicesProvider
    {
        /// <summary>
        /// Registreer de services in de IoC container om later te injecteren
        /// tijdens de constructie van de viewmodels in de ViewModelLocator class.
        /// wordt aangeroepen in de app.xaml.cs file bij de start van de applicatie.
        /// </summary>
        public static void RegisterServices()
        {
            // de Default instantie (singleton) van de class SimpleIOC container
            // gebruiken als container voor de services.
            SimpleIoc iocc = SimpleIoc.Default;



            //// registreren van utility services
            iocc.Register<ILoginUserService, LoginUserService>();

            //// Data services
            //iocc.Register<IMockDataService, MockDataService>();

        }
    }
}
