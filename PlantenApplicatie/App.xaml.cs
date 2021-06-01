using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using PlantenApplicatie.HelpClasses;

namespace PlantenApplicatie
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // services registeren
        ServicesProvider.RegisterServices()

        // VMLocator toevoegen als "static resource" in MvvM zodat die kan worden gebruikt in de Views om
        // de ViewModels te koppelen aan de DataContext
        // instantie die over de hele applicatie kan worden gebruikt in de Views met onderstaande binding
        // <Window: ...
        // DataContext="{Binding Source={ StaticResource VMLocator }, Path=MainWindowViewModel }" 
        // ... 
        // >
        this.Resources.Add("VMProvider",new ViewModelProvider());

        // de viewmodellen kunnen ook worden toegekend aan de 
        // datacontext van de view met GetInstance methode van de IoC Container
        // in de code behind van de view (yyy.xaml.cs)
        //vb. DataContext = GalaSoft.MvvmLight.Ioc.SimpleIoc.Default.GetInstance<MainWindowViewModel>
    }
}
