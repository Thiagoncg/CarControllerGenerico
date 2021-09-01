using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	// Use this for initialization

	// reference to the right pad
	public Pad rightPad;
	//this is the car gameobject, the camera is goign to look at
	public Transform car;
	//this is the speed of the rotation of the camera
	public float speed;
	//distance of the camera
	public float distance;
	// rotation in Y and X axis
	public float Xrot, Yrot;

	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		// we rotate the camera according to the values of the pad
		Xrot-=rightPad.X*speed;
		Yrot-=rightPad.Y*speed;


		// we use spherical coordinates
		float x=distance*Mathf.Sin(Yrot)*Mathf.Sin(Xrot)  + car.transform.position[0] ;
		float z=distance*Mathf.Sin(Yrot)*Mathf.Cos(Xrot)  + car.transform.position[2];
		float y = distance * Mathf.Cos (Yrot)  + car.transform.position[1];

		transform.position = new Vector3 (x, y, z);

		transform.LookAt (car);
	}
}
