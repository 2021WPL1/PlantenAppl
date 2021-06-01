using GalaSoft.MvvmLight.Ioc;
using MvvmDialogs;
using PlantenApplicatie.Services.Interfaces;

namespace PlantenApplicatie.Services.HelpClasses
{/*written by kenny*/
    public class ServiceProvider
    {

        public static void RegisterServices()
        {
            // de Default instantie (singleton) van de class SimpleIOC container
            // gebruiken als container voor de services.
            SimpleIoc iocc = SimpleIoc.Default;

            // registreren van utility services
            iocc.Register<IloginUserService, LoginUserService>();
        }
    }
}