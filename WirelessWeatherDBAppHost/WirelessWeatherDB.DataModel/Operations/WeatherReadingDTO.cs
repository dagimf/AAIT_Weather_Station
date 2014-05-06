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
        public Guid Id { get; set; }
    }


    /// <summary>
    /// The code below are used to retrevie current weather data from the DB 
    /// </summary>

    [Api("Get weather information")]
    [Route("/ReadWeather")]
    public class Weather
    {
        public Guid Id { get; set; }
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
