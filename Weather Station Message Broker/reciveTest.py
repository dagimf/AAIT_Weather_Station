#import the necessary librarys
import pika
import sys
import serial

#create a connection with the specified ipaddress (localHost)
connection = pika.BlockingConnection(pika.ConnectionParameters(
        host='localhost'))
#create a channel to connect with the RabbitMQ service
channel = connection.channel()

#create a global variable containing for erial communication
global ser
#set the serial communication to use COM30 and at a speed of 9600B baudrate
ser = serial.Serial('COM30', 9600)

#variable indicating if there is a message to recived from the serial port
global messageReceived
messageReceived = False

#chose the exchange to listen to (topic_logs)
channel.exchange_declare(exchange='topic_logs',
                         type='topic')

#create a random que to temporarly store the message
result = channel.queue_declare(exclusive=True)
queue_name = result.method.queue

#obtaine the binding key(routing key) for the que from the system argument
#it should be the Raspberry name. the arduino name
binding_key = "Device."+sys.argv[1]
#check to see if binding key is provided with system argument
#if not binding_keys:
 #   print >> sys.stderr, "Usage: %s [binding_key]..." % (sys.argv[0],)
  #  sys.exit(1)

#if binding key is provided bind the key to the random que created
#for binding_key in binding_keys:

channel.queue_bind(exchange='topic_logs',
                       queue=queue_name,
                       routing_key=binding_key)

print ' [*] Waiting for logs. To exit press CTRL+C'

#method that is called whenever a message is received
def callback(ch, method, properties, body):
    print " [x] %r:%r" % (method.routing_key, body,)
    #send the command that was recived directky to the serial port
    ser.write(body+'\n')
    #set the message recived status true    
    messageReceived = True
    #as long as there is a message to be recived do
    while messageReceived:
      #try to read a serial communication from the serial port
      try:
        message = ser.readline()
      #allow for keyboard interrupt to stop system from getting stuck  
      except KeyboardInterrupt :
        #if interupt occurs close the serial communication
        ser.close()
        break 
      #set the routing key for sending message
      routing_key = "Control."+sys.argv[1]
      #publish the message to topic_logs with the given routing key, and message read from the serial port
      channel.basic_publish(exchange='topic_logs',
                            routing_key=routing_key,
                            body=message)
      print " [x] Sent %r:%r" % (routing_key, message)
      # stop trying to recive message from the serial port
      messageReceived = False

# Recive the message from the random que, calls the callbak method
channel.basic_consume(callback,
                      queue=queue_name,
                      no_ack=True)
# starts the recive message method
channel.start_consuming()



