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

namespace CMS.ViewModel
{
    class TrucksViewModel : EditableViewModel
    {
        #region Trucks

        public ObservableCollection<Car> Trucks
        {
            get
            {
                return _trucks;
            }
            set
            {
                if (_trucks != value)
                {
                    _trucks = value;
                    OnPropertyChanged("Trucks");
                }
            }
        }
        private ObservableCollection<Car> _trucks;

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
                    _selectedCar = GetSelectedCar(value != null ? value.CarID : -1);
                    OnPropertyChanged("SelectedTruck");
                    OnSelectedTruckChanged();
                }
            }
        }        

        private Car _selectedCar;

        #endregion

        public TrucksViewModel()
        {
            
        }

        public override void InitData()
        {            
            Trucks = new ObservableCollection<Car>(Connector.GetAllCars());
            base.SelectedModeChanged -= TrucksViewModel_SelectedModeChanged;
            base.SelectedModeChanged += TrucksViewModel_SelectedModeChanged;

        }

        void TrucksViewModel_SelectedModeChanged(object sender, SelectedModeEventArgs e)
        {
            if (e == null) return;            

            if (e.SelectedMode == Mode.Add)
            {
                _selectedCar = new Car();
                OnPropertyChanged("SelectedTruck");
            }
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
            Connector.AddCar(SelectedTruck);
        }

        private Car GetSelectedCar(int carId)
        {
            if (carId < 0) return null;

            return Connector.GetSelectedCar(carId);
        }
    }
}
