//Created by Vitaliy Chumak, on 22.02.19
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Chumak_lab1
{
    internal class BirthdayViewModel : INotifyPropertyChanged
    {
        private static readonly string[] ChinaZodiacs = { "Monkey", "Rooster", "Dog", "Pig", "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat" };
        private static readonly string[] WesternZodiacs = { "Aquarius", "Pisces", "Aries", "Taurus", "Gemini", "Cancer", "Leo", "Virgo", "Libra", "Scorpio", "Sagittarius", "Capricorn" };
        private DateTime _dateOfBirth;
        private string _zodiacWest;
        private string _zodiacChina;
        private string _age;
        private bool _happyBDay;

        public string Age
        {
            get
            {
                return $"Your age is {_age}";
            }
            private set
            {
                _age = value;
                OnPropertyChanged();
            }
        }
        public string ZodiacWest
        {
            get
            {
                return $"Western zodiac: {_zodiacWest}";
            }
            private set
            {
                _zodiacWest = value;
                OnPropertyChanged();
            }
        }
        public string ZodiacChinese
        {
            get
            {
                return $"Chinese zodiac: {_zodiacChina}";
            }
            private set
            {
                _zodiacChina = value;
                OnPropertyChanged();
            }
        }
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                _dateOfBirth = value;
                try
                {
                    Calculate();
                    OnPropertyChanged();
                    if (_happyBDay)
                        MessageBox.Show("Happy b-day, bro!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Incorrect date!");
                }
            }
        }

        internal BirthdayViewModel()
        {
            _dateOfBirth = DateTime.Today;
        }

        private void Calculate()
        {
            int days = (DateTime.Today - _dateOfBirth).Days;
            var age = days / 365;

            if (days < 0 || age > 135)
                throw new ArgumentException("Incorrect date");

            Age = age.ToString();
            _happyBDay = HappyBDay();
            ZodiacWest = Zodiac();
            ZodiacChinese = ChineseZodiac();
        }
        private bool HappyBDay()
        {
            return DateTime.Today.DayOfYear == _dateOfBirth.DayOfYear;
        }
        private string ChineseZodiac()
        {
            return ChinaZodiacs[_dateOfBirth.Year % 12];
        }
        private string Zodiac()
        {
            var day = _dateOfBirth.Day;
            var month = _dateOfBirth.Month;
            switch (month)
            {
                case 1: case 4:
                    return day >= 20 ? WesternZodiacs[month - 1] : (month == 1 ? WesternZodiacs[WesternZodiacs.Length - 1] : WesternZodiacs[month - 2]);
                case 2:
                    return day >= 19 ? WesternZodiacs[month - 1] : WesternZodiacs[month - 2];
                case 3:  case 5:  case 6:
                    return day >= 21 ? WesternZodiacs[month - 1] : WesternZodiacs[month - 2];
                case 7: case 8:  case 9: case 10:
                    return day >= 23 ? WesternZodiacs[month - 1] : WesternZodiacs[month - 2];
                default:
                    return day >= 22 ? WesternZodiacs[month - 1] : WesternZodiacs[month - 2];
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
