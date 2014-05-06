using Funq;
using ServiceStack.OrmLite;
using ServiceStack.WebHost.Endpoints;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using WirelessWeatherDB.DataContex;
using WirelessWeatherDB.DataInterface;
using WirelessWeatherDB.DataModel.Models;
using WirelessWeatherDB.Service;

namespace WirelessWeatherDBAppHost
{
    public class Global : System.Web.HttpApplication
    {
        public class WeatherAPIAppHost : AppHostBase
        {

            public WeatherAPIAppHost() : base("Weather API", typeof(DataCollectorService).Assembly) { }

            public override void Configure(Container container)
            {

                //SetConfig(new EndpointHostConfig
                //{
                //    DefaultRedirectPath = "/home.html",
                //});
                container.Register<IDbConnectionFactory>(
                                     new OrmLiteConnectionFactory(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(), SqlServerDialect.Provider));

                container.Register<IWeatherReadingRepository>(c => new WeatherReadingRepository(c.Resolve<IDbConnectionFactory>()));
                container.Register<IDataTransmiterRepository>(c => new DataTransmiterRepository(c.Resolve<IDbConnectionFactory>()));
                container.Register<IDataCollectorRepository>(c => new  DataCollectorRepository (c.Resolve<IDbConnectionFactory>()));

            }



        }
        protected void Application_Start(object sender, EventArgs e)
        {
            new WeatherAPIAppHost().Init();

            var connection = new OrmLiteConnectionFactory(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(), SqlServerDialect.Provider);

            using (var dbcon = connection.OpenDbConnection())
            {
                dbcon.CreateTable<DataTransmiter>();               
                dbcon.CreateTable<DataCollector>();
                dbcon.CreateTable<WeatherReading>();
               

            }

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}