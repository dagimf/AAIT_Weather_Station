using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomatedTransmiterRequest
{
    class Program
    {
        public static void Main(string[] args)
        {

            Thread automatedReceive;
            automatedReceive = new Thread(new ThreadStart(readSensors));
            automatedReceive.Start();
        }

        private static void readSensors()
        {

            sendData("4", "Device.3.1");
            while (true)
            {
                sendData("5", "Device.3.1");
                Thread.Sleep(1000);

            }
        }


        public static void sendData(string message, string routingTemp)
        {

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    //The channel to send the message to and the type of message is set
                    channel.ExchangeDeclare("topic_logs", "topic");
                    // Routing Key is Set
                    var routingKey = routingTemp;
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish("topic_logs", routingKey, null, body);
                    Console.WriteLine(" [x] Sent '{0}':'{1}'", routingKey, message);
                }
            }
        }
    }
}
