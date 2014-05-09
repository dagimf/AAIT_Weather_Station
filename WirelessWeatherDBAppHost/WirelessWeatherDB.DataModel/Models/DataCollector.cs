using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WirelessWeatherDB.DataModel.Models
{
    public class DataCollector
    {
        [AutoIncrement]
        public int CollectorId { get; set; }
        [References(typeof(DataTransmiter))]
        public int TransmiterId { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
    }
}
