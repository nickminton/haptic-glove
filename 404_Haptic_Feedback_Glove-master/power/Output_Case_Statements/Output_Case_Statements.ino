#define N_POINTS 10

int T_Prox; //Thumb Proximal Joint
int T_Dist; //Thumb Distal Joint
int I_Prox; //Index Proximal Joint
int I_Dist; //Index Distal Joint
int M_Prox; //Middle Distal Joint           //Joint Status Vaiable Declarations
int M_Dist; //Middle Distal Joint
int R_Prox; //Ring Distal Joint
int R_Dist; //Ring Distal Joint
int P_Prox; //Pinky Distal Joint
int P_Dist; //Pinky Distal Joint

int T_Prox_Duty; //Thumb Proximal Duty Cycle on %
int T_Dist_Duty; //Thumb Distal Duty Cycle on %
int I_Prox_Duty; //Index Proximal Duty Cycle on %
int I_Dist_Duty; //Index Distal Duty Cycle on %
int M_Prox_Duty; //Middle Proximal Duty Cycle on %
int M_Dist_Duty; //Middle Distal Duty Cycle on %      //Per-Joint Duty Cycle on %
int R_Prox_Duty; //Ring Proximal Duty Cycle on %
int R_Dist_Duty; //Ring Distal Duty Cycle on %
int P_Prox_Duty; //Pinky Proximal Duty Cycle on %
int P_Dist_Duty; //Pinky Distal Duty Cycle on %

int interval = 100;
long check = 0; //last time thum proximate was updated

int JointDuty[N_POINTS];
int led_status = 0;


void setup() {
  //set output pins
  pinMode(GREEN_LED, OUTPUT);
  pinMode(P1_7, OUTPUT);
  //set UART input pin
  pinMode(P1_1, INPUT_PULLUP);

  Serial.begin(9600);
  while(!Serial);

  Serial.println("Ready!");
}

int state_function(long currTime, int Duty){
  if ((currTime - check) < Duty) {return 1;}
  else {
    if ((currTime - check) < interval) {return 0;}
    else {check = currTime;}
    return 0;
  }
}

// parse input as new duty cycle commands
void parseInput(String input) {
  // Initialize
  int ind = 0;
  int duty = 0;

  // TODO: DATA VERIFICATION
  
  // look for N_POINTS points
  for (int i = 0; i < N_POINTS; i++) {
    // find the next comma
    ind = input.indexOf(',');
    
    // set the duty cycle
    duty = input.substring(0,ind).toInt();
    JointDuty[i] = duty;

    // DEBUG
    Serial.println(duty);

    // shift the input
    input = input.substring(ind+1);
  }
}

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
  
T_Prox_Duty = JointDuty[0]; //Thumb Proximal Duty Cycle on %
T_Dist_Duty = JointDuty[1]; //Thumb Distal Duty Cycle on %
I_Prox_Duty = JointDuty[2]; //Index Proximal Duty Cycle on %
I_Dist_Duty = JointDuty[3]; //Index Distal Duty Cycle on %
M_Prox_Duty = JointDuty[4]; //Middle Proximal Duty Cycle on %
M_Dist_Duty = JointDuty[5]; //Middle Distal Duty Cycle on %      //Per-Joint Duty Cycle on %
R_Prox_Duty = JointDuty[6]; //Ring Proximal Duty Cycle on %
R_Dist_Duty = JointDuty[7]; //Ring Distal Duty Cycle on %
P_Prox_Duty = JointDuty[8]; //Pinky Proximal Duty Cycle on %
P_Dist_Duty = JointDuty[9]; //Pinky Distal Duty Cycle on %

  unsigned long currentMillis = millis();
  T_Prox = state_function(currentMillis, (T_Prox_Duty*interval/100));
  if (T_Prox == 1){analogWrite(P1_7, 255);}
  else {analogWrite(P1_7,0);}

  T_Dist = state_function(currentMillis, (T_Dist_Duty*interval/100));
  if (T_Dist == 1){analogWrite(P1_2, 255);}
  else {analogWrite(P1_2,0);}

  I_Prox = state_function(currentMillis, (I_Prox_Duty*interval/100));
  if (I_Prox == 1){analogWrite(P1_3, 255);}
  else {analogWrite(P1_3,0);}
   
  I_Dist = state_function(currentMillis, (I_Dist_Duty*interval/100));
  if (I_Dist == 1){analogWrite(P1_4, 255);}
  else {analogWrite(P1_4,0);}

  M_Prox = state_function(currentMillis, (M_Prox_Duty*interval/100));
  if (M_Prox == 1){analogWrite(P1_5, 255);}
  else {analogWrite(P1_5,0);}
   
  M_Dist = state_function(currentMillis, (M_Dist_Duty*interval/100));
  if (M_Dist == 1){analogWrite(P2_0, 255);}
  else {analogWrite(P2_0,0);}

  R_Prox = state_function(currentMillis, (R_Prox_Duty*interval/100));
  if (R_Prox == 1){analogWrite(P2_1, 255);}
  else {analogWrite(P2_1,0);}
   
  R_Dist = state_function(currentMillis, (R_Dist_Duty*interval/100));
  if (R_Dist == 1){analogWrite(P2_2, 255);}
  else {analogWrite(P2_2,0);}

  P_Prox = state_function(currentMillis, (P_Prox_Duty*interval/100));
  if (P_Prox == 1){analogWrite(P2_3, 255);}
  else {analogWrite(P2_3,0);}
   
  P_Dist = state_function(currentMillis, (P_Dist_Duty*interval/100));
  if (P_Dist == 1){analogWrite(P2_4, 255);}
  else {analogWrite(P2_4,0);}

}
