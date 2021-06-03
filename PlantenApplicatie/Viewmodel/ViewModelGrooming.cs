using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Planten2021.Data;
using Planten2021.Domain.Models;
using PlantenApplicatie.ViewModel;

namespace PlantenApplicatie.Viewmodel
{
    public class ViewModelGrooming : ViewModelBase
    {
        private DAO _dao;

        public ViewModelGrooming()
        {
            this._dao = DAO.Instance();

            cmbBeheerdaad = new ObservableCollection<string>();

            fillComboBoxBeheerdaad();
        }

        public ObservableCollection<string> cmbBeheerdaad { get; set; }

        public void fillComboBoxBeheerdaad()
        {
            var list = _dao.FillBeheerdaad().ToList();

            
                foreach (var item in list)
                {
                    //if (item != null)
                    //{
                        cmbBeheerdaad.Add(item.Beheerdaad);
                    //}
                    
                }
            
            
        }

        private string _selectedBeheerdaad;

        public string SelectedBeheer_Maand
        {
            get { return _selectedBeheerdaad; }
            set
            {
                _selectedBeheerdaad = value;
                OnPropertyChanged();

            }
        }
    }
}
