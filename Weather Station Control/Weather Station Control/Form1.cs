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

            messageBroker.sendData("1", "Device.Rasp1.Ardu1");
        }

        private void readSensors()
        {
            while (true)
            {
                messageBroker.sendData("5", "Device.Rasp1.Ardu1");
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
                        tempValue = records[1] + " Celcius";
                    }
                    else if (records[0].Contains("Light"))
                    {
                        lightValue = records[1] + " %";
                    }
                    else if (records[0].Contains("Presure"))
                    {
                        pressureValue = records[1] + " KPa";
                    }
                }
                SetTemp(tempValue);
                SetLight(lightValue );
                SetPressure(pressureValue );
            }
            if (cmd.Contains('1')) 
            {
                string[] data = message[1].Split(':');
                SetTempState(data[0]);
                SetLightState(data[1]);
                SetPressureState(data[2]);
            }
            output += e.newValue;
            
            SetText(output);
        }
        //For the state changes
        delegate void SetTempStateCallback(string temp);
        delegate void SetLightStateCallback(string light);
        delegate void SetPressureStateCallback(string pressure);

        //for reading value
        delegate void SetTextCallback(string text);
        delegate void SetTempCallback(string temp);
        delegate void SetLightCallback(string light);
        delegate void SetPressureCallback(string pressure);

        private void SetTempState(string temp)
        {
            if (this.tempState_tb.InvokeRequired)
            {
                SetTempStateCallback d = new SetTempStateCallback(SetTempState);
                this.Invoke(d, new object[] { temp });
            }
            else
            {
                this.tempState_tb.Text = temp;
            }
        }

        private void SetLightState(string light)
        {
            if (this.lightState_tb.InvokeRequired)
            {
                SetLightStateCallback d = new SetLightStateCallback(SetLightState);
                this.Invoke(d, new object[] { light });
            }
            else
            {
                this.lightState_tb.Text = light;
            }
        }

        private void SetPressureState(string pressure)
        {
            if (this.pressureState_tb.InvokeRequired)
            {
                SetPressureStateCallback d = new SetPressureStateCallback(SetPressureState);
                this.Invoke(d, new object[] { pressure });
            }
            else
            {
                this.pressureState_tb.Text = pressure;
            }
        }

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
            // Create a connection between the RabbitMQ service located at the given location
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    //set the exchange name and type to listen to
                    channel.ExchangeDeclare("topic_logs", "topic");
                    //create a temproary and random que to store the message recived from the exchane
                    var queueName = channel.QueueDeclare();
                    // bind the exchange and routing key to the random que created
                    channel.QueueBind(queueName, "topic_logs", "Control.*.*");
                    Console.WriteLine(" [*] Waiting for messages. " +
                                      "To exit press CTRL+C");
                    // create a consumer which can read the messages from the que
                    var consumer = new QueueingBasicConsumer(channel);
                    //assign the consumer to the random que
                    channel.BasicConsume(queueName, true, consumer);
                    // continuosly loop and recive message from the exchange
                    while (true)
                    {
                        //created whenever a mmessage is recived
                        var ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();
                        // retrieve the message that was sent
                        var body = ea.Body;
                        // Decode the message
                        var message = Encoding.UTF8.GetString(body);
                        //retrieve the routing key of the sender
                        var routingKey = ea.RoutingKey;
                        Console.WriteLine(" [x] Received '{0}':'{1}'",
                                          routingKey, message);
                        //stor the recived data
                        msg.Message = routingKey + ":" + message;
                    }
                }
            }
        }


        private void updateData_Click(object sender, EventArgs e)
        {
            data_display.Text = output;
        }

        private void change_state_btn_Click(object sender, EventArgs e)
        {
            int state = 0;
            tempState_tb.Text = "OFF";
            lightState_tb.Text = "OFF";
            pressureState_tb.Text = "OFF";
            if (temprature_CB.Checked) 
            {
                state += 4 ;
                tempState_tb.Text = "ON";
            }
            if (light_CB.Checked)
            {
                state += 2;
                lightState_tb.Text = "ON";
            }
            if (pressure_CB.Checked)
            {
                lightState_tb.Text = "ON";
                state += 1;
            }
            messageBroker.sendData("2"+state , "Device.Rasp1.Ardu1");
           
        }


        private void startSensorState_btn_Click(object sender, EventArgs e)
        {

            tempState_tb.Text = "ON";
            lightState_tb.Text = "ON";
            pressureState_tb.Text = "ON";
            messageBroker.sendData("4", "Device.Rasp1.Ardu1");
        }

        private void stopSensor_btn_Click(object sender, EventArgs e)
        {
            tempState_tb.Text = "OFF";
            lightState_tb.Text = "OFF";
            pressureState_tb.Text = "OFF";
            messageBroker.sendData("3", "Device.Rasp1.Ardu1");
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            output = "";
            data_display.Text = "";
        }
    }
}
