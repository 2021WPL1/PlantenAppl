using GalaSoft.MvvmLight.Ioc;
using Planten2021.Data;
using PlantenApplicatie.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PlantenApplicatie.Services
{
    public class DetailService : IDetailService, INotifyPropertyChanged
    {
        private DAO _dao;
        private static DetailService _detailService;
        private static SimpleIoc iocc = SimpleIoc.Default;
        private ISearchService _searchService = iocc.GetInstance<ISearchService>();

        public event PropertyChangedEventHandler PropertyChanged;
        public DetailService(ISearchService searchService)
        {
            _searchService = searchService;
            this._dao = DAO.Instance();
        }
    }
}
