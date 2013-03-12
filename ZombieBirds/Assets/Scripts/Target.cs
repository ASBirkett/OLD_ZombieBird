using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour 
{
	public Level1 lvl1;
	bool hit = false;
	
	void OnCollisionEnter (Collision collision)
	{				
		if (!hit)
		{
			hit = true;
			this.rigidbody.useGravity = true;			
			lvl1.targetHit();
		}		
	}
}
