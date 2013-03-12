using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour 
{
	//LevelLogic
	public Level1 lvl1;
	
	//Cannon
	public GameObject cannon;
	public GameObject rotateAxis;
	public float rotationSpeed;
	float rotateAngle;
	
	//Projectile
	public GameObject projectile;
	public GameObject spawnPoint;
	public float forcePerSecond;
	float launchForce;
	Vector3 launchVector;
	const float MIN_FORCE = 500.0f;
	const float MAX_FORCE = 1500.0f;
	const float MIN_ANGLE = 0.0f;
	const float MAX_ANGLE = 60.0f;
	public Rigidbody rb;
	
	//Controls
	bool up;
	bool down;
	bool left;
	
	//Initialization
	void Start () 
	{		
		rotateAngle = 0.0f;
		launchForce = MIN_FORCE;
		launchVector = Vector3.zero;
		up = false;
		down = false;
		left = false;
	}
	
	//Update
	void Update () 
	{	
		if (lvl1.GameOn())
		{
			//Controls
			if (Input.GetKeyDown(KeyCode.UpArrow))
				up = true;
			else if (Input.GetKeyUp(KeyCode.UpArrow))
				up = false;
			if (Input.GetKeyDown(KeyCode.DownArrow))
				down = true;
			else if (Input.GetKeyUp(KeyCode.DownArrow))
				down = false;
			if (Input.GetKeyDown(KeyCode.LeftArrow))
				left = true;
			else if (Input.GetKeyUp(KeyCode.LeftArrow))
				LaunchProjectile ();
			
			if (up && rotateAngle < MAX_ANGLE)
			{
				cannon.transform.RotateAround (rotateAxis.transform.position, Vector3.forward, rotationSpeed * Time.deltaTime);
				rotateAngle += (rotationSpeed * Time.deltaTime);
			}
			if (down && rotateAngle > MIN_ANGLE)
			{
				cannon.transform.RotateAround (rotateAxis.transform.position, Vector3.forward, -rotationSpeed * Time.deltaTime);
				rotateAngle += (-rotationSpeed * Time.deltaTime);
			}
				
			if (left && launchForce < MAX_FORCE)
				launchForce += forcePerSecond * Time.deltaTime;
		}
	}
	
	void LaunchProjectile ()
	{
		if (lvl1.projectilesRemain())
		{
			//Creates a New Projectile when the Left Key is Released
			GameObject newProjectile = (GameObject)Instantiate (projectile,spawnPoint.transform.position,Quaternion.identity);		
			launchVector.x = (Mathf.Cos(ConvertDegToRad(rotateAngle)) * launchForce);
			launchVector.y = (Mathf.Sin(ConvertDegToRad(rotateAngle)) * launchForce);
			newProjectile.rigidbody.AddForce(launchVector);			
			print (launchForce);
			lvl1.projectileFired();
			
			left = false;
			launchForce = MIN_FORCE;
			launchVector = Vector3.zero;
		}
	}
	
	float ConvertDegToRad (float degree)
	{
		float radian = (degree * (2 * Mathf.PI)) / 360;
		return radian;
	}
}
