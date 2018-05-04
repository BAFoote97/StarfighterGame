using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour {

	public GameObject seekTarget;
	public GameObject missileLauncher;

	public float missileHealth = 1;

	public float turnSensitivity = 1.0f;
	public float moveSpeed = 1.0f;

	public float impactDamage = 1;
	public float splashDamage = 1;
	public float explosionRange = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
