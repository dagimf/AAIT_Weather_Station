﻿using System;
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
        Thread automatedReceive;
        string output;
        public Form1()
        {
            InitializeComponent();
            receiveThread = new Thread(new ThreadStart(receiveMessage));
            receiveThread.Start();

            automatedReceive = new Thread(new ThreadStart(readSensors));
            automatedReceive.Start();
            msg.MessageChanged+=msg_MessageChanged;
        }

        private void readSensors()
        {
            while (true)
            {
                messageBroker.sendData("5", "Device.AAIT.4K");
                Thread.Sleep(1000);

            }
        }

        private void msg_MessageChanged(object sender, MessageChangedEventArgs e)
        {
            string[] message = e.newValue.Split('|');
            string[] parameters = message[0].Split(':');
            string routingKey = parameters[0];
            string cmd = parameters[1];
            string tempValue = "";
            string pressureValue = "";
            string lightValue = "";
            if (cmd.Contains('5')) 
            {
                string[] data = message[1].Split(':');
                foreach (string ms in data)
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
                SetTemp(tempValue);
                SetLight(lightValue);
                SetPressure(pressureValue);
            }
            output += e.newValue;
            
            SetText(output);
        }

        delegate void SetTextCallback(string text);
        delegate void SetTempCallback(string temp);
        delegate void SetLightCallback(string light);
        delegate void SetPressureCallback(string pressure);

        private void SetTemp(string temp)
        {
            if (this.temp_tbx.InvokeRequired)
            {
                SetTempCallback d = new SetTempCallback(SetTemp);
                this.Invoke(d, new object[] { temp });
            }
            else
            {
                this.temp_tbx.Text = temp;
            }
        }

        private void SetLight(string light)
        {
            if (this.light_tbx.InvokeRequired)
            {
                SetLightCallback d = new SetLightCallback(SetLight);
                this.Invoke(d, new object[] { light });
            }
            else
            {
                this.light_tbx.Text = light;
            }
        }

        private void SetPressure(string pressure)
        {
            if (this.press_tbx.InvokeRequired)
            {
                SetPressureCallback d = new SetPressureCallback(SetPressure);
                this.Invoke(d, new object[] { pressure });
            }
            else
            {
                this.press_tbx.Text = pressure;
            }
        }

        private void SetText(string text)
        {
          // InvokeRequired required compares the thread ID of the
          // calling thread to the thread ID of the creating thread.
          // If these threads are different, it returns true.
          if (this.data_display.InvokeRequired)
          { 
            SetTextCallback d = new SetTextCallback(SetText);
            this.Invoke(d, new object[] { text });
          }
          else
          {
            this.data_display.Text = text;
          }
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
