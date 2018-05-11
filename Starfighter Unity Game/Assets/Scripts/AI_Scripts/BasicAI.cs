using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicAI : MonoBehaviour {

	public List <Animation> evasiveManeuvers = new List<Animation> ();
	public List <Animation> cManeuvers = new List<Animation> ();

	public GameObject shipBody;

	public Transform currentTarget;

	public LockOnMeScript[] hostiles;
	public LockOnMeScript closestHostile;
	public float currentTargetDist;

	public bool onOffense;
	public bool onEvade;
	public bool onDefense;

	public float defSpeed = 1f;
	public float speedUp1 = 2f;
	public float speedUp2 = 3f;
	public float speedUp3 = 4f;

	public float interceptDist;

	public float rotSpeed = 1f;

	// Use this for initialization
	void Start () {
		hostiles = GameObject.FindObjectsOfType <LockOnMeScript> ();
		closestHostile = hostiles [0];
		currentTargetDist = Vector3.Distance (transform.position, hostiles [0].transform.position);



	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate (0, 0, defSpeed);

		foreach (LockOnMeScript player in hostiles) 
		{
			if (Vector3.Distance (transform.position, player.transform.position) < currentTargetDist) 
			{
				closestHostile = player;
				currentTargetDist = Vector3.Distance (transform.position, player.transform.position);
			}
		}

		if (onOffense == true) 
		{
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (closestHostile.transform.position - transform.position), rotSpeed * Time.deltaTime);
		}

		if (onEvade == true) 
		{
			onOffense = false;
			transform.LookAt(currentTarget);
//			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (currentTarget.transform.position - transform.position), rotSpeed * Time.deltaTime);
		}
		
	}
}
