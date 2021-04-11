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
//int tproxVibe = 0;
//int tmidVibe = Serial.parseInt();
//int iproxVibe = Serial.parseInt();
//int imidVibe = Serial.parseInt();
//int mproxVibe = Serial.parseInt();
//int mmidVibe = Serial.parseInt();
//int rproxVibe = Serial.parseInt();
//int rmidVibe = Serial.parseInt();
//int pproxVibe = Serial.parseInt();
//int pmidVibe = Serial.parseInt(); 


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
  Serial.begin(115200);
  while(! Serial);

  pinMode(ledPin, OUTPUT);
  

}

void loop() {
  // put your main code here, to run repeatedly:

  //Read from the Unity Code
  Serial.println("Available? " + Serial.available());
  while(Serial.available() > 0) {
    Serial.println("New loop");
    digitalWrite(ledPin, HIGH);
    //delay(100);
    digitalWrite(ledPin, LOW);      
    //Parses the input force values
    int tproxVibe = Serial.parseInt();
    int tmidVibe = Serial.parseInt();
    int iproxVibe = Serial.parseInt();
    int imidVibe = Serial.parseInt();
    int mproxVibe = Serial.parseInt();
    int mmidVibe = Serial.parseInt();
    int rproxVibe = Serial.parseInt();
    int rmidVibe = Serial.parseInt();
    int pproxVibe = Serial.parseInt();
    int pmidVibe = Serial.parseInt(); 

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
    if (Serial.find("\n")){
      
      //Keep the input values within the PWM output range
      iproxVibe = constrain(iproxVibe, 0, 255);
      imidVibe = constrain(imidVibe, 0, 255);
      mproxVibe = constrain(mproxVibe, 0, 255);
      mmidVibe = constrain(mmidVibe, 0, 255);

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
      digitalWrite(ledPin, HIGH);
      //delay(100);
      digitalWrite(ledPin, LOW);      
    }
  }
 //Serial.println("end of loop");

}
