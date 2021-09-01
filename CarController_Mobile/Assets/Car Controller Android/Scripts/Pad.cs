using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad : MonoBehaviour {

	// Use this for initialization
	// this is the top part of the pad
	public Transform topPad;	
	// this is the initial position of the pad
	Vector3 initialPos;
	//these are the X and Y values for the pad
	public float X, Y;
	// this is the maximum radius of the pad
	public float Radi=70;
	// these are used to trigger the pad
	float startTimer, stopTimer;
	// this is the time that sets the triger 
	public float trigTime;
	// this is the triggered proprertie
	public bool triggered;



	void Start () {
		initialPos = topPad.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// this is called when dragging the pad
	public void ondrag()
	{
		// lets get the direction of the pad and the magnitude of the movement
		Vector3 vectorMovement=(Input.mousePosition-initialPos);
		float distance=(Input.mousePosition-initialPos).magnitude;

					
		// check if the distance is bigger than the radi, in this case limit the movement.
		if (distance <= Radi) {
			topPad.position = Input.mousePosition;
			// these are the projections of the pad in the X and Y direction
			X = vectorMovement [0]/Radi;
			Y = vectorMovement [1]/Radi;

		} else {
			topPad.position =initialPos+vectorMovement/distance*Radi;

			// these are the projections of the pad in the X and Y direction
			X = vectorMovement [0]/distance;
			Y = vectorMovement [1]/distance;
		}
	}
	// this is called when releasing the pad
	public void onrelease()
	{
		// reset position to the initial position of the pad
		topPad.position = initialPos;
		X = 0;
		Y = 0;
	}



	// this is called when mouse down
	public void StartTimer()
	{
		startTimer = Time.fixedTime;
	}
	// this is called when mouse up
	public void StopTimer()
	{
		stopTimer = Time.fixedTime;

		if (stopTimer - startTimer < trigTime) {
			triggered = true;
		} else {
			triggered = false;
		}
	}
}
