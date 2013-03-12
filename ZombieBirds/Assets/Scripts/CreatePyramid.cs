using UnityEngine;
using System.Collections;

//Added some text//

public class CreatePyramid : MonoBehaviour 
{
	public GameObject cube;
	public int layers;
	
	void Start () 
	{
		for (int i = 0; i < layers; i++)
		{
			Vector3 position = this.transform.position;
			position.y += (cube.renderer.bounds.size.y / 2) + (cube.renderer.bounds.size.y * (layers - 1 - i));
			position.x -= ((cube.renderer.bounds.size.x / 2) * i);
			
			for (int u = 0; u < (i+1); u++)
			{
				Instantiate(cube,position,Quaternion.identity);
				position.x += (cube.renderer.bounds.size.x);
			}
		}
	}
}
