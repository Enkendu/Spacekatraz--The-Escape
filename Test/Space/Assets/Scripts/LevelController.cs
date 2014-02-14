using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

	// Use this for initialization

	//screen resolution stuff to keep the UI in proportion to the screen.
	private float native_height = 1080;
	private float native_width = 1920;

	//pause game
	public static bool pause;

	//bool for starting the game.
	public static bool startGame;
	public static bool didDie;
	public static bool didWin;
	public static bool canFire;
	private bool playerLoose;

	private float countDownToPauseOnDeath = 6.0f;

	void Start () {
		pause = false;
		canFire = false;
		startGame = false;
		didDie = false;
		didWin = false;
		playerLoose = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//pause and unpause game from pushing p
		if(Input.GetKeyDown("p"))
		{
			//print ("p was pushed");
			pause = !pause;
			if(pause == false)
			{
				//print("Game should not be paused");
				Time.timeScale = 1.0f;
			}
			else
			{
				//print ("Game should be paused.");
				Time.timeScale = 0.0f;
			}
		}

		if(didDie == true)
		{
			//print ("did die");
			timeDownTillPause();
		}
		else
		{
			//print ("not dead");
			countDownToPauseOnDeath = Time.time + 5.0f;
		}
		//print (Time.time);
	}


	void OnGUI()
	{
		//the three following lines are what scales up/down the UI proportionatly based on the screen resolution.
		float rx = Screen.width / native_width;
		float ry = Screen.height / native_height;
		GUI.matrix = Matrix4x4.TRS (new Vector3(0, 0, 0), Quaternion.identity, new Vector3 (rx, ry, 1));

		//start //Game is paused until player pushes start buttong
		if(startGame == false)
		{
			Time.timeScale = 0.0f;
			GUI.Box(new Rect(300, 300, 300, 300), "You Broke out of Prison and are trying to escape etc etc");
			if(GUI.Button (new Rect(375, 400, 150, 100), "Start game"))
			{

				startGame = true;
				canFire = true;
				Time.timeScale = 1.0f;

				Screen.lockCursor = true;
			}
		}

		//death/lose
		if(playerLoose == true)
		{
			canFire = false;
			Time.timeScale = 0.0f;
			GUI.Box(new Rect(300, 300, 300, 300), "You Broke out of Prison and are trying to escape etc etc");
			if(GUI.Button (new Rect(375, 400, 150, 100), "Restart game"))
			{

				Application.LoadLevel("Test_WithMap");
			}
		}

		//win
		if(didWin == true)
		{
			timeDownTillPause();
			GUI.Box(new Rect(300, 300, 300, 300), "You Broke out of Prison and are trying to escape etc etc");
			if(GUI.Button (new Rect(375, 400, 150, 100), "Restart game"))
			{
	
				Application.LoadLevel("Test_WithMap");
			}
		}
	}

	void timeDownTillPause()
	{
		//print (countDownToPauseOnDeath);
		if(Time.time > countDownToPauseOnDeath)
		{
			//bring up the player lose window UI menu
			//print ("You Died! Game Paused.");
			playerLoose = true;
		}
	}
}
