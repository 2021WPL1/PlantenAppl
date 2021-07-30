﻿using GalaSoft.MvvmLight.Ioc;
using MvvmDialogs;
using PlantenApplicatie.Services.Interfaces;

namespace PlantenApplicatie.Services.HelpClasses
{
    /*written by kenny*/
    public class ServiceProvider
    {
        public static void RegisterServices()
        {
            // basisstructuur kenny, mede gebruikt door Robin

            // de Default instantie (singleton) van de class SimpleIOC container
            // gebruiken als container voor de services.
            SimpleIoc iocc = SimpleIoc.Default;

            // registreren van utility services
            iocc.Register<IloginUserService, LoginUserService>();
            iocc.Register<ISearchService, SearchService>();
            iocc.Register<IDetailService, DetailService>();

        }
    }
}