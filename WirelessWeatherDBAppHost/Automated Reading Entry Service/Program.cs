﻿using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automated_Reading_Entry_Service
{
    class Program
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "127.0.0.1" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare("topic_logs", "topic");
                    var queueName = channel.QueueDeclare();

                    if (args.Length < 1)
                    {
                        Console.Error.WriteLine("Usage: {0} [binding_key...]",
                                                Environment.GetCommandLineArgs()[0]);
                        Environment.ExitCode = 1;
                        return;
                    }

                    foreach (var bindingKey in args)
                    {
                        channel.QueueBind(queueName, "topic_logs", bindingKey);
                    }

                    Console.WriteLine(" [*] Waiting for messages. " +
                                      "To exit press CTRL+C");

                    var consumer = new QueueingBasicConsumer(channel);
                    channel.BasicConsume(queueName, true, consumer);

                    while (true)
                    {
                        var ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                        var routingKey = ea.RoutingKey;
                        Console.WriteLine(" [x] Received '{0}':'{1}'",
                                          routingKey, message);
                    }

                }

            }
        }
    }
}
