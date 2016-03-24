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
using CMS.Common.Helpers;
using System.Reflection;

namespace CMS.ViewModel
{
    class CarsViewModel : EditableViewModel
    {
        #region Cars

        public ObservableCollection<Car> Cars
        {
            get
            {
                return _cars;
            }
            set
            {
                if (_cars != value)
                {
                    _cars = value;
                    OnPropertyChanged("Cars");
                }
            }
        }
        private ObservableCollection<Car> _cars;

        public Car SelectedCar
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
                    OnPropertyChanged("SelectedCar");
                    OnSelectedTruckChanged();
                }
            }
        }        
        private Car _selectedCar;

        #endregion

        public CarsViewModel()
        {
            
        }

        public override void InitData()
        {
            Cars = new ObservableCollection<Car>(Connector.GetAllCars());
            base.SelectedModeChanged -= TrucksViewModel_SelectedModeChanged;
            base.SelectedModeChanged += TrucksViewModel_SelectedModeChanged;            
        }

        void TrucksViewModel_SelectedModeChanged(object sender, SelectedModeEventArgs e)
        {
            if (e == null) return;            

            if (e.SelectedMode == Mode.Add)
            {
                _selectedCar = new Car();
                OnPropertyChanged("SelectedCar");
            }            
        }       

        private void OnSelectedTruckChanged()
        {
            SelectedMode = Mode.Read;
        }

        protected override void SaveData()
        {
            if (SelectedCar == null) return;

            Connector.UpdateCar(SelectedCar);
        }

        protected override void CreateData()
        {
            if (!CarValidator.Validate(SelectedCar))
            {
                MessageBox.Show("Marka i numer rejestracyjny musi być podany.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            Connector.AddCar(SelectedCar);
        }

        protected override void RemoveData()
        {
            Connector.RemoveCar(SelectedCar.CarID);
        }

        private Car GetSelectedCar(int carId)
        {
            if (carId < 0) return null;

            return Connector.GetSelectedCar(carId);
        }        
    }
}
