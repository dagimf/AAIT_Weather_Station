//digital OUTPUT pins (7, 8 and 9)
  int digTemp = 7;  
  int digLight = 8;   
  int digPresure = 9;
//digital OUTPUT pin state
  int digTemp_state = LOW;  
  int digLight_state = LOW;   
  int digPresure_state = LOW;
  
//analog INPUT pins A1, A2 and A3
  int anaTemp = A1;  
  int anaLight = A2; 
  int anaPresure = A3;
  
  //comand chars
  char changeState = '2';
  char checkSensor = '1';
  char stopSensing = '3';
  char startSensing = '4';
  char readValue = '5';

  //Variables used inside the code
  int stringNum = 0;  //count of serial read
  char inputState = 0;  //char used to store the state of the sensors from the control station
  char cmdChar = 0;    //storage for the commands given
  String inputString = "";         // a string to hold incoming data
  boolean stringComplete = false;  // whether the string is complete
  char inChar=0;

void setup() {
    // initialize serial:
    Serial.begin(9600);
    // reserve 200 bytes for the inputString:
    inputString.reserve(200);
    
    //setting the three digital pins as output to be used for power supply
    pinMode(digTemp, OUTPUT);
    pinMode(digLight, OUTPUT);
    pinMode(digPresure, OUTPUT);
    
    //setting three analog pins as input to be used to read seansor values
    pinMode(anaTemp,INPUT);
    pinMode(anaLight,INPUT);    
    pinMode(anaPresure,INPUT);  
}

void loop() 
{
   //if we have completed reading all the message that was sent 
   //and the command is to change state then do the following   
   if (stringComplete && cmdChar==changeState)
   {
      // send the comand that was provided back
      Serial.print(cmdChar);
      Serial.print('|');
     
      //method that takes in the read value and based on that change state of the sensor
      //input state is basically the binary rep of the state in dec format
      changeSensorState(inputState);
      
      // send 1 confirming sucess
      Serial.println('1');
      
      // clear the values that are used for reuse
      inputString = "";
      stringComplete = false;
      cmdChar = 0;
    }
    
    //if reading the message is done and if the command is to 
    // check sensor state then do
    if (stringComplete && cmdChar==checkSensor) 
    {
      // send what kind of data is separated by '|' from the actual message
      Serial.print(cmdChar);
      Serial.print('|');
      // method that  outputs a string of the state of the sensors 
      // in the order of temp, light and pressure      
      Serial.println(checkState());
      
      // clear the values that are used for reuse
      inputString = "";
      stringComplete = false;
      cmdChar = 0;
    }
    
    //if reading the message is done and if the command is to 
    // stop Sensing
    if (stringComplete && cmdChar==stopSensing) 
    {
      // send the comand that was provided back
      Serial.print(cmdChar);
      Serial.print('|');
      
      //change the sensors state of all to  low
      changeSensorState('0');
      
      // send 1 confirming sucess
      Serial.println('1');
      
      // clear the values that are used for reuse
      inputString = "";
      stringComplete = false;
      cmdChar = 0;
    }
    
    //if reading the message is done and if the command is to 
    // start sensing    
    if (stringComplete && cmdChar==startSensing) 
    {
      // send the comand that was provided back
      Serial.print(cmdChar);
      Serial.print('|');
      
      //change the sensors state of all to  high
      changeSensorState('7');
      
      // send 1 confirming sucess
      Serial.println('1');
      
      // clear the values that are used for reuse
      inputString = "";
      stringComplete = false;
      cmdChar = 0;
    }
    
    //if reading the message is done and if the command is to 
    // read sensed values      
    if (stringComplete && cmdChar==readValue) 
    {
      // send what kind of data is separated by '|' from the actual message
      Serial.print(cmdChar);
      Serial.print('|');
      //method used to read sensor data
      readSensorValue();
      
     // clear the values that are used for reuse
      inputString = "";
      stringComplete = false;
      cmdChar = 0;
    }
  //a delay of half a secound inorder to allow the message api 
  // writtin in python to execute its tasks and start reading from the arduino(sensors)   
  delay(500);
}

// a method(event) invoked whenever there is a serial recived transmission into the arduino 
void serialEvent() 
{

  // used to make sure the code is only executed when there is 
  // more serial communication to be read
  while (Serial.available()) 
  {
    // if its the first char to be read store it separatly as a command character
    if (stringNum==0)
    {      
      cmdChar = (char)Serial.read();
      //increment the number of read character by one
      stringNum++;  
    }
    // if its the secound character and if the command is to change state 
    // then read the secound char and store it as inout state to be 
    // used later for setting the state of the sensors
    if (cmdChar==changeState&&stringNum==1)
    {
      inputState = (char)Serial.read();
    }
    
    // if its the secound char and the comand is not change state or if its the 
    // third char store the info into a string (just a precaution not used for the moment)
    if ((stringNum>1&&cmdChar!=changeState)||stringNum>2)
    {
      inChar = (char)Serial.read();       
      // add the reead char to the inputString:
      inputString += inChar;
    }
    
    //Serial.println(inputString);
    // if the incoming character is a newline, set a flag
    // so the main loop can do something about it: also set some variables to default values for reuse
    stringNum++;
    if (inChar == '\n') 
    {        
      stringNum=0;
      stringComplete = true;
      inChar=0;
    }     
  }
}


