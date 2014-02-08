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
        RabbitMQMessage msg = new RabbitMQMessage();
        RabbitConnection messageBroker = new RabbitConnection();
        Thread receiveThread;
        string output;
        public Form1()
        {
            InitializeComponent();
            receiveThread = new Thread(new ThreadStart(receiveMessage));
            receiveThread.Start();
            msg.MessageChanged+=msg_MessageChanged;
        }

        private void msg_MessageChanged(object sender, MessageChangedEventArgs e)
        {
            output += e.newValue;
        }

        private void receiveMessage()
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
                        msg.Message = routingKey + ":" + message;
                    }
                }
            }
        }
        

        private void clear_btn_Click(object sender, EventArgs e)
        {
            data_display.Text = "";
        }

        private void send_btn_Click(object sender, EventArgs e)
        {
            if (cmd_dev_status.Checked) 
            {
                messageBroker.sendData("1", "Device.AAIT.4K");
            }

            else if (cmd_recv_data.Checked) 
            {
                messageBroker.sendData("5", "Device.AAIT.4K");
            }
        }

        private void updateData_Click(object sender, EventArgs e)
        {
            data_display.Text = output;
        }

        private void change_state_btn_Click(object sender, EventArgs e)
        {
            int state = 0;
            if (temprature_CB.Checked) 
            {
                state += 4 ;
            }
            if (light_CB.Checked)
            {
                state += 2;
            }
            if (pressure_CB.Checked)
            {
                state += 1;
            }
            messageBroker.sendData("2"+state , "Device.AAIT.4K");
           
        }
    }
}
