using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	public float bulletDmg = 1f;

	public AudioSource bulletDestroySFX;
	public GameObject Projectile;
	public GameObject explosionArea;
	public GameObject explosionFX;
	public ParticleSystem bulletFire;
	public float explosionTime;
	public bool canPassThru;
	public BoxCollider hitBox;

	public Animation bulletPath;

	// Use this for initialization
	void Start () {
		bulletPath.Play ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (canPassThru == false) {

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
		}
	}
}
