#define N_POINTS 10

int JointDuty[N_POINTS];
int interval = 100;


void setup() {
  // put your setup code here, to run once:

  // set serial
  Serial.begin(9600);
  while (!Serial);
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
    duty = input.substring(0, ind).toInt();
    JointDuty[i] = duty * interval / 100;

    // shift the input
    input = input.substring(ind + 1);
  }
}

void loop() {
  // put your main code here, to run repeatedly:

}

void serialEvent() {
  String input = Serial.readString();
  parseInput(input);

  for (int i = 0; i < N_POINTS; i++) {
    Serial.write(JointDuty[i]);
  }
}
