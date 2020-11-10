// I2Cdev and MPU6050 must be installed as libraries, or else the .cpp/.h files
// for both classes must be in the include path of your project

#include "I2Cdev.h"
#include "MPU6050_6Axis_MotionApps20.h"

//////// DO WE NEED THIS?????
//#if I2CDEV_IMPLEMENTATION == I2CDEV_ARDUINO_WIRE
   // #include "Wire.h"
//#endif

// class default I2C address is 0x68
// specific I2C addresses may be passed as a parameter here
// AD0 low = 0x68 (default for SparkFun breakout and InvenSense evaluation board)
// AD0 high = 0x69
MPU6050 mpu;
//MPU6050 mpu(0x69); // <-- use for AD0 high

/* =========================================================================
   NOTE: In addition to connection 3.3v, GND, SDA, and SCL, this sketch
   depends on the MPU-6050's INT pin being connected to the Arduino's
   external interrupt #0 pin. On the Arduino Uno and Mega 2560, this is
   digital I/O pin 2.
 * ========================================================================= */

/* =========================================================================
   NOTE: Arduino v1.0.1 with the Leonardo board generates a compile error
   when using Serial.write(buf, len). The Teapot output uses this method.
   The solution requires a modification to the Arduino USBAPI.h file, which
   is fortunately simple, but annoying. This will be fixed in the next IDE
   release. For more info, see these links:

   http://arduino.cc/forum/index.php/topic,109987.0.html
   http://code.google.com/p/arduino/issues/detail?id=958
 * ========================================================================= */



// uncomment "OUTPUT_READABLE_YAWPITCHROLL" if you want to see the yaw/
// pitch/roll angles (in degrees) calculated from the quaternions coming
// from the FIFO. Note this also requires gravity vector calculations.
// Also note that yaw/pitch/roll angles suffer from gimbal lock (for
// more info, see: http://en.wikipedia.org/wiki/Gimbal_lock)
#define OUTPUT_READABLE_YAWPITCHROLL

#define DEBUG_MODE // use this to print outputs about the debugging state


#define INTERRUPT_PIN 2 // P3_7  // use this as an interrprut 
#define LED_PIN LED_BUILTIN // RED_LED // to display if system is on
bool blinkState = false;

// MPU control/status vars
bool dmpReady = false;  // set true if DMP init was successful
uint8_t mpuIntStatus;   // holds actual interrupt status byte from MPU
uint8_t devStatus;      // return status after each device operation (0 = success, !0 = error)
uint16_t packetSize;    // expected DMP packet size (default is 42 bytes)
uint16_t fifoCount;     // count of all bytes currently in FIFO
uint8_t fifoBuffer[64]; // FIFO storage buffer

// orientation/motion vars
Quaternion q;           // [w, x, y, z]         quaternion container
//VectorInt16 aa;         // [x, y, z]            accel sensor measurements
//VectorInt16 aaReal;     // [x, y, z]            gravity-free accel sensor measurements
//VectorInt16 aaWorld;    // [x, y, z]            world-frame accel sensor measurements
VectorFloat gravity;    // [x, y, z]            gravity vector
//float euler[3];         // [psi, theta, phi]    Euler angle container
float ypr[3];           // [yaw, pitch, roll]   yaw/pitch/roll container and gravity vector

//const int sensorPin1 = A14;    // pin that the sensor is attached to
//const int sensorPin2 = A13;    // pin that the sensor is attached to
//const int sensorPin3 = A11;    // pin that the sensor is attached to
//const int sensorPin4 = A9;    // pin that the sensor is attached to
//const int sensorPin5 = A8;    // pin that the sensor is attached to

// pins that the sensors are attached to
const int sensorPin[5] = {A0, A1, A2, A3, A4};

// number of sensors available
const int numSensors = sizeof(sensorPin)/sizeof(sensorPin[0]);

// degree array
float deg[numSensors];

const int ledPin = LED_BUILTIN;        // pin that the LED is attached to

