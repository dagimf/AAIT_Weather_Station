using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_Station_Control
{
    public class RabbitMQMessage 
    {
        private string _message;
        public string Message 
        {
            get 
            {
                return _message;
            } 
            set 
            {
                if (_message != value) 
                {
                    _message = value;
                    OnMessageChanged ("Message",value);
                }
            } 
        }

    private void OnMessageChanged(string propertName, string newValue)
    {
 	    if(MessageChanged!=null)
        {
            MessageChangedEventArgs args = new MessageChangedEventArgs () ;
            args.newValue = newValue;
            MessageChanged(this,args);
        }
    }

        public event MessageChangedEventHandler MessageChanged;
    }

    public class MessageChangedEventArgs : EventArgs
    {
        string newMessage;
        public virtual string newValue { get { return newMessage; }
            set { newMessage = value; }
        }
    }

        public delegate void MessageChangedEventHandler(object sender, MessageChangedEventArgs e);
    
}
