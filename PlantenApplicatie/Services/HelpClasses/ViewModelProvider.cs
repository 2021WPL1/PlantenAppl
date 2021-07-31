using GalaSoft.MvvmLight.Ioc;
using Planten2021.Data;
using PlantenApplicatie.Services.Interfaces;
using PlantenApplicatie.View;
using PlantenApplicatie.View.Home;
using PlantenApplicatie.Viewmodel;
using PlantenApplicatie.ViewModel;

namespace PlantenApplicatie.Services.HelpClasses
{  /*written by kenny*/  
    /// <summary>
    /// Provider van viewmodels
    /// De views worden in de SimpleIoc IoC (Inversion of Control) container geregistreerd
    /// </summary>
    public class ViewModelProvider
    {
        public ViewModelProvider()
        {
            this.RegisterViewModels();
        }

        private void RegisterViewModels()
        {
            //basisstructuur kenny, mede gebruikt door Robin
            // gebruik de default instantie (singleton van de SimpleIoc class)
            var iocc = SimpleIoc.Default;

            // haal singletons (elke keer dezelfde instantie) van de services om de viewmodels te voorzien van de nodige services(service locator)
            var loginService = iocc.GetInstance<IloginUserService>();
            var searchService = iocc.GetInstance<ISearchService>();
            var detailService = iocc.GetInstance<IDetailService>();
            var windowManagerService = iocc.GetInstance<IWindowManagerService>();

            // registreer de viewmodels in de IoC Container
            // factory pattern om een instantie te maken van de viewmodels
            // Dependency Injection: constructor injection: injecteer  de services in the constructors van de viewmodels;

            iocc.Register<ViewModelLogin>(() => new ViewModelLogin(loginService, windowManagerService));
            iocc.Register<ViewModelRegister>(() => new ViewModelRegister(loginService, windowManagerService));

            iocc.Register<ViewModelBloom>(() => new ViewModelBloom(detailService));
            iocc.Register<ViewModelGrooming>(() => new ViewModelGrooming(detailService));
            iocc.Register<ViewModelGrow>(() => new ViewModelGrow(detailService));
            iocc.Register<ViewModelHabitat>(() => new ViewModelHabitat(detailService));

            iocc.Register<ViewModelAppearance>(() => new ViewModelAppearance(detailService));
            iocc.Register<ViewModelNameResult>(() => new ViewModelNameResult(searchService));

            //SimpleIoc.Default.Unregister<ViewModelMain>();
            iocc.Register<ViewModelBase>(() => new ViewModelBase());
            iocc.Register<ViewModelMain>(() => new ViewModelMain(loginService, searchService, windowManagerService));
            iocc.Register<ViewModelRepo>(() => new ViewModelRepo());

            iocc.Register<MainWindow>(() => new MainWindow());
            iocc.Register<LoginWindow>(() => new LoginWindow());
            iocc.Register<RegisterWindow>(() => new RegisterWindow());
        }
    }
}