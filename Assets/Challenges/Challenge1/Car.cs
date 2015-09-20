using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {

	// These variables allow the script to power the wheels of the car.
	[SerializeField]
	private WheelCollider FrontLeftWheel;
	[SerializeField]
	private WheelCollider FrontRightWheel;
	
	// These variables are for the gears, the array is the list of ratios. The script
	// uses the defined gear ratios to determine how much torque to apply to the wheels.
	[SerializeField]
	private float[] GearRatio;
	[SerializeField]
	private int CurrentGear = 0;
	
	// These variables are just for applying torque to the wheels and shifting gears.
	// using the defined Max and Min Engine RPM, the script can determine what gear the
	// car needs to be in.
	[SerializeField]
	private float EngineTorque = 180.0f;
	[SerializeField]
	private float MaxEngineRPM = 3000.0f;
	[SerializeField]
	private float MinEngineRPM = 1000.0f;
	private float EngineRPM = 0.0f;
	
	
	
	private void Start () {
		// I usually alter the center of mass to make the car more stable. I'ts less likely to flip this way.
		GetComponent<Rigidbody>().centerOfMass += new Vector3(0, -1f, .25f);
	}
	
	private void Update () {
		
		// Compute the engine RPM based on the average RPM of the two wheels, then call the shift gear function
		EngineRPM = (FrontLeftWheel.rpm + FrontRightWheel.rpm)/2f * GearRatio[CurrentGear];
		ShiftGears();
		
		// set the audio pitch to the percentage of RPM to the maximum RPM plus one, this makes the sound play
		// up to twice it's pitch, where it will suddenly drop when it switches gears.
		GetComponent<AudioSource>().pitch = Mathf.Abs(EngineRPM / MaxEngineRPM) + 1.0f ;
		// this line is just to ensure that the pitch does not reach a value higher than is desired.
		if ( GetComponent<AudioSource>().pitch > 2.0f ) {
			GetComponent<AudioSource>().pitch = 2.0f;
		}
		
		// finally, apply the values to the wheels.	The torque applied is divided by the current gear, and
		// multiplied by the user input variable.
		FrontLeftWheel.motorTorque = EngineTorque / GearRatio[CurrentGear] * Input.GetAxis("Vertical");
		FrontRightWheel.motorTorque = EngineTorque / GearRatio[CurrentGear] * Input.GetAxis("Vertical");
		
		// the steer angle is an arbitrary value multiplied by the user input.
		FrontLeftWheel.steerAngle = 10 * Input.GetAxis("Horizontal");
		FrontRightWheel.steerAngle = 10 * Input.GetAxis("Horizontal");
	}
	
	private void ShiftGears() {
		// this funciton shifts the gears of the vehcile, it loops through all the gears, checking which will make
		// the engine RPM fall within the desired range. The gear is then set to this "appropriate" value.

		int AppropriateGear;

		if ( EngineRPM >= MaxEngineRPM ) {
			AppropriateGear = CurrentGear;
			
			for ( var i = 0; i < GearRatio.Length; i ++ ) {
				if ( FrontLeftWheel.rpm * GearRatio[i] < MaxEngineRPM ) {
					AppropriateGear = i;
					break;
				}
			}
			
			CurrentGear = AppropriateGear;
		}
		
		if ( EngineRPM <= MinEngineRPM ) {
			AppropriateGear = CurrentGear;
			
			for ( var j = GearRatio.Length - 1; j >= 0; j -- ) {
				if ( FrontLeftWheel.rpm * GearRatio[j] > MinEngineRPM ) {
					AppropriateGear = j;
					break;
				}
			}
			
			CurrentGear = AppropriateGear;
		}
	}
}
