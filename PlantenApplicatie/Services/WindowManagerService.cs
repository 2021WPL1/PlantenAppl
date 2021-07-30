using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using Planten2021.Data;
using PlantenApplicatie.Services.Interfaces;
using PlantenApplicatie.View;
using PlantenApplicatie.View.Home;

namespace PlantenApplicatie.Services
{
    public class WindowManagerService: IWindowManagerService, INotifyPropertyChanged
    {
        private DAO _dao;

        private ObservableCollection<Window> _windows;

        public event PropertyChangedEventHandler PropertyChanged;
        public WindowManagerService()
        {
            this._dao = DAO.Instance();
           // _windows = new ObservableCollection<Window> {new LoginWindow() , new MainWindow(),new RegisterWindow()};
        }

        public void CloseWindow(Window window)
        {
           
            window.Close();

        }

        public bool IsAnyWindowOpen()
        {
            if (_windows.Count == 0)

            { return true; }

            else

            { return false; }

        }
    }
}
