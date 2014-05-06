using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WirelessWeatherDB.DataModel.Operations;

namespace WirelessWeatherDB.DataInterface
{
    public interface IWeatherReadingRepository
    {
        WeatherReadingDTOResponse AddReading (WeatherReadingDTO Weather);
        WeatherResponse GetReading(Weather WeatherDetail);
    }
}
