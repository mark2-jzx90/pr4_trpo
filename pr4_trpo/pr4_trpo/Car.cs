using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace pr4_trpo
{
    class Car : INotifyPropertyChanged
    {
        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                if(_id != value)
                {
                    _id = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _brand;
        public string Brand
        {
            get => _brand;
            set
            {
                if(_brand != value)
                {
                    _brand = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _model;
        public string Model
        {
            get => _model;
            set
            {
                if (_model != value)
                {
                    _model = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _year;
        public int Year
        {
            get => _year;
            set
            {
                if(_year != value)
                {
                    _year = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _km;
        public int Km
        {
            get => _km;
            set
            {
                if( _km != value)
                {
                    _km = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Age
        {
            get
            {
                int YearNow = DateTime.Now.Year;
                int age = YearNow - Year;
                return age;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged ([CallerMemberName] string? propName = null)
        {
            PropertyChanged?.Invoke(this, new
            PropertyChangedEventArgs(propName));
        }
    }
}



