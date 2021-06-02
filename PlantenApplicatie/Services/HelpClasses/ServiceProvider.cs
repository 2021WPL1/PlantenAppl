using GalaSoft.MvvmLight.Ioc;
using MvvmDialogs;
using PlantenApplicatie.Services.Interfaces;

namespace PlantenApplicatie.Services.HelpClasses
{
    public class ServiceProvider
    {
        public static void RegisterServices()
        {
            // de Default instantie (singleton) van de class SimpleIOC container
            // gebruiken als container voor de services.
            SimpleIoc iocc = SimpleIoc.Default;

            //iocc.Register<IDialogService>(() => new MvvmDialogs.DialogService());
            //iocc.Register<IloginUserService>(() => new LoginUserService());

            // registreren van utility services
            iocc.Register<IloginUserService, LoginUserService>();
            iocc.Register<ISearchService, SearchService>();
        }
    }
}