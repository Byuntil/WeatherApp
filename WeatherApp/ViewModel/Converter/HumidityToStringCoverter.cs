using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WeatherApp.ViewModel.Converter
{
    public class HumidityToStringCoverter : IValueConverter //숫자를 높음 낮음 으로 바꾸는 역활
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) //value = 습도
        {
            int humidityValue = (int)value; //converter 쓰는 데가 TextBlock의 humidity부분인데 애초에 int로 넘어오니까 명시만 해주면 끝
            if(humidityValue < 30)
            {
                return "습도 : 낮다";
            }
            if(humidityValue < 40)
            {
                return "습도 : 보통";
            }
            return "습도 : 높음";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return 0;
        }
    }
}
