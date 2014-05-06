using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WirelessWeatherDB.DataModel.Models;

namespace WirelessWeatherDB.DataModel.Operations
{
    [Api("Register new raspberry Pi")]
    [Route("/AddCollector")]
    public class DataCollectorDTO : DataCollector
    {
    }

    public class DataCollectorDTOResponse 
    {
        public Guid Id { get; set; }
    }


    [Api("retreive raspberry Pi")]
    [Route("/GetCollector")]
    public class CollectorDevice 
    {
        public Guid Id { get; set; }
    }

    public class CollectorDeviceResponse 
    {
        public CollectorDeviceResponse() 
        {
            this.Device = new DataCollector();
        }
        public DataCollector Device { get; set; }
    }

}
