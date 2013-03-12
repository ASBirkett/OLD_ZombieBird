using UnityEngine;
using System.Collections;

public class Level1 : MonoBehaviour 
{
	public int targetsRemaining;
	public int projectilesRemaining;
	float timer;
	bool gameOn;
	
	//Win and Lose Condition Objects
	public GameObject camera;
	public GUIText winScreen;
	bool stateTriggered; //Temp for Running Lose/Win Only Once
	
	void Start () 
	{	
		timer = 10.0f;
		gameOn = true;
		stateTriggered = false;
	}
	
	void Update () 
	{			
		if (targetsRemaining == 0)
			GameWin ();
		else if (projectilesRemaining == 0 && targetsRemaining > 0 && timer > 0)
		{
			timer -= Time.deltaTime;
			print (timer);
		}
		
		if (timer <= 0.0f)
			GameLose();		
	}
	
	public void targetHit ()
	{
		targetsRemaining--;
	}
	public void projectileFired ()
	{
		projectilesRemaining--;
	}
	void GameWin()
	{
		if (!stateTriggered)
		{
			gameOn = false;
			stateTriggered = true;
			
			Vector3 position = camera.transform.position;
			position.z += 5.0f;		
			position.x -= 4.0f;
			position.y += 1.0f;
			
			winScreen.text = "YOU WIN!";
			winScreen.material.color = Color.green;
			Instantiate (winScreen,Camera.main.WorldToViewportPoint(position),Quaternion.identity);
		}
	}
	void GameLose()
	{		
		if (!stateTriggered)
		{
			gameOn = false;
			stateTriggered = true;
			
			Vector3 position = camera.transform.position;
			position.z += 5.0f;
			position.x -= 4.0f;
			position.y += 1.0f;

			winScreen.text = "YOU LOSE";
			winScreen.material.color = Color.red;
			Instantiate (winScreen,Camera.main.WorldToViewportPoint(position),Quaternion.identity);
		}
	}
	
	//Returns True if the Player has neither Won nor Lost
	public bool GameOn ()
	{
		return gameOn;
	}
	
	//Returns True if Projectiles Remain
	public bool projectilesRemain ()
	{
		if (projectilesRemaining > 0)
			return true;
		return false;
	}
}
