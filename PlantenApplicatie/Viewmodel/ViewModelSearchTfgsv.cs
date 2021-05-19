using System;
using System.Collections.Generic;
using System.Text;
using Planten2021.Data;

namespace PlantenApplicatie.ViewModel
{
    class ViewModelSearchTfgsv
    {
        private DAO _dao;
        public ViewModelSearchTfgsv(DAO dao)
        {
            _dao = dao;
        }

        //public ICommand addProductToInventoryCommand { get; set; }
        //public ICommand removeProductFromInventoryCommand { get; set; }
        //public ICommand addProductCommand { get; set; }
        //public ICommand removeProductCommand { get; set; }

        //public ObservableCollection<Inventory> Inventories { get; set; }
        //public ObservableCollection<Product> Products { get; set; }

        //private string productNameInput;
        //private string productDescriptionInput;

        //private GameStoreDataService _dataservice;

        //private Inventory _selectedInventory;
        //private Product _selectedProduct;

        //public MainViewModel(GameStoreDataService zooAnimalDataService)
        //{
        //    addProductToInventoryCommand = new DelegateCommand(addToInventory);
        //    removeProductFromInventoryCommand = new DelegateCommand(removeFromInventory);
        //    addProductCommand = new DelegateCommand(addProduct);
        //    removeProductCommand = new DelegateCommand(deleteProduct);

        //    Inventories = new ObservableCollection<Inventory>();
        //    Products = new ObservableCollection<Product>();

        //    this._dataservice = zooAnimalDataService;
        //}
    }
}
