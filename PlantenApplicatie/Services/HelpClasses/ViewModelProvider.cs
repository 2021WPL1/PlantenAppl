﻿using GalaSoft.MvvmLight.Ioc;
using Planten2021.Data;
using PlantenApplicatie.Services.Interfaces;
using PlantenApplicatie.Viewmodel;
using PlantenApplicatie.ViewModel;

namespace PlantenApplicatie.Services.HelpClasses
{
    /// <summary>
    /// Provider van viewmodels
    /// De views worden in de SimpleIoc IoC (Inversion of Control) container geregistreerd
    /// </summary>
    public class ViewModelProvider
    {
        private static readonly ViewModelProvider instance = new ViewModelProvider();
        
        public static ViewModelProvider Instance()
        {
            return instance;
        }
        private ViewModelProvider()
        {
            this.RegisterViewModels();
        }

        #region exposed viewmodels 
        // viewmodels public exposure om te gebruiken in de views met onderstaande code
        // de ViewModelProvider wordt geinstancieerd tijdens de constructie van de App class. => App.xaml.cs
        // de ViewModels worden uit de IoC Container gehaald (GetInstance) en public beschikbaar gemaakt
        // gebruik in de View: 
        //// <Window: ...
        // DataContext="{Binding Source={ StaticResource VMProvider }, Path=MainWindowViewModel }" 
        // ... 
        // >
        public ViewModelMain ViewModelMain { get { return SimpleIoc.Default.GetInstance<ViewModelMain>(); } }
        public ViewModelLogin ViewModelLogin { get { return SimpleIoc.Default.GetInstance<ViewModelLogin>(); } }

        //public ViewModelNameResult ViewModelNameResult { get { return SimpleIoc.Default.GetInstance<ViewModelNameResult>(); } }
        //public ViewModelRepo ViewModelRepo
        #endregion

        private void RegisterViewModels()
        {
            // gebruik de default instantie (singleton van de SimpleIoc class)
            var iocc = SimpleIoc.Default;

            // haal singletons (elke keer dezelfde instantie) van de services om de viewmodels te voorzien van de nodige services, 
            var loginService = iocc.GetInstance<IloginUserService>();
            var searchService = iocc.GetInstance<ISearchService>();


            // registreer de viewmodels in de IoC Container
            // factory pattern om een instantie te maken van de viewmodels
            // Dependency Injection: constructor injection: injecteer  de services in the constructors van de viewmodels;

            SimpleIoc.Default.Unregister<ViewModelLogin>();
            iocc.Register<ViewModelLogin>(() => new ViewModelLogin(loginService));

            SimpleIoc.Default.Unregister<ViewModelNameResult>();
            iocc.Register<ViewModelNameResult>(() => new ViewModelNameResult(searchService));

            SimpleIoc.Default.Unregister<ViewModelRepo>();
            iocc.Register<ViewModelRepo>(() => new ViewModelRepo(searchService));

            SimpleIoc.Default.Unregister<ViewModelMain>();
            iocc.Register<ViewModelMain>(() => new ViewModelMain(loginService, searchService));

            SimpleIoc.Default.Unregister<ViewModelProvider>();
            iocc.Register<ViewModelProvider>(() => new ViewModelProvider());

        }
        public ViewModelRepo ReturnViewModelRepo()
        {
            var iocc = SimpleIoc.Default;
            var result = iocc.GetInstance<ViewModelRepo>();

            return result;
        }
        public ViewModelProvider ReturnViewModelProvider()
        {
            var iocc = SimpleIoc.Default;
            var result = iocc.GetInstance<ViewModelProvider>();

            return result;
        }
    }
}