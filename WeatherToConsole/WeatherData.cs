using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeatherToConsole
{
    public class WeatherData
    {
        [JsonPropertyName("current")]
        public CurrentWeather Current { get; set; }
        [JsonPropertyName("daily")]
        public List<FutureWeather> DailyPredictions { get; set; }

    }

    public class CurrentWeather
    {
        [JsonPropertyName("temp")]
        public double Temperature { get; set; }
        [JsonPropertyName("weather")]
        public List<Weather> WeatherDescription { get; set; }
    }

    public class FutureWeather
    {
        [JsonPropertyName("temp")]
        public Temperature FutureTemp { get; set; }
        [JsonPropertyName("weather")]
        public List<Weather> FutureWeatherDescription { get; set; }
    }
    
    public class Weather
    {
        [JsonPropertyName("description")]
        public string WeatherDescription { get; set; }
    }

    public class Temperature
    {
        [JsonPropertyName("min")]
        public double MinTemp { get; set; }
        [JsonPropertyName("max")]
        public double MaxTemp { get; set; }
    }
}
