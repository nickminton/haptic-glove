#define N_POINTS 10

// The indices of the arrays below follow the following pattern:
// 0 - T_Prox; //Thumb Proximal Joint
// 1 - T_Dist; //Thumb Distal Joint
// 2 - I_Prox; //Index Proximal Joint
// 3 - I_Dist; //Index Distal Joint
// 4 - M_Prox; //Middle Distal Joint
// 5 - M_Dist; //Middle Distal Joint
// 6 - R_Prox; //Ring Proximal Joint
// 7 - R_Dist; //Ring Distal Joint
// 8 - P_Prox; //Pinky Proximal Joint
// 9 - P_Dist; //Pinky Distal Joint

int JointState[N_POINTS];
int JointDuty[N_POINTS];
//int JointPin[N_POINTS] = {P1_3, P1_2}; //P1_1, P1_4, P1_5, P2_0, P2_1, P2_2, P2_3, P2_4};
int JointPin[N_POINTS] = {P1_1,  // Thumb Proximal Joint
                          P1_2,  // Thumb Distal Joint
                          P1_3,  // Index Proximal Joint
                          P1_4,  // Index Distal Joint
                          P1_5,  // Middle Proximal Joint
                          P2_0,  // Middle Distal Joint
                          P2_1,  // Ring Proximal Joint
                          P2_2,  // Ring Distal Joint
                          P2_3,  // Pinky Proximal Joint
                          P2_4}; // Pinky Distal Joint

// ================================================================
// ===                      INITIAL SETUP                       ===
// ================================================================
int interval = 100;
unsigned long check[N_POINTS];       // last time thum proximate was updated
int led_status = 0;

void setup() {
  // set output pins
  pinMode(GREEN_LED, OUTPUT);
  pinMode(P1_7, OUTPUT);
//  pinMode(P1_1, INPUT_PULLUP);

  // set serial
  Serial.begin(1200);
  digitalWrite(GREEN_LED, LOW);
  while (!Serial);
  digitalWrite(GREEN_LED, HIGH);
  
  // debug
  Serial.println(N_POINTS);

  // fill arrays
  for (int i = 0; i < N_POINTS; i++) {
    check[i] = 0;
    JointDuty[i] = 0;
    JointState[i] = 0;
  }

//  Serial.println(F("\nSend any character to begin DMP programming and demo: "));
  while (Serial.available() && Serial.read()); // empty buffer
//  while (!Serial.available());                 // wait for data
//  while (Serial.available()) Serial.read(); // empty buffer again
  Serial.println("Starting...");
  digitalWrite(GREEN_LED, LOW);
}


// ================================================================
// ===                    UTILITY FUNCTIONS                     ===
// ================================================================

// update the state of a given index of JointState
void state_function(int index) {
  // Initialize
  unsigned long currTime = millis();
  int Duty = JointDuty[index];
  
  // if the time since the last check is less than the duty cycle, output 1
  if ((currTime - check[index]) < Duty) {JointState[index] = 1;} 
  else {
    // if the time since the last check is less than the interval, output 0
    if ((currTime - check[index]) < interval) {JointState[index] = 0;}
    // otherwise, update check to the last checking time
    else {check[index] = currTime;}
  }
}

// parse input as new duty cycle commands
void parseInput(String input) {
  // Initialize
  int ind = 0;
  int duty = 0;

  // debug
  Serial.print(input);

  // TODO: DATA VERIFICATION
  
  // look for N_POINTS points
  for (int i = 0; i < N_POINTS; i++) {
    // find the next comma
    ind = input.indexOf(',');
    
    // set the duty cycle
    duty = input.substring(0,ind).toInt();
    JointDuty[i] = duty * interval / 100;

    // DEBUG
    Serial.println(duty);

    // shift the input
    input = input.substring(ind+1);
  }
}

// ================================================================
// ===                    MAIN PROGRAM LOOP                     ===
// ================================================================
void loop() {
  // Read in from Serial if available
  if (Serial.available()) {
    // toggle LED
    led_status = !led_status;
    digitalWrite(GREEN_LED, led_status);
    
    // read and parse
    String strIn = Serial.readString();
    parseInput(strIn);
    
  } else {
    // assume that the data stayed the same if there is none available
  }

  // Do state_function on each joint
  for (int i = 0; i < N_POINTS; i++) {
    // update the state of the joint
    state_function(i);

    // write either 0 or 255 depending on the state
    analogWrite(JointPin[i], JointState[i]);
//    delay(1);
  }
}
