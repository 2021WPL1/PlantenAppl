using GalaSoft.MvvmLight.Ioc;
using Planten2021.Data;
using Planten2021.Domain.Models;
using PlantenApplicatie.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;

namespace PlantenApplicatie.Services
{
    public class DetailService : IDetailService, INotifyPropertyChanged
    {
        private DAO _dao;
        private static DetailService _detailService;
        private static SimpleIoc iocc = SimpleIoc.Default;
        private ISearchService _searchService = iocc.GetInstance<ISearchService>();

        public Plant selectedPlantInResult;

        public event PropertyChangedEventHandler PropertyChanged;
        public DetailService(ISearchService searchService)
        {
            this._dao = DAO.Instance(); 
            _searchService = searchService;
            
        }
        public void test()
        {
            selectedPlantInResult = _searchService.ReturnSelectedPlantInSearchResult();
            MessageBox.Show(selectedPlantInResult.Fgsv.ToString());
        }
        
    }
}
