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
            DataTransmiter.Location = Transmiter.Location;
            DataTransmiter.Name = Transmiter.Name;


            using (var dbcon = DbConnectionFactory.OpenDbConnection())
            {
                dbcon.Insert<DataTransmiter>(DataTransmiter);
            }
            return new DataTransmiterDTOResponse { Id = DataTransmiter.TransmiterId };
        }

        public TransmiterDeviceResponse GetTransmiter(TransmiterDevice TransmiterDetail)
        {
            DataTransmiter Transmiter;
            using (var dbcon = DbConnectionFactory.OpenDbConnection())
            {
                Transmiter = dbcon.QueryById<DataTransmiter>(TransmiterDetail.Id);
            }
            return new TransmiterDeviceResponse { Device = Transmiter };
        }
    }
}
