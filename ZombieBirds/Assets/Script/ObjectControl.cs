using UnityEngine;
using System.Collections;



public class Control1 : MonoBehaviour 
{
	
	//Mouse//
	private Vector3 screenPoint;
	private Vector3 offset;
	
	private Vector3 initial;
	private Vector3 current;
	private Vector3 released;
	private int power;
	private bool rest;
	private bool shot;
	public GameObject ammo;
	
	
	// Use this for initialization
	void Start () 
	{
		//saves the initial position of the ammo//
		initial = ammo.transform.position;
		//Sets the ammo to "float" when the user hasnt touched it yet
		rest = true;
		shot = false;
		power = 10;
		ammo.rigidbody.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		current = ammo.transform.position;
	}

	void OnMouseDown()
	{
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		//ammo.transform.position = CircleClamp(newPos, initPos, radius);
		rest = false;
	}
	
	void OnMouseUp()
	{
		released = initial - current;
		if(!shot && !rest)
		{
			ammo.rigidbody.isKinematic = false;
			ammo.rigidbody.AddForce(released * power, ForceMode.Impulse);
			shot = true;
		}
		else
		{
			Vector3.Lerp(ammo.transform.position, initial, 10*Time.deltaTime);
		}
	}
	
	void OnMouseDrag()
	{
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);    
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		ammo.transform.position = curPosition;
	}
	
//	Vector3 CircleClamp(Vector3 pos, Vector3 center, float rad)
//	{
//		Vector3 offset = pos - center;
//		float distance = offset.magnitude;
//		if (distance<rad*.2) 
//		{
//			rest = true;
//		} 
//		else 
//		{
//			rest = false;
//		}
//		if (rad < distance) 
//		{
//			Vector2 direction = offset/distance;
//			pos = center+direction*rad;
//		}
//			return pos;
//	}
	
}
