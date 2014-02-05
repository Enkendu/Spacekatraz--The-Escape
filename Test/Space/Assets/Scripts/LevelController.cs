using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

	// Use this for initialization

	//screen resolution stuff to keep the UI in proportion to the screen.
	private float native_height = 1080;
	private float native_width = 1920;

	//bool for starting the game.
	public static bool startGame;
	public static bool didDie;
	public static bool didWin;
	public static bool canFire;

	void Start () {
		canFire = false;
		startGame = false;
		didDie = false;
		didWin = false;
	}
	
	// Update is called once per frame
	void Update () {
	
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
		if(didDie == true)
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
			canFire = false;
			Time.timeScale = 0.0f;
			GUI.Box(new Rect(300, 300, 300, 300), "You Broke out of Prison and are trying to escape etc etc");
			if(GUI.Button (new Rect(375, 400, 150, 100), "Restart game"))
			{
	
				Application.LoadLevel("Test_WithMap");
			}
		}
	}
}
