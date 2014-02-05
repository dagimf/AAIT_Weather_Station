import time
import serial
import pika
import sys
  
ser = serial.Serial('COM30', 9600)
   
while True:
    
    message = ser.readline()
    print(message)
    connection = pika.BlockingConnection(pika.ConnectionParameters(
            host='localhost'))
    channel = connection.channel()

    channel.exchange_declare(exchange='topic_logs',
                             type='topic')

    routing_key = sys.argv[1] if len(sys.argv) > 1 else 'anonymous.info'
    channel.basic_publish(exchange='topic_logs',
                          routing_key=routing_key,
                          body=message)
    print " [x] Sent %r:%r" % (routing_key, message)
    connection.close()
