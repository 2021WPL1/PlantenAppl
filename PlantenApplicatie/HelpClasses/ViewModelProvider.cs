
using GalaSoft.MvvmLight.Ioc;
using PlantenApplicatie.Services.Interface;
using PlantenApplicatie.HelpClasses;

namespace PlantenApplicatie.HelpClasses
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
        //////////////public MainWindowViewModel MainWindowViewModel {  get { return SimpleIoc.Default.GetInstance<MainWindowViewModel>(); }  }
        //////////////public LoginViewModel LoginView { get { return SimpleIoc.Default.GetInstance<LoginViewModel>(); } }
        #endregion

        private void RegisterViewModels()
        {
            // gebruik de default instantie (singleton van de SimpleIoc class)
            var  iocc = SimpleIoc.Default;

            // haal singletons (elke keer dezelfde instantie) van de services om de viewmodels te voorzien van de nodige services, 
            var loginService = iocc.GetInstance<ILoginUserService>();


            // registreer de viewmodels in de IoC Container
            // factory pattern om een instantie te maken van de viewmodels
            // Dependency Injection: constructor injection: injecteer  de services in the constructors van de viewmodels;
            ////////iocc.Register<MainWindowViewModel>(() => new MainWindowViewModel(dialogService, sharedService, loginService));
            ////////iocc.Register<LoginViewModel>(() => new LoginViewModel(loginService, closingWindowManager));

        }
    }
}
