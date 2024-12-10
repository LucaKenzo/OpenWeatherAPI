using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using OpenWeatherAPI.Models;
using OpenWeatherAPI.Services;

namespace OpenWeatherAPI.ViewModels
{
    public class OpenWeatherViewModel : INotifyPropertyChanged
    {
        private readonly OpenWeatherService _weatherService;
        private WeatherResponse _currentWeather;
        private ObservableCollection<DailyForecast> _dailyForecasts;

        public event PropertyChangedEventHandler PropertyChanged;

        public WeatherResponse CurrentWeather
        {
            get => _currentWeather;
            set
            {
                _currentWeather = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<DailyForecast> DailyForecasts
        {
            get => _dailyForecasts;
            set
            {
                _dailyForecasts = value;
                OnPropertyChanged();
            }
        }

        public OpenWeatherViewModel()
        {
            _weatherService = new OpenWeatherService();
            DailyForecasts = new ObservableCollection<DailyForecast>();
        }

        public async Task LoadWeatherAsync(string city)
        {
            CurrentWeather = await _weatherService.GetWeather(city);
        }

        public async Task LoadForecastAsync(double latitude, double longitude)
        {
            var forecast = await _weatherService.Get5DayForecast(latitude, longitude);
            if (forecast != null)
            {
                DailyForecasts.Clear();
                foreach (var daily in forecast)
                {
                    DailyForecasts.Add(daily);
                }
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
