using System.ComponentModel;

namespace mvvm_exercise.ViewModel
{
    using Model;
    using System.Windows;
    using System.Windows.Input;

    class MvvmExerciseViewModel : INotifyPropertyChanged
    {
        private MvvmExerciseModel model = new MvvmExerciseModel() { FontSize = 0 } ;

        #region Properties         
        public string DefaultName
        {
            get
            {
                return model.DefaultName;
            }
            set
            {
                model.DefaultName = value;
                OnPropertyChnged(nameof(DefaultName));
            }
        }

        public int FontSize
        {
            get
            {
                return model.FontSize;
            }
            set
            {
                model.FontSize = value;
                OnPropertyChnged(nameof(FontSize));
            }
        }

        public bool Start
        {
            get
            {
                return model.Start;
            }
            set
            {
                model.Start = value;
                OnPropertyChnged(nameof(Start));
            }
        }

        public bool AutoStart
        {
            get
            {
                return model.AutoStart;
            }
            set
            {
                model.AutoStart = value;
                OnPropertyChnged(nameof(AutoStart));
            }
        }

        public bool DynamicColors
        {
            get
            {
                return model.DynamicColors;
            }
            set
            {
                model.DynamicColors = value;
                OnPropertyChnged(nameof(DynamicColors));
            }
        }
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChnged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        #endregion

        #region RelayCommand
        private ICommand _reset;
        private ICommand _ok;
        private ICommand _cancel;

        public ICommand Reset
        {
            get
            {
                if (_reset == null)
                    _reset = new RelayCommand(
                        (object o) =>
                        {
                            DefaultName = "";
                            FontSize = 0;
                            Start = false;
                            AutoStart = false;
                            DynamicColors = false;
                        },
                        (object o) => { return !string.IsNullOrEmpty(DefaultName) || FontSize != 0 || Start != false || AutoStart != false || DynamicColors != false; }
                        );
                return _reset;
            }
        }

        public ICommand Ok
        {
            get
            {
                if (_ok == null)
                    _ok = new RelayCommand(
                        (object o) =>
                        {
                            MessageBox.Show("Hello " + DefaultName, "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        },
                        (object o) => { return !string.IsNullOrEmpty(DefaultName) || FontSize != 0 || Start != false || AutoStart != false || DynamicColors != false; }
                        );
                return _ok;
            }
        }
        public ICommand Cancel
        {
            get
            {
                if (_cancel == null)
                    _cancel = new RelayCommand(
                        (object o) =>
                        {
                            MessageBox.Show("Operation has been cancelled by the User", "Information", MessageBoxButton.OK, MessageBoxImage.Stop);
                        },
                        (object o) => { return !string.IsNullOrEmpty(DefaultName) || FontSize != 0 || Start != false || AutoStart != false || DynamicColors != false; }
                        );
                return _cancel;
            }
        }


        #endregion
    }
}
