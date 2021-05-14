using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Model
{
    

    public class Main : INotifyPropertyChanged //온도가 바뀌었을때의 신호를 보내기 위해 INotifyPropertyChanged구현
    {
        private double temp;

        public double Temp
        {
            get { return temp; }
            set { temp = value; OnPropertyChanged(nameof(Temp));} //C#의 강력한 기능중 하나로 유연성이 올라감 자동으로 형식, 멤버, 변수의 타입을 알려줌, 런타임에 멤버추가 가능
        }

        private int humidity;

        public int Humidity
        {
            get { return humidity; }
            set { humidity = value; OnPropertyChanged(nameof(Temp)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (propertyName != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }

    public class Wind :INotifyPropertyChanged
    {
        private double speed;

        public double Speed
        {
            get { return speed; }
            set { speed = value; OnPropertyChanged(nameof(Speed)); } //C#의 강력한 기능중 하나로 유연성이 올라감 자동으로 형식, 멤버, 변수의 타입을 알려줌, 런타임에 멤버추가 가능
        }

        private int deg;

        public int Deg
        {
            get { return deg; }
            set { deg = value; OnPropertyChanged(nameof(Deg)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (propertyName != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }


    public class Weatherinformation : INotifyPropertyChanged
    {
        private Main main;
        public Main Main
        {
            get
            {
                return main;
            }
            set
            {
                main = value;
                OnPropertyChanged("Main");
            }
        }
        private Wind wind;

        public Wind Wind
        {
            get { return wind; }
            set { wind = value; OnPropertyChanged("Wind"); }
        }

        private String name;

        public String Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if(propertyName != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