//method used to check state of the sensors
String checkState ()
{
  //a string meant to hold the status of each sennsor
  //each sensor is check in an if statement then appended to the string
  
  String sensorState;
  if(digTemp_state==HIGH)
  {
    sensorState+='1';
  }
  else 
  {
    sensorState+='0';  
  }
  sensorState+=':';
  if(digLight_state==HIGH)
  {
    sensorState+='1';
  }
  else 
  {
    sensorState+='0';  
  }
  sensorState+=':';
  if(digPresure_state==HIGH)
  {
    sensorState+='1';
  }
  else 
  {
    sensorState+='0';  
  }  
  return sensorState;
}

// method used to set the state of each sensor
// takes in a  char of the value to be changed
void changeSensorState (char newState)
{
  // the newState is analysed in an if clause to see wich state fits the inputed number
  
  if ( newState=='0')
  {    
    digTemp_state = LOW;  
    digLight_state = LOW;   
    digPresure_state = LOW;
  }  
  else if ( newState=='1')
  {    
    digTemp_state = LOW;  
    digLight_state = LOW;   
    digPresure_state = HIGH;
  }
  else if ( newState=='2')
  {    
    digTemp_state = LOW;  
    digLight_state = HIGH;   
    digPresure_state = LOW;
  }
  else if ( newState=='3')
  {    
    digTemp_state = LOW;  
    digLight_state = HIGH;   
    digPresure_state = HIGH;
  }
  else if ( newState=='4')
  {    
    digTemp_state = HIGH;  
    digLight_state = LOW;   
    digPresure_state = LOW;
  }
  else if ( newState=='5')
  {    
    digTemp_state = HIGH;  
    digLight_state = LOW;   
    digPresure_state = HIGH;
  }
  else if ( newState=='6')
  {    
    digTemp_state = HIGH;  
    digLight_state = HIGH;   
    digPresure_state = LOW;
  }
  else if ( newState=='7')
  {
    digTemp_state = HIGH;  
    digLight_state = HIGH;   
    digPresure_state = HIGH;
  }  
  
    // write the currently set states into the arduin pins
    digitalWrite(digTemp, digTemp_state); 
    digitalWrite(digLight, digLight_state); 
    digitalWrite(digPresure, digPresure_state);  
}

// method used to read the sensor data from the sensors
void readSensorValue () 
{
  // the output are divided by : and the text and the actuall values are separated by = sign
  
    // a float used to store temprature value
    float tempValue;
    // a float used to store light value
    float lightValue;
    // a float used to store pressure data
    float presureValue;
    
    //if the temp sensor is turned on read the temp
    if (digTemp_state == HIGH)
    {
         // read the temp valu after its caliberated for heat and current distortion, 
         // the output is in kelvin
         tempValue = analogRead(anaTemp)* 0.004882812 * 100;
         //convert degree kelvin into  degree celscies
         tempValue = tempValue - 2.5 - 273.15;
         Serial.print("Temp=");
         Serial.print(tempValue);
         // check to see if any other data is to be read inorder to see if selimitors is nescessary
         if (digLight_state == HIGH||digPresure_state == HIGH)
         {
           Serial.print(":"); 
         }       
    }
    // check to see if the light sensor is turned on and if it should be read
    if (digLight_state == HIGH)
    {
         //read the sensor value of light
         lightValue = analogRead(anaLight);
         // normalize data if it falls outside the bounds of 210, and 1000 to the max and min value respectively
         if (lightValue <100)
         {
           lightValue = 100;
         }
         else if (lightValue >1000)
         {
           lightValue = 1000;
         }
         // remap the read value into a percentage scale then send them
         lightValue = map (lightValue, 100, 1000, 0 ,100);
         Serial.print("Light=");
         Serial.print(lightValue);
         // check to see if any other data is to be read inorder to see if selimitors is nescessary
         if (digPresure_state == HIGH)
         {
           Serial.print(":"); 
         }        
    }
    // if the pressure sensor is turned on then read the value and send it
    if (digPresure_state == HIGH)
    {
         //read the value of the pressure then check how much it is by using the relation 200kpa = 1023 
         presureValue = analogRead(anaPresure);
         presureValue = presureValue * (200.0 / 1023.0);
         Serial.print("Presure=");
         Serial.print(presureValue);
    }
    // then add a new line statement to show that the message has ended
    Serial.println("");           
}





