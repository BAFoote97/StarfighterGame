using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MarkerScript : MonoBehaviour {

	//public Camera MyCamera;
	public float objectScale = 1.0f; 
	private Vector3 initialScale; 

	public float distanceValue;
	public  Text distanceLabel;
	public GameObject playerObject;
	public GameObject currentObject;

	// set the initial scale, and setup reference camera
	void Start ()
	{
		// record initial scale, use this as a basis
		initialScale = transform.localScale; 
		
		// if no specific camera, grab the default camera
		//if (MyCamera == null)
			//MyCamera = Camera.main; 
	}

	
	// Update is called once per frame
	void Update () {

		transform.LookAt (transform.position + Camera.current.transform.rotation * Vector3.forward,
			Camera.current.transform.rotation * Vector3.up);
		Plane plane = new Plane(Camera.current.transform.forward, Camera.current.transform.position);
		float dist = plane.GetDistanceToPoint(transform.position); 
		transform.localScale = initialScale * dist * objectScale; 

		distanceValue = Vector3.Distance(playerObject.transform.position,currentObject.transform.position); 

		distanceLabel.text = distanceValue.ToString ("F0");
	
	}
}