// variables:
//int sensorValue1 = 0;         // the sensor value
//int sensorValue2 = 0;         // the sensor value
//int sensorValue3 = 0;         // the sensor value
//int sensorValue4 = 0;         // the sensor value
//int sensorValue5 = 0;         // the sensor value

// sensor values
int sensorValue[numSensors];
const float defaultValue = 0;

// minimum sensor value volts
float sensorMin[numSensors];
const float defaultMin = 0;

// maximum sensor value volts
float sensorMax[numSensors];
const float defaultMax = 5;

//float sensorMin1 = 5;        // minimum sensor value volts
//float sensorMax1 = 0;           // maximum sensor value volts
//float sensorMin2 = 5;        // minimum sensor value volts
//float sensorMax2 = 0;           // maximum sensor value volts
//float sensorMin3 = 5;        // minimum sensor value volts
//float sensorMax3 = 0;           // maximum sensor value volts
//float sensorMin4 = 5;        // minimum sensor value volts
//float sensorMax4 = 0;           // maximum sensor value volts
//float sensorMin5 = 5;        // minimum sensor value volts
//float sensorMax5 = 0;           // maximum sensor value volts

int sensorDeg = 0;          // degree mapping degree

// the setup routine runs once when you press reset:
float volts(int senseval){
  float volt = senseval * (5.000/1023.000);
  return volt;
}

// ================================================================
// ===               INTERRUPT DETECTION ROUTINE                ===
// ================================================================

volatile bool mpuInterrupt = false;     // indicates whether MPU interrupt pin has gone high
void dmpDataReady() {
    mpuInterrupt = true;
}

// ================================================================
// ===                      INITIAL SETUP                       ===
// ================================================================

