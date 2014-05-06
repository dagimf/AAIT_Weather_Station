using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WirelessWeatherDB.DataModel.Operations;

namespace WirelessWeatherDB.DataInterface
{
    public interface IDataTransmiterRepository
    {
        DataTransmiterDTOResponse AddTransmiter(DataTransmiterDTO Transmiter);
        TransmiterDeviceResponse GetTransmiter(TransmiterDevice TransmiterDetail);
    }
}
