using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

	// Use this for initialization

	//screen resolution stuff to keep the UI in proportion to the screen.
	private float native_height = 1080;
	private float native_width = 1920;

	//textures and GUIStyles for the health bar
	public Texture redHealthBar;
	public Texture greenHealthBar;
	public GUISkin redHealthBarSkin;
	public GUISkin greenHealthBarSkin;
	float healthPercent;

	//pause game
	public static bool pause;

	//player space ship object
	public GameObject playerShip;
	//player Hit points
	float playerHP;
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
		if(playerShip != null)
		{
			playerHP = playerShip.GetComponent<ShipHitPoints>().hitPoints;

			healthPercent = ((playerHP/100.0f) * 400.0f);
		}
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


		//player health bar. (not sure if this would be better to add to the ship script or not)
		GUI.Box (new Rect(860, 980, 200, 100), playerHP.ToString() );

		//health bars
		GUI.skin = redHealthBarSkin;
		GUI.Box (new Rect(760, 1020, 400, 33), " ");
		GUI.skin = greenHealthBarSkin;
		GUI.Box (new Rect(760, 1020, healthPercent, 33), " ");
		GUI.skin = null;

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
