using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsScript : MonoBehaviour {

	public GameObject playerObject;

	public float speedStat;
	public float maxSpeedStat;
	public float shieldHealthValue = 100.0f;
	public float maxShieldHealthValue = 100.0f;
	public float regenShieldHealthValue = 100.0f;
	public float hullHealthValue = 100.0f;
	public float maxHullHealthValue = 100.0f;

	public Vector3 prevPos;
	public Vector3 currVel;

	public float scoreValue;

	public Text speedNumberIndic;
	public Text shieldNumberIndic;
	public Text hullNumberIndic;
	public Text scoreIndic;

	public Slider speedMeterIndic;
	public Slider shieldMeterIndic;
	public Slider hullMeterIndic;
	public Slider laserHeatMeter1, laserHeatMeter2;

	public float laserHeatValue;
	public float maxLaserHeatValue;
	public float laserHeatPlusValue;
	public float laserHeatCooldownValue;

//	public static Player_Control playerRef;
//	public static PlayerPrimaryLaserScript laserRef;

	float CalculateSpeed()
	{
		return speedStat / maxSpeedStat;
	}

	float CalculateShield()
	{
		return shieldHealthValue / maxShieldHealthValue;
	}
		
	float CalculateHull()
	{
		return hullHealthValue / maxHullHealthValue;
	}

	void OnGUI()
	{



	}

	// Use this for initialization
	void Start () {
		StartCoroutine( CalcVelocity() );


//		gameObject.GetComponent<Player_Control> ().speedValue = speedStat;

	}
	
	// Update is called once per frame
	void Update () {


		if (shieldHealthValue < maxShieldHealthValue) {
			shieldHealthValue += regenShieldHealthValue * Time.deltaTime;
			if (shieldHealthValue > maxShieldHealthValue) 
			{
				shieldHealthValue = maxShieldHealthValue;
			}


		}

		speedMeterIndic.value = speedStat * 50;
		speedMeterIndic.maxValue = maxSpeedStat * 50;
		shieldMeterIndic.value = shieldHealthValue;
		hullMeterIndic.value = hullHealthValue;
		laserHeatMeter1.value = laserHeatValue;
		laserHeatMeter2.value = laserHeatValue;

		speedNumberIndic.text = speedStat.ToString ("F0");
		shieldNumberIndic.text = shieldHealthValue.ToString ("F0");
		hullNumberIndic.text = hullHealthValue.ToString ("F0");
		scoreIndic.text = scoreValue.ToString ("F0");
		
	}

	IEnumerator CalcVelocity()
	{
		while( Application.isPlaying )
		{
			// Position at frame start
			prevPos = gameObject.transform.position;
			// Wait till it the end of the frame
			yield return new WaitForEndOfFrame();
			// Calculate velocity: Velocity = DeltaPosition / DeltaTime
			currVel = (prevPos - gameObject.transform.position) / Time.deltaTime;
			//Debug.Log( currVel );
		}
	}
}