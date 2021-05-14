using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Model;

namespace WeatherApp.ViewModel
{
    public class WeatherApi
    {
        public const string API_KEY = "85cc30a15fb710c78a4cb1d02e9298f2";
        public const string BASE_URL = "https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}";

        public Weatherinformation GetWeatherinformation(string cityName)
        {
            Weatherinformation result = new Weatherinformation();

            //{}이 기호 사이에 있는 곳을 포멧팅 하는데 Format(어디, 첫번째, 두번째)
            string url = string.Format(BASE_URL, cityName, API_KEY);

            //괄호 안 객체 -> 나오면서 없어지면서 어떤 메소드를 호출한다
            //dispose메소드인데 안에 객체를 사용하고 잘 파기 시켜줘야하는 경우 사용
            using(HttpClient client = new HttpClient())
            {
                //server에서 데이터를 달라고 요청(GetAsync()) -> 서버에서 응답이 날라옴
                var response = client.GetAsync(url);
                //날라온 결과를 string으로 변환
                string json = response.Result.Content.ReadAsStringAsync().Result;

                //string과 class가 있을때 string을 이 클래스의 프로퍼티로 자동으로 변환해주는 JsonConvert.DeserializeObject<type>(string)
                result = JsonConvert.DeserializeObject<Weatherinformation>(json);
            }
            return result;
        }
    }
}
