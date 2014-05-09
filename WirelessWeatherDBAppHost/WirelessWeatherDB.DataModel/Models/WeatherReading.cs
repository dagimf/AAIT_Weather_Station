using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WirelessWeatherDB.DataModel.Models
{
    public class WeatherReading
    {
        //public Guid ID { get; set; }
        public double Temprature { get; set; }
        public double Light { get; set; }
        public double Pressure { get; set; }

        [References (typeof(DataCollector))]
        public int CollectorId { get; set; }
        public DateTime Time { get; set; }
    }
}
