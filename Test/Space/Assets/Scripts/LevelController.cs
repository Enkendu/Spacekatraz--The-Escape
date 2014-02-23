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
	public AudioClip backGroundMusic;
	public AudioClip deathMusic;
	public AudioClip victoryMusic;
	public AudioClip mainBadGuy;
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


	//dialog images and switches
	public static bool dialogZero;
	public static bool dialogOne;
	public static bool dialogTwo;
	public static bool dialogThree;
	public static bool dialogFour;
	//dialog skins
	public GUISkin dialogZeroSkin;
	public GUISkin dialogOneSkin;
	public GUISkin dialogTwoSkin;
	public GUISkin dialogThreeSkin;
	public GUISkin dialogFourSkin;
	//startskin
	public GUISkin startSkin;
	public GUISkin loseSkin;
	public GUISkin winSkin;
	//dialog timer
	float dialogTimer = 0.0f;
	public float dialogSetTime = 9.0f;



	void Start () {
		//AI dialog scripts
		dialogOne = false;
		dialogTwo = false;
		dialogThree = false;
		dialogFour = false;

		pause = false;
		canFire = false;
		startGame = false;
		didDie = false;
		didWin = false;
		playerLoose = false;
		audio.clip = backGroundMusic;
		audio.Play();
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
			audio.clip = deathMusic;
			if(audio.isPlaying == false)
			{
				audio.Play();
			}
			timeDownTillPause();
		}
		else
		{
			//print ("not dead");
			countDownToPauseOnDeath = Time.time + 5.0f;
		}
		//print (Time.time);

		if((dialogOne == true || dialogTwo == true || dialogThree == true || dialogFour == true || dialogZero == true))
		{
			if(Time.time > dialogTimer)
			{
				dialogZero = false;
				dialogOne = false;
				dialogTwo = false;
				dialogThree = false;
				dialogFour = false;
			}
		}
		else
		{
			dialogTimer = Time.time + dialogSetTime;
		}

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
			GUI.skin = startSkin;
			Time.timeScale = 0.0f;
			GUI.Box(new Rect(0, 0, 750, 305.5f), " ");
			if(GUI.Button (new Rect(457, 50, 125, 75), "Push to start game"))
			{
				dialogZero = true;
				startGame = true;
				canFire = true;
				Time.timeScale = 1.0f;

				Screen.lockCursor = true;
			}
		}

		//death/lose
		if(playerLoose == true)
		{
			GUI.skin = loseSkin;
			canFire = false;
			Time.timeScale = 0.0f;
			GUI.Box(new Rect(0, 0, 750, 305.5f), "You Lose! Try again");
			if(GUI.Button (new Rect(457, 50, 125, 75), "Main Menu"))
			{

				Application.LoadLevel("MainMenu");
			}
		}

		//win
		if(didWin == true)
		{
			audio.clip = victoryMusic;
			if(audio.isPlaying == false)
			{
				audio.Play();
			}
			GUI.skin = winSkin;
			timeDownTillPause();
			GUI.Box(new Rect(0, 0, 750, 305.5f), " ");
			if(GUI.Button (new Rect(457, 50, 125, 75), "Main Menu"))
			{
	
				Application.LoadLevel("MainMenu");
			}
		}
		if(dialogZero == true)
		{
			GUI.skin = dialogZeroSkin;
			GUI.Box(new Rect(0, 0, 750, 305.5f), " ");
		}

		if(dialogOne == true)
		{
			//dialogTimer = Time.time + dialogSetTime;
			GUI.skin = dialogOneSkin;
			GUI.Box(new Rect(0, 0, 750, 305.5f), " ");
		}

		if(dialogTwo == true)
		{
			//dialogTimer = Time.time + dialogSetTime;
			GUI.skin = dialogTwoSkin;
			GUI.Box(new Rect(0, 0, 750, 305.5f), " ");
		}

		if(dialogThree == true)
		{
			//dialogTimer = Time.time + dialogSetTime;
			GUI.skin = dialogThreeSkin;
			GUI.Box(new Rect(0, 0, 750, 305.5f), " ");
		}

		if(dialogFour == true)
		{
			//dialogTimer = Time.time + dialogSetTime;
			//audio.Stop ();
			audio.clip = mainBadGuy;
			if(!audio.isPlaying)
			{
				audio.Play();
			}
			GUI.skin = dialogFourSkin;
			GUI.Box(new Rect(0, 0, 750, 305.5f), " ");
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
