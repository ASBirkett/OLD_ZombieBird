using UnityEngine;
using System.Collections;

public class DestroyTest : MonoBehaviour {

    public GameObject test;
    bool alive = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(Input.GetKeyDown("space"))
        {
            test.SetActiveRecursively(false);
            Debug.Log("Deactivate");
        }
        else{
            test.SetActiveRecursively(true);
            Debug.Log("activated");
        }
        alive = !alive;	
	}
}
