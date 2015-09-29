using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMSDatabaseConnector;
using System.Windows;
using System.Diagnostics;
using CMS.Common.Enums;
using CMS.ViewModel.Base;
using CMS.Common.Interfaces;

namespace CMS.ViewModel
{
    class TrucksViewModel : EditableViewModel
    {
        #region Trucks

        public ObservableCollection<Car> Trucks { get; set; }

        public Car SelectedTruck
        {
            get
            {
                return _selectedCar;
            }
            set
            {
                if (value != _selectedCar)
                {
                    _selectedCar = value;
                    OnPropertyChanged("SelectedTruck");
                    OnSelectedTruckChanged();
                }
            }
        }

        private Car _selectedCar;

        #endregion       

        #region Modes

        public ObservableCollection<Mode> Modes
        {
            get
            {
                return new ObservableCollection<Mode>
                {
                    Mode.Read,
                    Mode.Edit,
                    Mode.Add,
                    Mode.Remove
                };
            }
        }

        #endregion

        public TrucksViewModel()
        {
            Trucks = new ObservableCollection<Car>(Connector.GetAllCars());
        }
      

        private void OnSelectedTruckChanged()
        {
            SelectedMode = Mode.Read;
        }

        protected override void SaveData()
        {
            if (SelectedTruck == null) return;

            Connector.UpdateCar(SelectedTruck);
        }

        protected override void CreateData()
        {
            
        }

        private Car FromViewModelToEntity()
        {
            var car = new Car();

            

            return car;
        }
    }   
}
