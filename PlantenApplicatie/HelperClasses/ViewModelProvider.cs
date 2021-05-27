using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight.Ioc;
using PlantenApplicatie.Viewmodel;
using PlantenApplicatie.ViewModel;

namespace PlantenApplicatie.HelperClasses
{
    public class ViewModelProvider
    {
        public ViewModelProvider()
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
        public ViewModelMain viewModelMain { get { return SimpleIoc.Default.GetInstance<ViewModelMain>(); } }
        public ViewModelLogin viewModelLogin { get { return SimpleIoc.Default.GetInstance<ViewModelLogin>(); } }
        #endregion

        private void RegisterViewModels()
        {
            // gebruik de default instantie (singleton van de SimpleIoc class)
            var iocc = SimpleIoc.Default;

            // haal singletons (elke keer dezelfde instantie) van de services om de viewmodels te voorzien van de nodige services, 
            var loginService = iocc.GetInstance<ILoginUserService>();


            // registreer de viewmodels in de IoC Container
            // factory pattern om een instantie te maken van de viewmodels
            // Dependency Injection: constructor injection: injecteer  de services in the constructors van de viewmodels;
            iocc.Register<ViewModelMain>(() => new ViewModelMain(loginService));
            iocc.Register<ViewModelLogin>(() => new ViewModelLogin(loginService));

        }
    }
}
