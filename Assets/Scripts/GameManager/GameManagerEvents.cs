using UnityEngine;
using System.Collections;

public partial class GameManager : MonoBehaviour {

	//Game Event System System
	public delegate void GameStateEvent();
	public static event GameStateEvent START;
	public static event GameStateEvent PAUSE; 
	public static event GameStateEvent UNPAUSED;
	public static event GameStateEvent GAME_OVER; 
	public static event GameStateEvent RESET;



	//Event Handlers Init Method
	//This method should be placed in the AWAKE or Start Method Within the MonoBehavour method
	void EventHanlderInit(){

		//Event Handlers Initialize
		Player.OnDeath += OnDeath;				//This statment handles when the player dies
		PAUSE += OnPauseHandler;				//The OnPauseEventHandler, See description bellow.
		UNPAUSED += OnUnPauseHandler;
		START += GameReset;
	
	}

	void EventHandlersRemove(){

	
		//Event Handlers Remove
		Player.OnDeath -= OnDeath;				//This statment handles when the player dies
		PAUSE -= OnPauseHandler;				//The OnPauseEventHandler, See description bellow.
		UNPAUSED -= OnUnPauseHandler;
		START -= GameReset;
	
	}


	//Event Handlers

	//1. The OnStartHander Method is called when a new game starts
	public void OnStartHandler(){
			
		//Code for on start goes here
		//This Method Resets the game
		ChangeState((int)GameState.GameRunning);
		
		//Set Pause to false
		PauseGame (false);
	
	}

	//2. The OnPause Handler is called when the game goes into a Pause state
	public void OnPauseHandler(){

		//Pause Code Goes Here
		//This Code Here Sets time scale zero
		if (Time.timeScale != 0) {
			
			Time.timeScale = 0;	
		}
		
		//Set The Game State
		ChangeState ((int)GameState.GamePaused);			//This Chanages the state within the manager to Paused State
	}


	//3. The OnUnPausedHander is called when the game comes out of a paused state
	public void OnUnPauseHandler(){
		
		

		//UnPause Code Goes Here
		//This Code Here Sets time scale One
		if (Time.timeScale != 1) {
			
			Time.timeScale = 1;	
		}
		
		
		//Set The Game State
		ChangeState ((int)GameState.GameRunning);			//This Chanages the state within the manager to Paused State
		
	}
	

	//4. The OnDeath Handler is called when the game is Over
	public void OnDeath(string msg){
		
		//Display Message
		Debug.Log (msg);
		
		//Change The Game State
		ChangeState ((int)GameState.GameOver);
		
		//Send Game Over Event
		GAME_OVER ();



		
		
	}
	
	//6. Game Reset
	public void GameReset(){
		
		//This Method Resets the game
		ChangeState((int)GameState.GameRunning);

		//Remove Event Handlers
		EventHandlersRemove ();						//This Removes All The Event Handlers In Play

		//Set Pause to false
		PauseGame (false);
		
	}
}
