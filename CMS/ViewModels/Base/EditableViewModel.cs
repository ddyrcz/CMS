﻿using CMS.Common.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CMS.ViewModels.Base
{
    abstract class EditableViewModel : BaseViewModel
    {
        public event EventHandler<SelectedModeEventArgs> SelectedModeChanged;

        public void EditData()
        {
            switch (SelectedMode)
            {
                case Mode.Add:
                    CreateData();
                    break;
                case Mode.Edit:
                    SaveData();
                    break;
                default: return;
            }

            InitData();
        }

        abstract protected void SaveData();

        abstract protected void CreateData();

        abstract protected void RemoveData();

        /// <summary>
        /// Indicates if there are any changes
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
        /// Indicates if selected mode allows to save the data
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

        /// <summary>
        /// Indicates if editable mode is set on
        /// </summary>
        public bool IsEditable
        {
            get
            {
                return
                    (SelectedMode == Mode.Edit || SelectedMode == Mode.Add);
            }
        }

        public virtual void InitData() { }

        public void WindowLoaded()
        {
            InitData();
        }

        /// <summary>
        /// Indicates if controls for editing are visible
        /// </summary>
        public Visibility EditVisible
        {
            get
            {
                return
                    (SelectedMode == Mode.Edit || SelectedMode == Mode.Add) ?
                    Visibility.Visible :
                    Visibility.Collapsed;
            }
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
                NotifyOfPropertyChange(() => SelectedMode);
                NotifyOfPropertyChange(() => CanSaveData);
                NotifyOfPropertyChange(() => EditVisible);
                NotifyOfPropertyChange(() => IsEditable);
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

        /// <summary>
        /// Better would be to set read mode as a default, but then there are some errors while reparing date pickers background
        /// </summary>
        private Mode _selectedMode = Mode.Edit;

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
