using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMissileLauncher : MonoBehaviour {

	public List <GameObject> targets = new List<GameObject> ();

	public Transform lockedTarget;

	public float bulletLifetime = 1.0f;
	public GameObject Bullet;
	public GameObject bulletEmitter1;
	public GameObject bulletEmitter2;
	public float Bullet_Forward_Force = 1.0f;
	public bool canShoot;
	public bool heatCooldown;
	public bool cantCooldown;
	public float shootDelay = 0.1f;
	public float overHeatDelay = 1.0f;

	public Text overHeatText;

	public float laserHeat = 0;
	public float maxLaserHeat = 100;
	public float laserHeatPlus = 5;
	public float laserHeatCooldown = 10;
	public float delayBeforeCooldown = 1;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		lockedTarget = transform.GetComponent<TargettingScript> ().currentTarget;

		if (Input.GetMouseButtonDown (2)) 
		{
			//The Bullet Instantiation happens here.
			GameObject Temporary_Bullet_handler;

			Temporary_Bullet_handler = Instantiate(Bullet, bulletEmitter1.transform.position, bulletEmitter1.transform.rotation) as GameObject;
			//Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
			//This is EASILY corrected here, you might have to rotate it from a different axis and/or angle based on your particular mesh.
			Temporary_Bullet_handler.transform.Rotate(Vector3.left);

			//Retrieve the Rigidbody component from the instantiated Bullet and control it.
			Rigidbody Temporary_RigidBody;
			Temporary_RigidBody = Temporary_Bullet_handler.GetComponent<Rigidbody>();

			//Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
			Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force, ForceMode.Impulse);

			//Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
			Destroy(Temporary_Bullet_handler, bulletLifetime);
		}
		
	}
}
