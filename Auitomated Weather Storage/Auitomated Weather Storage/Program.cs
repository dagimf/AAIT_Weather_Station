using System;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using ServiceStack.ServiceClient.Web;
using WirelessWeatherDB.DataModel.Operations;
using WirelessWeatherDB.DataModel.Models;
using Microsoft.AspNet.SignalR.Client;

namespace Aytomated_Weather_Storage
{
    class Program
    {
        public static void Main(string[] args)
        {

            //string bindingKey = "Control.*.*";
            //var factory = new ConnectionFactory() { HostName = "127.0.0.1" };
            //using (var connection = factory.CreateConnection())
            //{
            //    using (var channel = connection.CreateModel())
            //    {
            //        channel.ExchangeDeclare("topic_logs", "topic");
            //        var queueName = channel.QueueDeclare();
            //        channel.QueueBind(queueName, "topic_logs", bindingKey);

            //        Console.WriteLine(" [*] Waiting for messages. " +
            //                          "To exit press CTRL+C");

            //        var consumer = new QueueingBasicConsumer(channel);
            //        channel.BasicConsume(queueName, true, consumer);

            //        while (true)
            //        {
            //            var ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();
            //            var body = ea.Body;
            //            var message = Encoding.UTF8.GetString(body);
            //            var routingKey = ea.RoutingKey;
            //            Console.WriteLine(" [x] Received {0} : {1}",
            //                              routingKey, message);

            //            storeReading(message, routingKey);
            //            //storeTransmiter(message, routingKey);
            //            //StoreCollector(message);
            //            //readTransimter(message);
            //        }

            //    }

            //}

            updateData();

        }

        public static string storeReading(string message, string routingKey)
        {
            message = message.Split('\r')[0];
            string[] parametersnew = message.Split('|');
            string[] parameters = parametersnew[1].Split(':');
            //must change this to get the id from the routing key
            Guid id = Guid.NewGuid();
            string cmd = parameters[1];
            string tempValue = "";
            string pressureValue = "";
            string lightValue = "";
            //This has to be changed so that it gets the id from  the routing key
            int CollectorId = int.Parse( routingKey.Split('.')[2]);;
            //if (cmd.Contains("5"))
            //{
            string[] data = message.Split(':');
            foreach (string ms in parameters)
            {
                string[] records = ms.Split('=');
                if (records[0].Contains("Temp"))
                {
                    tempValue = records[1];
                }
                else if (records[0].Contains("Light"))
                {
                    lightValue = records[1];
                }
                else if (records[0].Contains("Presure"))
                {
                    pressureValue = records[1];
                }
            }
            //}

            var client = new JsonServiceClient("http://localhost:57175/");
            var response = client.Send<WeatherReading>(new WeatherReadingDTO
            {
                Light = double.Parse(lightValue),
                Pressure = double.Parse(pressureValue),
                Temprature = double.Parse(tempValue),
                CollectorId = CollectorId
            });

            return response.ToString();
        }

        public static string storeTransmiter(string message, string routingKey)
        {
            string[] parameters = message.Split(':');
            //must change this to get the id from the routing key
            string Name = parameters[0];
            string Location = parameters[1];


            var client = new JsonServiceClient("http://localhost:57175/");
            var response = client.Send<DataTransmiter>(new DataTransmiterDTO {Location = Location, Name = Name });

            return response.ToString();
        }

        public static string StoreCollector(String message) 
        {
            string[] parameters = message.Split(':');
            string Status = parameters[0];
            string Location = parameters[1];
            int TransmiterId = int.Parse(parameters[2]);

            var client = new JsonServiceClient("http://localhost:57175/");
            var response = client.Send<DataTransmiter>(new DataCollectorDTO { TransmiterId=TransmiterId, Location=Location, Status=Status });


            return response.TransmiterId.ToString();
        }

        public static DataTransmiter readTransimter(string message)
        {
            var client = new JsonServiceClient("http://localhost:57175/");
            var response = client.Get<DataTransmiter>(message);
            return response;
        }

        public static void updateData ()
        {
            var hubConnection = new HubConnection("http://localhost:57175/");
            IHubProxy WeatherDataHubProxy = hubConnection.CreateHubProxy("WeatherDataHub");
            WeatherDataHubProxy.On<WeatherReading>("UpdateStockPrice", WeatherReading => Console.WriteLine("Stock update for {0} new price", WeatherReading.Temprature));
            hubConnection.Start().Wait();
            WeatherReading weather = new WeatherReading(); 
            WeatherDataHubProxy.Invoke("UpdateData", weather);

        }

    }
}
