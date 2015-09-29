using CMS.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.ViewModel.Base
{
    abstract class EditableViewModel : BaseViewModel
    {

        protected void EditData()
        {
            Mode selectedMode = SelectedMode;

            switch (selectedMode)
            {
                case Mode.Add: CreateData();
                    break;
                case Mode.Edit: EditData();
                    break;
                default: return;
            }
        }

        abstract protected void SaveData();

        abstract protected void CreateData();

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

        public Mode SelectedMode
        {
            get
            {
                return _selectedMode;
            }
            set
            {
                if (_selectedMode != value)
                {
                    _selectedMode = value;
                    OnPropertyChanged("SelectedMode");
                }
            }
        }
        private Mode _selectedMode = Mode.Read;
    }
}
