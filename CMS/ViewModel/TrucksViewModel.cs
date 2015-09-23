using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMSDatabaseConnector;
using System.Windows;
using System.Diagnostics;

namespace CMS.ViewModel
{
    class TrucksViewModel : BaseViewModel
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
                    SelectedTruckChanged();
                    OnPropertyChanged("SelectedTruck");                    
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

        public Mode SelectedMode
        {
            get
            {
                return _selectedMode;
            }
            set
            {
                _selectedMode = value;
                OnPropertyChanged("SelectedMode");
            }
        }
        private Mode _selectedMode;

        #endregion

        public TrucksViewModel()
        {
            try
            {
                Trucks = new ObservableCollection<Car>(Connector.GetAllCars());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SelectedTruckChanged()
        {
            
        }
    }

    enum Mode
    {
        Read,
        Edit,
        Add,
        Remove,
    }
}
