using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WirelessWeatherDB.DataModel.Models;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceHost;

namespace WirelessWeatherDB.DataModel.Operations
{


    /// <summary>
    /// The code below are used to Add current weather data to the DB
    /// </summary>
    [Api("Get weather information")]
    [Route("/SubmitReading")]
    public class WeatherReadingDTO  : WeatherReading
    {
    }

    public class WeatherReadingDTOResponse
    {
        public int Id { get; set; }
    }


    /// <summary>
    /// The code below are used to retrevie current weather data from the DB 
    /// </summary>

    [Api("Get weather information based on collectorID or location")]
    [Route("/ReadWeather")]
    public class Weather
    {
        public int Id { get; set; }
    }

    public class WeatherResponse
    {
        public WeatherResponse()
        {
            this.Weather = new WeatherReading();
        }
        public WeatherReading Weather { get; set; }
    }

}
