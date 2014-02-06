using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Weather_Station_Control
{
    public partial class Form1 : Form
    {

        RabbitConnection messageBroker = new RabbitConnection();
        Thread receiveThread;
        public Form1()
        {
            InitializeComponent();
            receiveThread = new Thread(new ThreadStart(receiveMessage));
            receiveThread.Start();
        }

        private void receiveMessage()
        {
            string output;
            output.
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
                    channel.QueueBind(queueName, "topic_logs", "Control.*.*");
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
                        output = routingKey + ":" + message;
                    }
                }
            }
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {

        }

        private void send_btn_Click(object sender, EventArgs e)
        {
            if (cmd_dev_status.Checked) 
            {
                messageBroker.sendData("1", "Device.AAIT.4K");
            }
        }
    }
}
