using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Ioc;
using PlantenApplicatie.Services;
using PlantenApplicatie.Services.HelpClasses;
using PlantenApplicatie.Viewmodel;

namespace PlantenApplicatie
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            //SearchService.CreateInstance();
            // services registeren
            ServiceProvider.RegisterServices();
            // VMprovider toevoegen als "static resource" in MvvM zodat die kan worden gebruikt in de Views om
            // de ViewModels te koppelen aan de DataContext
            // instantie die over de hele applicatie kan worden gebruikt in de Views met onderstaande binding
            // <Window: ...
            // DataContext="{Binding Source={ StaticResource VMProvider }, Path=MainWindowViewModel }" 
            // ... 
            // >

            //var iocc = SimpleIoc.Default;

            //ViewModelRepo.CreateInstance();
            
            this.Resources.Add("VMProvider", new ViewModelProvider());

            // de viewmodellen kunnen ook worden toegekend aan de 
            // datacontext van de view met GetInstance methode van de IoC Container
            // in de code behind van de view (yyy.xaml.cs)
            //vb. DataContext = GalaSoft.MvvmLight.Ioc.SimpleIoc.Default.GetInstance<MainWindowViewModel>
        }
    }
}
