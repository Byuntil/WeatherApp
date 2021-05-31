using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WeatherApp.ViewModel.Command
{
    public class RefreshCommand : ICommand //날씨를 갱신 다시 API에 요청을 보내는
    {
        public WeatherVM VM { get; set; }

        public event EventHandler CanExecuteChanged;


        public RefreshCommand(WeatherVM vm)
        {
            VM = vm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter.ToString() == "")
            {
                VM.GetWeather();
            }
            else
            {
                VM.Cities.Add(parameter.ToString());
                VM.SelectedCity = parameter.ToString();
            }
            
        }
    }
}
