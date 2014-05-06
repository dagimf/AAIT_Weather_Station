using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.OrmLite;
using System.Data;
using WirelessWeatherDB.DataInterface;
using WirelessWeatherDB.DataModel.Operations;
using WirelessWeatherDB.DataModel.Models;

namespace WirelessWeatherDB.DataContex
{
    public class WeatherReadingRepository : IWeatherReadingRepository
    {
        public IDbConnectionFactory DbConnectionFactory { get; set; }
        public IDbConnection IdbConnection { get; set; }

        public WeatherReadingRepository(IDbConnectionFactory _IDbConnectionFactory) 
        {
            this.DbConnectionFactory = _IDbConnectionFactory;
        }

        public WeatherReadingDTOResponse AddReading(WeatherReadingDTO Weather)
        {
            WeatherReading WeatherReading = new WeatherReading();
            WeatherReading.ID = Guid.NewGuid();
            WeatherReading.CollectorId = Weather.CollectorId;
            WeatherReading.Light = Weather.Light;
            WeatherReading.Pressure = Weather.Pressure;
            WeatherReading.Time = Weather.Time;

            using (IdbConnection = DbConnectionFactory.CreateDbConnection())
            {
                IdbConnection.Insert<WeatherReading>();
            }
            return new WeatherReadingDTOResponse { Id=  WeatherReading.ID};

        }

        public WeatherResponse GetReading(Weather WeatherDetail)
        {
            WeatherReading Weather;
            using (IdbConnection = DbConnectionFactory.CreateDbConnection())
            {
                Weather = IdbConnection.QueryById<WeatherReading>(WeatherDetail.Id);
            }
            return new WeatherResponse { Weather = Weather };
        }
    }
}
