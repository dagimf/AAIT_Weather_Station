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
    public class DataTransmiterRepository : IDataTransmiterRepository
    {
        public IDbConnectionFactory DbConnectionFactory { get; set; }
        public IDbConnection IdbConnection { get; set; }

        public DataTransmiterRepository(IDbConnectionFactory _IDbConnectionFactory)
        {
            this.DbConnectionFactory = _IDbConnectionFactory;
        }

        public DataTransmiterDTOResponse AddTransmiter(DataTransmiterDTO Transmiter)
        {
            DataTransmiter DataTransmiter = new DataTransmiter();
            DataTransmiter.Id = Transmiter.Id;
            DataTransmiter.Location = Transmiter.Location;
            DataTransmiter.Name = Transmiter.Name;


            using (IdbConnection = DbConnectionFactory.CreateDbConnection())
            {
                IdbConnection.Insert<DataTransmiter>();
            }
            return new DataTransmiterDTOResponse { Id = DataTransmiter.Id };
        }

        public TransmiterDeviceResponse GetTransmiter(TransmiterDevice TransmiterDetail)
        {
            DataTransmiter Transmiter;
            using (IdbConnection = DbConnectionFactory.CreateDbConnection())
            {
                Transmiter = IdbConnection.QueryById<DataTransmiter>(TransmiterDetail.Id);
            }
            return new TransmiterDeviceResponse { Device = Transmiter};
        }
    }
}
