

// pins that the sensors are attached to
const int sensorPin[10] = {A0, A1, A2, A3, A4, A5, A6, A7, A8, A9};

// number of sensors available
const int n_sensors = sizeof(sensorPin)/sizeof(sensorPin[0]);

// Measure the voltage at 5V and the actual resistance of your
// 47k resistor, and enter them below:
const float VCC = 4.98; // Measured voltage of Ardunio 5V line
const float R_DIV = 51000.0; // Measured resistance of 47k resistor
                                              //ThumbD, THumbM, IndexM,   IndexPrx,MiddleM, MiddlePrx, RingM, RingProx, SmallM, SmallPrx
const float STRAIGHT_RESISTANCE[n_sensors] =  {26300.0, 22071.0, 27300.0, 27300.0, 28500.0, 29300.0, 26300.0, 26300.0, 33300.0, 26300.0}; // resistance when straight
const float BEND_RESISTANCE[n_sensors] =      {45000.0, 49000.0, 74000.0, 43000.0, 84000.0, 38000.0, 33000.0, 32000.0, 56000.0, 52000.0}; // resistance at 90 deg


// ================================================================
// ===                      INITIAL SETUP                       ===
// ================================================================

void setup() {
   
    // initialize serial communication
    // (115200 chosen because it is required for Teapot Demo output, but it's
    // really up to you depending on your project)
    Serial.begin(115200);
    while (!Serial);
    for(int i = 0; i < n_sensors; i++){
      pinMode(sensorPin[i], INPUT);
    }

}


// ================================================================
// ===                    MAIN PROGRAM LOOP                     ===
// ================================================================
void loop() {
      
   float bend_angles[10] = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
   for (int i = 0; i < n_sensors; i++) {
      bend_angles[i] = calculate_bend(i);
  }

// ================================================================
// ===              Printing Degrees Flex senosrs               ===
// ================================================================
    
  String send_data = "";
    for (int i = 0; i < n_sensors; i++) {
      if (i != 0) { send_data= send_data + ","; }
      send_data = send_data + bend_angles[i];
    }
    Serial.println(send_data);
    delay(11);

}

float calculate_bend(int pin_n) {
  // Read the ADC, and calculate voltage and resistance from it

  int flexADC = analogRead(sensorPin[pin_n]);
  float flexV = flexADC * VCC / 1023.0;
  //Serial.println("flexV: " + String(flexV));
  float flexR = R_DIV * (VCC / flexV - 1.0);

  // Use the calculated resistance to estimate the sensor's
  // bend angle:
  float angle = map(flexR, STRAIGHT_RESISTANCE[pin_n], BEND_RESISTANCE[pin_n],
                   0, 90.0);
  return(angle);
}
