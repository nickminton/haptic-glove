int tproximal = 3;
int tmiddle = 2;
int iproximal = 5;
int imiddle = 4;
int mproximal = 7;
int mmiddle = 6;
int rproximal = 9;
int rmiddle = 8;
int pproximal = 11;
int pmiddle = 10;

//Initialize Vibe Variables to zero
int tproxVibe = 0;
int tmidVibe = 0;
int iproxVibe = 0;
int imidVibe = 0;
int mproxVibe = 0;
int mmidVibe = 0;
int rproxVibe = 0;
int rmidVibe = 0;
int pproxVibe = 0;
int pmidVibe = 0; 


const int ledPin =  LED_BUILTIN;// the number of the LED pin

// Variables will change:
int ledState = LOW;             // ledState used to set the LED

void setup() {
  // put your setup code here, to run once:

  //Set pin mode for PWM pins
  pinMode(iproximal, OUTPUT);
  pinMode(imiddle, OUTPUT);
  pinMode(mproximal, OUTPUT);
  pinMode(mmiddle, OUTPUT);
  pinMode(rproximal, OUTPUT);
  pinMode(rmiddle, OUTPUT);
  pinMode(pproximal, OUTPUT);
  pinMode(pmiddle, OUTPUT);
  pinMode(tproximal, OUTPUT);
  pinMode(tmiddle, OUTPUT);

  //Setup serial communication
  Serial.begin(9600);
  while(! Serial);

  pinMode(ledPin, OUTPUT);
  Serial.flush();
  

}

void loop() {
  // put your main code here, to run repeatedly:
  
  //Read from the Unity Code
  //Serial.println("Available? " + Serial.available());
  while(Serial.available() > 10) {
    //Serial.println("New loop");

    //delay(100);
    //digitalWrite(ledPin, LOW);      
    //Parses the input force values
    tproxVibe = Serial.read() - '0';
    tmidVibe = Serial.read()- '0';
    iproxVibe = Serial.read()- '0';
    imidVibe = Serial.read()- '0';
    mproxVibe = Serial.read()- '0';
    mmidVibe = Serial.read()- '0';
    rproxVibe = Serial.read()- '0';
    rmidVibe = Serial.read()- '0';
    pproxVibe = Serial.read()- '0';
    pmidVibe = Serial.read()- '0'; 
    

    //Serial.println("mmid =" + String(mmidVibe));

/*
    Serial.print(String(tproxVibe)+",");
    Serial.print(String(tmidVibe)+",");
    Serial.print(String(iproxVibe)+",");
    Serial.print(String(imidVibe)+",");
    Serial.print(String(mproxVibe)+",");
    Serial.print(String(mmidVibe)+",");
    Serial.print(String(rproxVibe)+","); 
    Serial.print(String(rmidVibe)+","); 
    Serial.print(String(pproxVibe)+",");
    Serial.print(String(pmidVibe)+",");
   */ 
    //Serial.println("Peek: ");
    //Reads for the next line of force values
    char str = Serial.read();
    
    //Serial.println("end char:" + String(str));
    if (str == '\n'){
      
      //Keep the input values within the PWM output range
      tproxVibe = map(tproxVibe, 0, 9, 0, 255);
    tmidVibe = map(tmidVibe, 0, 9, 0, 255);
    iproxVibe = map(iproxVibe, 0, 9, 0, 255);
    imidVibe = map(imidVibe, 0, 9, 0, 255);
    mproxVibe = map(mproxVibe, 0, 9, 0, 255);
    mmidVibe = map(mmidVibe, 0, 9, 0, 255);
    rproxVibe = map(rproxVibe, 0, 9, 0, 255);
    rmidVibe = map(rmidVibe, 0, 9, 0, 255);
    pproxVibe = map(pproxVibe, 0, 9, 0, 255);
    pmidVibe = map(pmidVibe, 0, 9, 0, 255);
      
      iproxVibe = constrain(iproxVibe, 0, 255);
      imidVibe = constrain(imidVibe, 0, 255);
      mproxVibe = constrain(mproxVibe, 0, 255);
      mmidVibe = constrain(mmidVibe, 0, 255);
    tproxVibe = constrain(tproxVibe, 0, 255);
    tmidVibe =constrain(tmidVibe, 0, 255);
    rproxVibe = constrain(rproxVibe, 0, 255);
    rmidVibe = constrain(rmidVibe, 0, 255);
    pproxVibe = constrain(pproxVibe, 0, 255);
    pmidVibe = constrain(pmidVibe, 0, 255);
    
      //Set the output at the PWM pins
      analogWrite(iproximal, iproxVibe);
      analogWrite(imiddle, imidVibe);
      analogWrite(mproximal, mproxVibe);
      analogWrite(mmiddle, mmidVibe);
      analogWrite(rproximal, rproxVibe);
      analogWrite(rmiddle, rmidVibe);
      analogWrite(pproximal, pproxVibe);
      analogWrite(pmiddle, pmidVibe);
      analogWrite(tproximal, tproxVibe);
      analogWrite(tmiddle, tproxVibe);
      //Serial.print("test");
//      digitalWrite(ledPin, HIGH);
//      //delay(100);
//      digitalWrite(ledPin, LOW);

    } else {
      
      //Serial.println("new line not found");
      Serial.find('\n');
    }

  }
 //Serial.println("end of loop");

}
