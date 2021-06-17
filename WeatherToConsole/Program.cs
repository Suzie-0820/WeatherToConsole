using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace WeatherToConsole
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        private static async Task ProcessRepositories()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(
                //new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            //client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

           
            var streamTask = client.GetStreamAsync("https://api.openweathermap.org/data/2.5/onecall?lat=57.69&lon=12.70&exclude=minutely,hourly&appid=802001628e1fa2b9977a685f54f04f1b&units=metric");
            var weatherdata = await JsonSerializer.DeserializeAsync<WeatherData>(await streamTask);
            
            Console.WriteLine($"The weather today is {weatherdata.Current.WeatherDescription[0].WeatherDescription} with a temperature of {weatherdata.Current.Temperature}");
            Console.WriteLine("The weather the next 7 days will be: ");

            for (int i =0; i<weatherdata.DailyPredictions.Count; i++)
            {
                Console.WriteLine($"Day {i + 1}: ");
                Console.WriteLine($"Weather: {weatherdata.DailyPredictions[i].FutureWeatherDescription[0].WeatherDescription} with a min of {weatherdata.DailyPredictions[i].FutureTemp.MinTemp} celsius and a high of {weatherdata.DailyPredictions[i].FutureTemp.MaxTemp} celsius");
            }
               
        }

        static async Task Main(string[] args)
        {
            await ProcessRepositories();
        }
    }
}
