using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lab12_Multiplataforma.ViewModel
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        private string _result;

        public CalculatorViewModel()
        {
            CalculateCommand = new Command<string>(Calculate);
            ClearCommand = new Command(Clear);
            _result = string.Empty;
        }

        public string Result
        {
            get { return _result; }
            set
            {
                if (_result != value)
                {
                    _result = value;
                    OnPropertyChanged(nameof(Result));
                }
            }
        }

        public ICommand CalculateCommand { get; }
        public ICommand ClearCommand { get; }

        private void Calculate(string parameter)
        {
            if (parameter == "=")
            {
                Result = new DataTable().Compute(Result, null).ToString();
            }
            else
            {
                Result += parameter;
            }
        }

        private void Clear()
        {
            Result = string.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
