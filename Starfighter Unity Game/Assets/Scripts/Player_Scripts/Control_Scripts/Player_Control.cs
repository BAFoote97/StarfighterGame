using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player_Control : MonoBehaviour {

	//public List<GameObject> bulletEmitter = new List<GameObject> (1);
		

		//public float VRotSpeed = 2F;
		//public float HRotSpeed = 2F;
		public float speedValue;
		public float speedChangeVal;
		public float speedChangeDef = 1f;
		public float speedChange1 = 1f;
		public float speedChange2 = 0.75f;
		public float speedChange3 = 0.5f;
		public float changeThresh1 = 2f;
		public float changeThresh2 = 2f;
		public float changeThresh3 = 3f;
		public float DefaultSpeed = 1f;
		public float goToDefault = 1f;
		public float TopSpeed = 2f;
		public float MinSpeed = -0f;
		public float StarfighterRoll = 1f;

	public static float speedValueToScript;
	public static float TopSpeedToScript;

		public bool speedGoesDef;

		
		CharacterController Player;
		
		float moveFB;
		float moveLR;
		
		public float XSensitivty = 1f;
		public float YSensitivty = 1f;
		float RotX;
		float RotY;
		
	private bool SpeedUp;
	private bool SpeedDown;

	void StaticValues()
	{
		speedValueToScript = speedValue;
		TopSpeedToScript = TopSpeed;
	}
		
		// Use this for initialization
		void Start()
		{
			Cursor.lockState = CursorLockMode.Locked;
			
			Player = GetComponent<CharacterController> ();
		speedChangeVal = speedChangeDef;	

		speedValue = DefaultSpeed;
			
		}
		
	void ChangetheSpeed()
	{
		if (speedValue > changeThresh1) 
		{
			speedChangeVal = speedChange1;
		}
		if (speedValue < changeThresh1) 
		{
			speedChangeVal = speedChangeDef;
		}

		if (speedValue > changeThresh2) 
		{
			speedChangeVal = speedChange2;
		}

		if (speedValue < changeThresh2) 
		{
			speedChangeVal = speedChange1;
		}

		if (speedValue > changeThresh3) 
		{
			speedChangeVal = speedChange3;
		}

		if (speedValue < changeThresh3) 
		{
			speedChangeVal = speedChange2;
		}
	}
		
		// Update is called once per frame
	void Update()
	{

		gameObject.GetComponent<PlayerStatsScript> ().speedStat = speedValue * 50;
		gameObject.GetComponent<PlayerStatsScript> ().maxSpeedStat = TopSpeed * 50;


		
		if (speedValue > TopSpeed) 
		{
			speedValue = TopSpeed;
		}

		if (speedValue < MinSpeed) 
		{
			speedValue = MinSpeed;
		}

		if (speedValue > DefaultSpeed) 
		{
			if (speedGoesDef) 
			{
				speedValue -= DefaultSpeed * Time.deltaTime;
			}
		}

		if (speedValue < DefaultSpeed) 
		{
			if (speedGoesDef) 
			{
				speedValue += DefaultSpeed * Time.deltaTime;
			}
		}





			//translation = Input.GetAxis("Vertical") * speed;
			//straffe = Input.GetAxis("Horizontal") * speed;
			
			//moveFB = Input.GetAxis ("Vertical") * VRotSpeed;
			//moveLR = Input.GetAxis ("Horizontal") * HRotSpeed;
			
			RotX = Input.GetAxis ("Mouse X") * XSensitivty;
			RotY = Input.GetAxis ("Mouse Y") * -YSensitivty;
			transform.Rotate (RotY, RotX, 0);
			
		transform.Translate(0, 0, speedValue);
			{
					if (Input.GetKey ("w")) 
						{
						speedValue += speedChangeVal * Time.deltaTime; // Cap at some max value too
						//transform.Translate (0, 0, TopSpeed);
						speedGoesDef = false;
						} 
					else 
						{
						speedGoesDef = true;
						}
				
					if (Input.GetKey ("s")) {
						speedValue -= speedChangeVal * Time.deltaTime; // Cap at some min value too
						//transform.Translate (0, 0, MinSpeed);
						speedGoesDef = false;
					} 
//					else 
//						{
//						speedGoesDef = true;
//						}


				if (Input.GetKey ("a"))
					transform.Rotate (0, 0, StarfighterRoll);
				if (Input.GetKey ("d"))
					transform.Rotate (0, 0, -StarfighterRoll);
			}


			
			
			if (Input.GetKeyDown("escape"))
				Cursor.lockState = CursorLockMode.Confined;
			
		}


	
}