void setup() {
    // join I2C bus (I2Cdev library doesn't do this automatically)
    #if I2CDEV_IMPLEMENTATION == I2CDEV_ARDUINO_WIRE
        Wire.begin();
        //Wire.setClock(400000); // 400kHz I2C clock. Comment this line if having compilation difficulties
    #elif I2CDEV_IMPLEMENTATION == I2CDEV_BUILTIN_FASTWIRE
        Fastwire::setup(400, true);
    #endif

    // initialize serial communication
    // (115200 chosen because it is required for Teapot Demo output, but it's
    // really up to you depending on your project)
    Serial.begin(115200);
    while (!Serial);

    // initialize device
    #ifdef DEBUG_MODE
      Serial.println(F("Initializing I2C devices..."));
    #endif
    pinMode(INTERRUPT_PIN, INPUT);
    Serial.println(F("Interupt pin set"));
    mpu.initialize();
    

    // verify connection
    #ifdef DEBUG_MODE
      Serial.println(F("Testing device connections..."));
      Serial.println(mpu.testConnection() ? F("MPU6050 connection successful") : F("MPU6050 connection failed"));
    #endif

    // wait for ready
    
//    Serial.println(F("\nSend any character to begin DMP programming and demo: "));
//    while (Serial.available() && Serial.read()); // empty buffer
//    while (!Serial.available());                 // wait for data
    while (Serial.available() && Serial.read()); // empty buffer again

    // load and configure the DMP
    #ifdef DEBUG_MODE
      Serial.println(F("Initializing DMP..."));
    #endif
    devStatus = mpu.dmpInitialize();

    ///////////// WHY? ARE THESE CORRECT? //////////////
    // supply your own gyro offsets here, scaled for min sensitivity
    mpu.setXGyroOffset(220);
    mpu.setYGyroOffset(76);
    mpu.setZGyroOffset(-85);
    mpu.setZAccelOffset(1788); // 1688 factory default for my test chip

    // make sure it worked (returns 0 if so)
    if (devStatus == 0) {
        // turn on the DMP, now that it's ready
        #ifdef DEBUG_MODE  
          Serial.println(F("Enabling DMP..."));
        #endif
        mpu.setDMPEnabled(true);

        // enable Arduino interrupt detection
        #ifdef DEBUG_MODE
          Serial.println(F("Enabling interrupt detection (Arduino external interrupt 0)..."));
        #endif
        attachInterrupt(digitalPinToInterrupt(INTERRUPT_PIN), dmpDataReady, RISING);
        mpuIntStatus = mpu.getIntStatus();

        // set our DMP Ready flag so the main loop() function knows it's okay to use it
        #ifdef DEBUG_MODE
          Serial.println(F("DMP ready! Waiting for first interrupt..."));
        #endif
        dmpReady = true;

        // get expected DMP packet size for later comparison
        packetSize = mpu.dmpGetFIFOPacketSize();
    } else {
        // ERROR!
        // 1 = initial memory load failed
        // 2 = DMP configuration updates failed
        // (if it's going to break, usually the code will be 1)
        Serial.print(F("DMP Initialization failed (code "));
        Serial.print(devStatus);
        Serial.println(F(")"));
    }

    // configure LED for output
    //pinMode(LED_PIN, OUTPUT);

    digitalWrite(ledPin, HIGH);

    //////////// WHAT IS THIS AND WHY? /////////////
    // calibrate during the first five seconds 
    while (millis() < 5000) {
       sensorValue[0] = analogRead(sensorPin[0]);
       float temp = volts(sensorValue[0]);
      //Serial.println(temp);
      //delay(1000);
      
  
      // record the maximum sensor value
      if (temp > sensorMax[0]) {
        sensorMax[0] = 4.52;
        sensorMax[1] = 4.7;
        sensorMax[2] = 5;
        sensorMax[3] = 4.95;
        sensorMax[4] = 4.55;
      } else {
        // default all max to defaultMax
        for (int i = 0; i < numSensors; i++) {
          sensorMax[i] = defaultMax;
        }
      }
      // record the minimum sensor value
      if (temp < sensorMin[0]) {
        sensorMin[0] = 2.89;
        sensorMin[1] = 3.0;
        sensorMin[2] = 3.4;
        sensorMin[3] = 3.2;
        sensorMin[4] = 3.5;
      } else {
        // defualt all min to defaultMin
        for (int i = 0; i < numSensors; i++) {
          sensorMin[i] = defaultMin;
        }
      }
  }

    // signal the end of the calibration period
    digitalWrite(ledPin, LOW);
    #ifdef DEBUG_MODE
      Serial.println("_____ sensor 1 ________");
      Serial.println(sensorMin[0]);
      Serial.println(sensorMax[0]);
      Serial.println("_______________________");
      Serial.println("_____ sensor 2 ________");
      Serial.println(sensorMin[1]);
      Serial.println(sensorMax[1]);
      Serial.println("_______________________");
      Serial.println("_____ sensor 3 ________");
      Serial.println(sensorMin[2]);
      Serial.println(sensorMax[2]);
      Serial.println("_______________________");
      Serial.println("_____ sensor 4 ________");
      Serial.println(sensorMin[3]);
      Serial.println(sensorMax[3]);
      Serial.println("_______________________");
      Serial.println("_____ sensor 5 ________");
      Serial.println(sensorMin[4]);
      Serial.println(sensorMax[4]);
      Serial.println("_______________________");
    #endif
}



float mapping(float v_deg, int sensorIndex){
  float v_diff = sensorMax[sensorIndex] - sensorMin[sensorIndex];
  float v_per_deg = v_diff/90;
  if (v_deg >= sensorMax[sensorIndex]){
    return 90.00;
  } else if (v_deg <= sensorMin[sensorIndex]){
    return 0.00;
  } else{
    float i = 0;
    while(v_deg > (i*v_per_deg)+sensorMin[sensorIndex]){
      i = i + 1;
    }
    return i;
  }
}



