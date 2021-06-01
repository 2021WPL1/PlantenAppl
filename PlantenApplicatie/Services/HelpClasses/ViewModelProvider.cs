using GalaSoft.MvvmLight.Ioc;
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
        public ViewModelMain ViewModelMain { get { return SimpleIoc.Default.GetInstance<ViewModelMain>(); } }
        public ViewModelLogin ViewModelLogin { get { return SimpleIoc.Default.GetInstance<ViewModelLogin>(); } }
        #endregion

        private void RegisterViewModels()
        {
            // gebruik de default instantie (singleton van de SimpleIoc class)
            var iocc = SimpleIoc.Default;

            // haal singletons (elke keer dezelfde instantie) van de services om de viewmodels te voorzien van de nodige services, 
            var loginService = iocc.GetInstance<IloginUserService>();


            // registreer de viewmodels in de IoC Container
            // factory pattern om een instantie te maken van de viewmodels
            // Dependency Injection: constructor injection: injecteer  de services in the constructors van de viewmodels;
            iocc.Register<ViewModelLogin>(() => new ViewModelLogin(loginService));
            iocc.Register<ViewModelMain>(() => new ViewModelMain(loginService));


        }
    }
}