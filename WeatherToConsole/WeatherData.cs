using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherToConsole
{
    public class WeatherData
    {
        public CurrentWeather current { get; set; }
        public List<FutureWeather> daily { get; set; }

    }

    public class CurrentWeather
    {
        public double temp { get; set; }
        public List<Weather> weather { get; set; }
    }

    public class FutureWeather
    {
        public Temperature temp { get; set; }
        public List<Weather> weather { get; set; }
    }
    
    public class Weather
    {
        public string description { get; set; }
    }

    public class Temperature
    {
        public double min { get; set; }
        public double max { get; set; }
    }
}
