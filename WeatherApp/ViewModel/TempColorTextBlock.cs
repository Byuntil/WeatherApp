using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WeatherApp.Model;

namespace WeatherApp.ViewModel
{
    class TempColorTextBlock:TextBlock
    {
        public string TempBlock
        {
            get { return (string)GetValue(TempBlockProperty); }
            set { SetValue(TempBlockProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TempBlock.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TempBlockProperty =
            DependencyProperty.Register("TempBlock", typeof(string), typeof(TempColorTextBlock), new PropertyMetadata(null, new PropertyChangedCallback(FontColorChange)));

        private static void FontColorChange(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            TempColorTextBlock tempColorTextBlock = source as TempColorTextBlock;
            string str = tempColorTextBlock.TempBlock;
            string tmp = Regex.Replace(str, "[ ,°,C]",string.Empty);
            int currentTemp;
            if (Int32.TryParse(tmp, out currentTemp))
            {
                if (currentTemp <= 20)
                {
                    tempColorTextBlock.Foreground = System.Windows.Media.Brushes.Blue;
                }
                else
                {
                    tempColorTextBlock.Foreground = System.Windows.Media.Brushes.Red;
                }
            }
            
        }
    }
}
