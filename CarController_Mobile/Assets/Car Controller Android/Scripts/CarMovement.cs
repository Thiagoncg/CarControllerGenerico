using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour {

	// Use this for initialization


	//these are the two wheels that move when moving the pad
	public Transform wheelL, wheelR,wheelLr, wheelRr;
    // this is the reference to the left pad
    public Pad leftPad;
	// this is the factor applied to the pad value for the rotation of the wheel
	public float rotFactor=20;
	//this is the movement speed
	public float speed=5, rotSpeed=2;

	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		// wheel movement according to the X value of the pad
		wheelL.localRotation = Quaternion.Euler (0,rotFactor*leftPad.X -90, wheelL.parent.GetComponent<WheelCollider>().rpm);
		wheelR.localRotation = Quaternion.Euler (0,rotFactor*leftPad.X +90, wheelR.parent.GetComponent<WheelCollider>().rpm);

        wheelLr.localRotation = Quaternion.Euler(0, - 90, wheelLr.parent.GetComponent<WheelCollider>().rpm);
        wheelRr.localRotation = Quaternion.Euler(0, + 90, wheelRr.parent.GetComponent<WheelCollider>().rpm);


        //movement of the car according to the value of X and Y of the pad break if its near to 0
        if (Mathf.Abs(leftPad.Y)>0.2f)
        {
            wheelL.parent.GetComponent<WheelCollider>().motorTorque = speed * leftPad.Y;
            wheelR.parent.GetComponent<WheelCollider>().motorTorque = speed * leftPad.Y;
        }
        else
        {
            wheelL.parent.GetComponent<WheelCollider>().motorTorque = - Vector3.Dot(transform.GetComponent<Rigidbody>().velocity,transform.forward)*speed;
            wheelR.parent.GetComponent<WheelCollider>().motorTorque = -Vector3.Dot(transform.GetComponent<Rigidbody>().velocity, transform.forward)*speed;
            
        }

        //rotation is opposite when going backwards:
        wheelL.parent.GetComponent<WheelCollider>().steerAngle = rotSpeed * leftPad.X;
        wheelR.parent.GetComponent<WheelCollider>().steerAngle = rotSpeed * leftPad.X;

        
 



    }




}
