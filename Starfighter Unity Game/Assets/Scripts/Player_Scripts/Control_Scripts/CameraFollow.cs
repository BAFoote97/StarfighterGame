using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {



	public Transform lookAtTarget;
	public Transform lookAtDef;
	public Transform camTransform;

	public Camera cam;

	public float distance = 10.0f;
	public float currentX = 0.0f;
	public float currentY = 0.0f;
	public float sensitivityX = 4.0f;
	public float sensitivityY = 1.0f;

	private void Start ()
	{
		camTransform = transform;
//		cam = Camera.main;

		Vector3 dir = new Vector3 (0, 0, -distance);
		Quaternion rotation = Quaternion.Euler (lookAtDef.forward);
		//		camTransform.position = lookAt.rotation * dir;
		camTransform.LookAt (lookAtDef.position);
	}

	private void Update()
	{
		currentX += Input.GetAxis ("Mouse X");
		currentY += Input.GetAxis ("Mouse Y");
	}

	private void LateUpdate ()
	{
		if (Input.GetMouseButton (1)) {
			Vector3 dir = new Vector3 (0, 0, -distance);
			Quaternion rotation = Quaternion.Euler (lookAtTarget.forward);
//		camTransform.position = lookAtTarget.rotation * dir;
			camTransform.LookAt (lookAtTarget.position);
		}

		if (Input.GetMouseButtonUp (1)) {
//			Vector3 dir = new Vector3 (0, 0, -distance);
//			Quaternion rotation = Quaternion.Euler (lookAtDef.forward);
//			camTransform.position = lookAtDef.position + rotation * dir;
//			camTransform.LookAt (lookAtDef.position);

		}
	}
}
