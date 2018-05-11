using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargettingScript : MonoBehaviour {

	public Transform currentTarget;
	public Transform nextTarget;
	public Transform nextHostile;

	public GameObject coneCollision;

//	public Transform shipObject;
//	public float dotProd;
//	public Vector3 shipDirection;
//	public Vector3 targetPos;

	//public KeyCode RClick;

	public Transform camLookAt;

	private bool camCanLook;

	//public bool trgtSwitch = false;

	public Transform lookAtTarget;
	public Transform lookAtDef;
	public Transform camTransform;
	Vector3 defaultCamPosition = new Vector3 (0f,0f,0);

	public bool canLookAtTarget;
	public float camRotSpeed;

	public Camera cam;

	public float distance = 10.0f;
	public float currentX = 0.0f;
	public float currentY = 0.0f;
	public float sensitivityX = 4.0f;
	public float sensitivityY = 1.0f;

	// Use this for initialization
	void Start () {

		canLookAtTarget = false;
////		camTransform = transform;
//		//		cam = Camera.main;
//
//		Vector3 dir = new Vector3 (0, 0, -distance);
//		Quaternion rotation = Quaternion.Euler (lookAtDef.forward);
//		//		camTransform.position = lookAt.rotation * dir;
//		camTransform.LookAt (lookAtDef.position);
//		
	}
	
	// Update is called once per frame
	void Update () {

//		shipDirection = shipObject.transform.forward;
//		targetPos = currentTarget.forward;
//
//		dotProd = Vector3.Dot (shipDirection, targetPos);

		currentX += Input.GetAxis ("Mouse X");
		currentY += Input.GetAxis ("Mouse Y");

		if (Input.GetKeyDown ("F")) 
		{
			currentTarget = null;
			currentTarget = nextTarget;
		}

		
	}

	void LateUpdate () {



		if (Input.GetMouseButton (1)) {
//			lookAtDef.rotation = Quaternion.Slerp (lookAtDef.rotation, Quaternion.LookRotation (currentTarget.transform.position - lookAtDef.position), camRotSpeed * Time.deltaTime);
			camTransform.transform.LookAt(currentTarget);
//			StartCoroutine(CamsLookAtTarget());

		}

		if (Input.GetMouseButtonUp (1)) {
			camTransform.transform.rotation = lookAtDef.transform.rotation;

//			StopCoroutine (CamsLookAtTarget());
//			if (canLookAtTarget == true) {
//				camTransform.transform.rotation = lookAtDef.transform.rotation;
//			}
//			canLookAtTarget = false;
//			if (canLookAtTarget == false) {
//
//			}
		}
	}

//	IEnumerator CamsLookAtTarget()
//	{
//		yield return new	WaitForSeconds (0.5f);
//		canLookAtTarget = true;
//		camTransform.transform.LookAt(currentTarget);
//	}
}
