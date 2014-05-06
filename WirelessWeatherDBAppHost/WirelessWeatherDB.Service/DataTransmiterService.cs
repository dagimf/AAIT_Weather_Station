using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WirelessWeatherDB.DataModel.Operations;
using WirelessWeatherDB.DataInterface;

namespace WirelessWeatherDB.Service
{
    public class DataTransmiterService : ServiceStack.ServiceInterface.Service
    {
        public IDataTransmiterRepository DataTransmiterRepository { get; set; }

        public DataTransmiterDTOResponse Post(DataTransmiterDTO Request)
        {
            var Response = DataTransmiterRepository.AddTransmiter(Request);
            return Response;
        }
        public TransmiterDeviceResponse Get(TransmiterDevice Request)
        {
            var Response = DataTransmiterRepository.GetTransmiter(Request);
            return Response;
        }
    }
}