// ================================================================
// ===                    MAIN PROGRAM LOOP                     ===
// ================================================================
void loop() {
    // if programming failed, don't try to do anything
    if (!dmpReady) return;

    // wait for MPU interrupt or extra packet(s) available
    while (!mpuInterrupt && fifoCount < packetSize) {
        // other program behavior stuff here
        // .
        // .
        // .
        // if you are really paranoid you can frequently test in between other
        // stuff to see if mpuInterrupt is true, and if so, "break;" from the
        // while() loop to immediately process the MPU data
        // .
        // .
        // .
    }

    // reset interrupt flag and get INT_STATUS byte
    mpuInterrupt = false;
    mpuIntStatus = mpu.getIntStatus();

    // get current FIFO count
    fifoCount = mpu.getFIFOCount();

    // check for overflow (this should never happen unless our code is too inefficient)
    if ((mpuIntStatus & 0x10) || fifoCount == 1024) {
        // reset so we can continue cleanly
        mpu.resetFIFO();
        #ifdef DEBUG_MODE
          Serial.println(F("FIFO overflow!"));
        #endif

    // otherwise, check for DMP data ready interrupt (this should happen frequently)
    } else if (mpuIntStatus & 0x02) {
        // wait for correct available data length, should be a VERY short wait
        while (fifoCount < packetSize) fifoCount = mpu.getFIFOCount();

        // read a packet from FIFO
        mpu.getFIFOBytes(fifoBuffer, packetSize);
        
        // track FIFO count here in case there is > 1 packet available
        // (this lets us immediately read more without waiting for an interrupt)
        fifoCount -= packetSize;

// ================================================================
// ===              Printing Degrees IMU                        ===
// ================================================================

        // display Euler angles in degrees
        mpu.dmpGetQuaternion(&q, fifoBuffer);
        mpu.dmpGetGravity(&gravity, &q);
        mpu.dmpGetYawPitchRoll(ypr, &q, &gravity);
        Serial.print(ypr[0] * 180/M_PI + 40.5);           // WHY ARE WE ADDING THESE ARBITRARY VALUES?
        Serial.print(",");
        Serial.print(ypr[1] * 180/M_PI - 6.22);
        Serial.print(",");
        Serial.print(ypr[2] * 180/M_PI + 1.5);

        // blink LED to indicate activity
        blinkState = !blinkState;
        digitalWrite(LED_PIN, blinkState); 
    }

//      // read the input on analog pin A3:
//    sensorValue1 = analogRead(sensorPin1);
//    sensorValue2 = analogRead(sensorPin2);
//    sensorValue3 = analogRead(sensorPin3);
//    sensorValue4 = analogRead(sensorPin4);
//    sensorValue5 = analogRead(sensorPin5);

    // read the inputs
    for (int i = 0; i < numSensors; i++) {
      sensorValue[i] = analogRead(sensorPin[i]);
    }

    // apply the calibration to the sensor reading
    for (int i = 0; i < numSensors; i++) {
      deg[i] = mapping(volts(sensorValue[i]), i);
    }

// ================================================================
// ===              Printing Degrees Flex senosrs               ===
// ================================================================
    
    //Serial.print(voltage5, 2);
//    Serial.print("\t\tdegree s1 : ");
//    Serial.print(deg1);
//    Serial.print("\tdegree s2 : ");
//    Serial.print(deg2);
//    Serial.print("\tdegree s3 : ");
//    Serial.print(deg3);
//    Serial.print("\tdegree s4 : ");
//    Serial.print(deg4);
//    Serial.print("\tdegree s5 : ");
//    Serial.println(deg5);

//    Serial.print(",");
//    Serial.print(deg[0]);
//    Serial.print(",");
//    Serial.print(deg[1]);
//    Serial.print(",");
//    Serial.print(deg[2]);
//    Serial.print(",");
//    Serial.println(deg[3]);
//    Serial.print(",");
//    Serial.println(deg[4]);

    for (int i = 0; i < numSensors; i++) {
      Serial.print(",");
      Serial.print(deg[i]);
    }
    Serial.println("");
}
