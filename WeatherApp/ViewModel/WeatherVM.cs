using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Model;
using WeatherApp.ViewModel.Command;

namespace WeatherApp.ViewModel
{
    public class WeatherVM
    {
        public Weatherinformation Weather { get; set; } // Api result를 받아오는  녀석
        public ObservableCollection<string> Cities { get; set; }

        private string selectedCity; //ListView에서 선택된 나라가 저장

        public string SelectedCity
        {
            get { return selectedCity; }
            set { selectedCity = value;
                GetWeather();
            }
        }

        //Command
        public RefreshCommand RefreshCommand { get; set; }


        public WeatherVM()
        {
            Weather = new Weatherinformation();
            Cities = new ObservableCollection<string>();
            Cities.Add("London");
            Cities.Add("Paris");
            Cities.Add("Jeonju");
            Cities.Add("Seoul");

            RefreshCommand = new RefreshCommand(this); //xaml Button에서 바인딩 시킬때 RefreshCommand를 사용하기 위해 이미 되어있는 vm에 생성자에서 호출
        }
        
        public void GetWeather()
        {
            
            if(selectedCity != null)
            {
                var weather = WeatherApi.GetWeatherinformation(SelectedCity);
                Weather.Name = weather.Name;
                Weather.Main = weather.Main;
                Weather.Wind = weather.Wind;
            }  
        }
    }
}
