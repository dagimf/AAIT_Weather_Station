using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using WirelessWeatherDB.DataModel.Models;

namespace WirelessWeatherDBAppHost
{
    
    public class WeatherDataHub : Hub
    {
        public void UpdateData(WeatherReading updatedData)
        {
            Clients.All.updateData(updatedData);
        }
    }
}