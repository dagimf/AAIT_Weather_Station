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
    [Route("/AddTransmiter")]
    public class DataTransmiterDTO : DataTransmiter
    {
    }

    public class DataTransmiterDTOResponse
    {
        public Guid Id { get; set; }
    }


    [Api("retreive raspberry Pi")]
    [Route("/GetTransmiter")]
    public class TransmiterDevice
    {
        public Guid Id { get; set; }
    }

    public class TransmiterDeviceResponse
    {
        public TransmiterDeviceResponse()
        {
            this.Device = new DataTransmiter();
        }
        public DataTransmiter Device { get; set; }
    }

}
