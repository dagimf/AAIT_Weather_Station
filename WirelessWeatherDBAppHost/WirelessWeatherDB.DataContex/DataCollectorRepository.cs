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
    public class DataCollectorRepository : IDataCollectorRepository
    {
        public IDbConnectionFactory DbConnectionFactory { get; set; }
        public IDbConnection IdbConnection { get; set; }

        public DataCollectorRepository(IDbConnectionFactory _IDbConnectionFactory)
        {
            this.DbConnectionFactory = _IDbConnectionFactory;
        }

        public DataCollectorDTOResponse AddCollector(DataCollectorDTO Collector)
        {
            DataCollector DataCollector = new DataCollector();
            DataCollector.Id = Collector.Id;
            DataCollector.Location = Collector.Location;
            DataCollector.TransmitterId= Collector.TransmitterId;
            DataCollector.Status = Collector.Status;


            using (var dbCon = DbConnectionFactory.OpenDbConnection())
            {
                dbCon.Insert<DataCollector>(DataCollector);
            }
            return new DataCollectorDTOResponse { Id = DataCollector.Id };
        }

        public CollectorDeviceResponse GetCollector(CollectorDevice CollectorDetail)
        {
            DataCollector Collector;
            using (var dbCon = DbConnectionFactory.OpenDbConnection())
            {
                Collector = dbCon.QueryById<DataCollector>(CollectorDetail.Id);
            }
            return new CollectorDeviceResponse { Device = Collector };
        }
    }
}
