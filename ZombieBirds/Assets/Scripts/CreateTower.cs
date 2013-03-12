using UnityEngine;
using System.Collections;

public class CreateTower : MonoBehaviour 
{
	public GameObject rect;
	public int layers;
	
	void Start () 
	{
		for (int i = 0; i < layers; i++)
		{
			Vector3 position = this.transform.position;
			
			//Left Leg
			position.x = this.transform.position.x - (rect.renderer.bounds.size.y / 2) + (rect.renderer.bounds.size.x / 2);
			position.y = (this.transform.position.y + (rect.renderer.bounds.size.y / 2)) + (GetHeight () * i);
			Instantiate (rect,position,Quaternion.identity);
			
			//Right Leg
			position.x = this.transform.position.x + (rect.renderer.bounds.size.y / 2) - (rect.renderer.bounds.size.x / 2);
			position.y = (this.transform.position.y + (rect.renderer.bounds.size.y / 2)) + (GetHeight () * i);
			Instantiate (rect,position,Quaternion.identity);
			
			//Top
			position.x = this.transform.position.x;
			position.y = (this.transform.position.y + rect.renderer.bounds.size.y + (rect.renderer.bounds.size.x / 2)) + (GetHeight () * i);
			Instantiate (rect,position,Quaternion.Euler(new Vector3(0.0f,0.0f,90.0f)));
			
		}
	}
	
	float GetHeight ()
	{
		float height = rect.renderer.bounds.size.y + rect.renderer.bounds.size.x;
		return height;
	}
}
