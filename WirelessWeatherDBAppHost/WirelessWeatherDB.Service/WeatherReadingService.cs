using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WirelessWeatherDB.DataInterface;
using WirelessWeatherDB.DataModel.Operations;

namespace WirelessWeatherDB.Service
{
    public class WeatherReadingService : ServiceStack.ServiceInterface.Service
    {
        public IWeatherReadingRepository WeatherReadingRepository { get; set; }

        public WeatherReadingDTOResponse Post(WeatherReadingDTO Request)
        {
            var Response = WeatherReadingRepository.AddReading(Request);
            return Response;
        }
        public WeatherResponse Get(Weather WeatherDetail)
        {
            var Response = WeatherReadingRepository.GetReading(WeatherDetail);
            return Response;
        }
    }
}
