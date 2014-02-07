//digital OUTPUT pins (7, 8 and 9)
  int digPin1 = 7;  
  int digPin2 = 8;   
  int digPin3 = 13;
//digital OUTPUT pin state
  int digPin1_state = LOW;  
  int digPin2_state = LOW;   
  int  digPin3_state = LOW;
  
//analog INPUT pins A1, A2 and A3
  int anaPin1 = A1;  
  int anaPin2 = A2; 
  int anaPin3 = A3;

int stringNum = 0;
char cmdChar = 0;
String inputString = "";         // a string to hold incoming data
boolean stringComplete = false;  // whether the string is complete
char inChar=0;

void setup() {
  // initialize serial:
  Serial.begin(9600);
  // reserve 200 bytes for the inputString:
  inputString.reserve(200);
    pinMode(digPin1, digPin1_state);
    pinMode(digPin2, digPin2_state);
    pinMode(digPin3, digPin3_state);
  
}

void loop() {
  // print the string when a newline arrives:
  if (stringComplete && cmdChar=='1') {
    Serial.println(inputString);
    Serial.println(cmdChar);
   digitalWrite(digPin3, HIGH); 
    // clear the string:
    inputString = "";
    stringComplete = false;
  }
   if (stringComplete && cmdChar=='2') {
    Serial.println(inputString);
    Serial.println(cmdChar);
    digitalWrite(digPin3, LOW); 
    // clear the string:
    inputString = "";
    stringComplete = false;
  }
  delay(500);
}

void serialEvent() {
  while (Serial.available()) {
    // get the new byte:
    if (stringNum==0)
    {      
      cmdChar = (char)Serial.read();
      stringNum++;  
    }
    if (stringNum>1)
    {
      inChar = (char)Serial.read();
       
      // add it to the inputString:
      inputString += inChar;
    }
    //Serial.println(inputString);
    // if the incoming character is a newline, set a flag
    // so the main loop can do something about it:
    stringNum++;
    if (inChar == '\n') {
      stringNum=0;
      stringComplete = true;
      inChar='0';
    } 
    
  }
}


