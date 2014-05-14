using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WirelessWeatherDB.DataModel.Models;
using WirelessWeatherDB.DataModel.Operations;

namespace WirelessWeatherDB.DataInterface
{
    public interface IDataCollectorRepository
    {
        DataCollectorDTOResponse AddCollector(DataCollectorDTO Collector);
        DataCollector GetCollector(CollectorDevice CollectorDetail);
    }
}
