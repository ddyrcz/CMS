using System.Collections.ObjectModel;
using CMSDatabaseConnector;
using System.Windows;
using CMS.Common.Enums;
using CMS.ViewModels.Base;
using CMS.Common.Helpers;

namespace CMS.ViewModels
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
                    NotifyOfPropertyChange();
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
                    NotifyOfPropertyChange();
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
                NotifyOfPropertyChange(() => SelectedCar);
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

        public void ManageOCInstallments()
        {
        }

        public void ManageACInstallemnts()
        {

        }
    }
}
