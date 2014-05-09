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
            WeatherReading currentReading = new WeatherReading();
            currentReading.CollectorId = Weather.CollectorId;
            currentReading.Light = Weather.Light;
            currentReading.Pressure = Weather.Pressure;
            currentReading.Time = DateTime.UtcNow;
            currentReading.Temprature = Weather.Temprature;

            using (var dbCon = DbConnectionFactory.OpenDbConnection())
            {
                dbCon.Insert<WeatherReading>(currentReading);
            }
            return new WeatherReadingDTOResponse { Id = currentReading.CollectorId };

        }

        public WeatherResponse GetReading(Weather WeatherDetail)
        {
            WeatherReading Weather;
            using (var dbCon = DbConnectionFactory.OpenDbConnection())
            {
                Weather = dbCon.QueryById<WeatherReading>(WeatherDetail.Id);
            }
            return new WeatherResponse { Weather = Weather };
        }
    }
}
