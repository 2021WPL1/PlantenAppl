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
        //Robin
        //Op dit moment wordt de service niet gebruikt, deze is opgezet om later de plantdetails te kunnen weergeven en te kunnen toevoegen in alle usercontrols

        private DAO _dao;
        private static DetailService _detailService;
        private static SimpleIoc iocc = SimpleIoc.Default;
        private ISearchService _searchService = iocc.GetInstance<ISearchService>();

        public event PropertyChangedEventHandler PropertyChanged;
        public DetailService(ISearchService searchService)
        {
            this._dao = DAO.Instance();
            _searchService = searchService;
        }

        public Plant ReturnSelectedPlant()
        {
            Plant plant = _searchService.ReturnSelectedPlant();
            return plant;
        }

        public List<FenotypeMulti> FilterFenoMulti(long plantId)
        {
            var filteredFenoTypeMulti = _dao.GetFenotypeMultis(plantId);

            return filteredFenoTypeMulti;
        }

        public List<FenoBloeiwijze> GetFenoBloeiwijzes()
        {
            var fenoBloeiWijzes = _dao.GetFenoBloeiwijze();

            return fenoBloeiWijzes;
        }

        public Fenotype GetFenoTypes(long plantId)
        {
            var fenoTypes = _dao.GetFenoTypes(plantId);

            return fenoTypes;
        }

        
    }
}
