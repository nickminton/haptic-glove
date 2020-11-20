/******************************************************************************
Flex_Sensor_Example.ino
Example sketch for SparkFun's flex sensors
  (https://www.sparkfun.com/products/10264)
Jim Lindblom @ SparkFun Electronics
April 28, 2016

Create a voltage divider circuit combining a flex sensor with a 47k resistor.
- The resistor should connect from A0 to GND.
- The flex sensor should connect from A0 to 3.3V
As the resistance of the flex sensor increases (meaning it's being bent), the
voltage at A0 should decrease.

Development environment specifics:
Arduino 1.6.7
******************************************************************************/
const int sensorPin[2] = {A0, A1}; // Pin connected to voltage divider output
const int n_sensors = sizeof(sensorPin)/sizeof(sensorPin[0]);

// Measure the voltage at 5V and the actual resistance of your
// 47k resistor, and enter them below:
const float VCC = 4.98; // Measured voltage of Ardunio 5V line
const float R_DIV = 47500.0; // Measured resistance of 47k resistor

// Upload the code, then try to adjust these values to more
// accurately calculate bend degree.
const float STRAIGHT_RESISTANCE[2] = {32500.0, 23500.0}; // resistance when straight
const float BEND_RESISTANCE[2] = {48000.0, 55000.0}; // resistance at 90 deg
void setup() 
{
  Serial.begin(9600);
  for(int i = 0; i < n_sensors; i++){
    pinMode(sensorPin[i], INPUT);
  }
}

void loop() 
{
  int bend_angle;
   for (int i = 0; i < n_sensors; i++) {
      if(i == 0) {
        Serial.println("Proximal:");
      } else {
        Serial.println("Middle:");
      }
      bend_angle = calculate_bend(i);
  }

  delay(1000);
}
float calculate_bend(int pin_n) {
  // Read the ADC, and calculate voltage and resistance from it
  int flexADC = analogRead(sensorPin[pin_n]);
  float flexV = flexADC * VCC / 1023.0;
  float flexR = R_DIV * (VCC / flexV - 1.0);
  Serial.println("Resistance: " + String(flexR) + " ohms");

  // Use the calculated resistance to estimate the sensor's
  // bend angle:
  float angle = map(flexR, STRAIGHT_RESISTANCE[pin_n], BEND_RESISTANCE[pin_n],
                   0, 90.0);
  Serial.println("Bend: " + String(angle) + " degrees");
  Serial.println();
  return(angle);
}
