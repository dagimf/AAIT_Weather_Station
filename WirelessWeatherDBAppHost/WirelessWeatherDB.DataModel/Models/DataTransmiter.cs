using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WirelessWeatherDB.DataModel.Models
{
    public class DataTransmiter
    {
        [AutoIncrement]
        public int TransmiterId { get; set; }
        public string Location { get; set; }
        public string Name { get; set; }
    }
}
