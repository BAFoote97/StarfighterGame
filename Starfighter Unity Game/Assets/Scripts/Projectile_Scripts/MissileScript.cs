using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour {

	public Transform seekTarget;
	public GameObject missileLauncher;

	public bool lockedOnTarget;

	public float missileHealth = 1;

	public float turnSensitivity = 1.0f;
	public float moveSpeed = 1.0f;

	public float seekTime = 1.0f;

	public float impactDamage = 1;
	public float splashDamage = 1;
	public float explosionRange = 1;

	public AudioSource bulletDestroySFX;
	public GameObject Projectile;
	public GameObject explosionArea;
	public GameObject explosionFX;
	public ParticleSystem bulletFire;
	public float explosionTime;
	public bool canPassThru;
	public BoxCollider hitBox;

	// Use this for initialization
	void Start () {
		StartCoroutine (CancelSeek ());
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0, 0, moveSpeed);

		if (seekTarget != null) 
		{
			lockedOnTarget = true;
		}
		if (seekTarget == null) 
		{
			lockedOnTarget = false;
		}

		if (lockedOnTarget == true)
		{
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (seekTarget.transform.position - transform.position), turnSensitivity * Time.deltaTime);
//			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (seekTarget.transform.position - transform.position), turnSensitivity * Time.deltaTime);
		}



	}

	void OnTriggerEnter(Collider other)
	{

			if (other.gameObject.tag == "ColObject") {
				//				Debug.Log ("Bullet hit");
				//			bulletDestroySFX.PlayOneShot (bulletDestroySFX.clip);
				//Projectile.GetComponent<MeshRenderer> ().enabled = false;
				Destroy (bulletFire);
				Destroy (Projectile);
				Destroy (hitBox);


				//this.bulletDestroySFX.GetComponent<BoxCollider> ().enabled = false;

				GameObject FX_Handler;


				FX_Handler = Instantiate (explosionFX, explosionArea.transform.position, explosionArea.transform.rotation) as GameObject;

				Destroy (this.gameObject, 0.2f);
				Destroy (FX_Handler, explosionTime);
			}
//		if (other.gameObject.tag == "Team1Player") {
//			//				Debug.Log ("Bullet hit");
//			//			bulletDestroySFX.PlayOneShot (bulletDestroySFX.clip);
//			//Projectile.GetComponent<MeshRenderer> ().enabled = false;
//			Destroy (bulletFire);
//			Destroy (Projectile);
//			Destroy (hitBox);
//
//
//			//this.bulletDestroySFX.GetComponent<BoxCollider> ().enabled = false;
//
//			GameObject FX_Handler;
//
//
//			FX_Handler = Instantiate (explosionFX, explosionArea.transform.position, explosionArea.transform.rotation) as GameObject;
//
//			Destroy (this.gameObject, 0.2f);
//			Destroy (FX_Handler, explosionTime);
//		}
		if (other.gameObject.tag == "Team2Player") {
			Debug.Log ("HitTarget");
			//				Debug.Log ("Bullet hit");
			//			bulletDestroySFX.PlayOneShot (bulletDestroySFX.clip);
			//Projectile.GetComponent<MeshRenderer> ().enabled = false;
			Destroy (bulletFire);
			Destroy (Projectile);
			Destroy (hitBox);


			//this.bulletDestroySFX.GetComponent<BoxCollider> ().enabled = false;

			GameObject FX_Handler;


			FX_Handler = Instantiate (explosionFX, explosionArea.transform.position, explosionArea.transform.rotation) as GameObject;

			Destroy (this.gameObject, 0.2f);
			Destroy (FX_Handler, explosionTime);
		}
	}

	IEnumerator CancelSeek(){
		yield return new WaitForSeconds (seekTime);
		seekTarget = null;
	}
}
