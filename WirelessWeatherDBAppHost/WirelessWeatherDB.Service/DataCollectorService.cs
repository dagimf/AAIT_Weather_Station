using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WirelessWeatherDB.DataModel.Operations;
using WirelessWeatherDB.DataInterface;
using ServiceStack;
using ServiceStack.ServiceInterface;
using WirelessWeatherDB.DataModel.Models;


namespace WirelessWeatherDB.Service
{
    public class DataCollectorService : ServiceStack.ServiceInterface.Service
    {
        public IDataCollectorRepository DataCollectorRepository { get; set; }

        public DataCollectorDTOResponse Post(DataCollectorDTO Request)
        {
            var Response = DataCollectorRepository.AddCollector(Request);
            return Response;
        }

        public DataCollector Get(CollectorDevice Request)
        {
            var Response = DataCollectorRepository.GetCollector(Request);
            return Response;
        }

    }
}
