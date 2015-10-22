using CMS.Common.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CMS.ViewModel.Base
{
    abstract class EditableViewModel : BaseViewModel
    {
        public event EventHandler<SelectedModeEventArgs> SelectedModeChanged;

        public void EditData()
        {
            Mode selectedMode = SelectedMode;

            switch (selectedMode)
            {
                case Mode.Add: CreateData();
                    break;
                case Mode.Edit: SaveData();
                    break;                
                default: return;
            }

            InitData();
        }

        abstract protected void SaveData();

        abstract protected void CreateData();

        abstract protected void RemoveData();

        /// <summary>
        /// Indicates if there was any changes
        /// </summary>
        public bool PendingChanges
        {
            get
            {
                return _pendingChanges;
            }
            set
            {
                if (_pendingChanges != value)
                {
                    _pendingChanges = value;
                }
            }
        }
        private bool _pendingChanges = false;

        /// <summary>
        /// Indicates if the selected mode allows to save data
        /// </summary>
        public bool CanSaveData
        {
            get
            {
                return
                    SelectedMode == Mode.Add ||
                    SelectedMode == Mode.Edit;
            }
        }

        public virtual void InitData()
        {

        }

        #region Modes

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
                OnPropertyChanged("CanSaveData");
                OnSelectedModeChanged(new SelectedModeEventArgs(value));

                if (value == Mode.Remove)
                {
                    if (MessageBox.Show("Czy napewno chcesz dokonać usunięcia?", "Usuwanie", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        RemoveData();
                        InitData();
                    }

                }
            }
        }

        private void OnSelectedModeChanged(SelectedModeEventArgs e)
        {
            EventHandler<SelectedModeEventArgs> selectedModeChanged = SelectedModeChanged;

            if (selectedModeChanged != null)
            {
                selectedModeChanged.Invoke(this, e);
            }
        }

        private Mode _selectedMode = Mode.Read;

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
    }

    class SelectedModeEventArgs : EventArgs
    {
        public Mode SelectedMode { get; private set; }

        public SelectedModeEventArgs(Mode mode)
        {
            SelectedMode = mode;
        }
    }
}
