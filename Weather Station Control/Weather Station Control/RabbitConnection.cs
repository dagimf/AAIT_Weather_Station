using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Weather_Station_Control
{
    class RabbitConnection
    {
        public void sendData(string message, string routingTemp) 
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
        public void sendData(string message, string routingTemp, string server)
        {
            var factory = new ConnectionFactory() { HostName = server };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare("topic_logs", "topic");

                    var routingKey = routingTemp;
                    //var message = (args.Length > 1) ? string.Join(" ", args.Skip(1)
                    //                                                                .ToArray())
                    //                                             : "Hello World!";
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish("topic_logs", routingKey, null, body);
                    Console.WriteLine(" [x] Sent '{0}':'{1}'", routingKey, message);
                }
            }
        }
        public void sendData(string message, string routingTemp, string server, string exchange)
        {
            //chose the ipaddress for the RabbitMq service
            var factory = new ConnectionFactory() { HostName = server };
            //create a connection to the service
            using (var connection = factory.CreateConnection())
            {
                //open a channel of communincation with the service
                using (var channel = connection.CreateModel())
                {
                    //set the place of message exchange, and the type of exchange to topic                    
                    channel.ExchangeDeclare(exchange, "topic");
                    //set the routing key for the message
                    var routingKey = routingTemp;
                    // change the encoding of the message to make it safer to transfer
                    var body = Encoding.UTF8.GetBytes(message);
                    //publish the message to the specified exchange with the specified routing key
                    channel.BasicPublish("topic_logs", routingKey, null, body);
                }
            }
        }

        public string receiveData(string bindingKey) 
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare("topic_logs", "topic");
                    var queueName = channel.QueueDeclare();

                    //Commented out but should use when multiple binding is implemented
                    //foreach (var bindingKey in args)
                    //{
                     //   channel.QueueBind(queueName, "topic_logs", bindingKey);
                    //}
                    channel.QueueBind(queueName, "topic_logs", bindingKey);
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
                        string output = routingKey+":"+ message;
                        return output;
                    }
                }
            }
        }
        public string receiveData(string bindingKey, string server)
        {
            var factory = new ConnectionFactory() { HostName = server };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare("topic_logs", "topic");
                    var queueName = channel.QueueDeclare();

                    //Commented out but should use when multiple binding is implemented
                    //foreach (var bindingKey in args)
                    //{
                    //   channel.QueueBind(queueName, "topic_logs", bindingKey);
                    //}
                    channel.QueueBind(queueName, "topic_logs", bindingKey);
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
                        string output = routingKey + ":" + message;
                        return output;
                    }
                }
            }
        }
        public string receiveData(string bindingKey, string server, string exchange)
        {
            var factory = new ConnectionFactory() { HostName = server };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare( exchange , "topic");
                    var queueName = channel.QueueDeclare();

                    //Commented out but should use when multiple binding is implemented
                    //foreach (var bindingKey in args)
                    //{
                    //   channel.QueueBind(queueName, "topic_logs", bindingKey);
                    //}
                    channel.QueueBind(queueName, "topic_logs", bindingKey);
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
                        string output = routingKey + ":" + message;
                        return output;
                    }
                }
            }
        }


    }
}
