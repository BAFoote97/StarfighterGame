using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraSwitchScript : MonoBehaviour {

	public Transform Player;
	public Camera Cam1, Cam2;
	public KeyCode TKey;
	public bool camSwitch = false;
	
	void Update()
	{
		if (Input.GetKeyDown(TKey))
		{
			camSwitch = !camSwitch;
			Cam1.gameObject.SetActive(camSwitch);
			Cam2.gameObject.SetActive(!camSwitch);
		}
	}
}
