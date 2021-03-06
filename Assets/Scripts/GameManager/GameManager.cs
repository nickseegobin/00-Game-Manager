using UnityEngine;
using System.Collections;

/*
	Name: Game Manager Class
	Author: Nick Seegobin

	About: This partial class contains code for the state manager code	
	This section of the partial class contains the Logic for the game manager
*/
public partial class GameManager : MonoBehaviour {


	public bool _pause = false; // Pause boolean :: Initialize the pause as fals

	//Awake Method
	void Awake(){

	 


	}
	// Use this for initialization
	void Start () {


		//Call The Game Start Event
		PRE_START ();					//On Load for the first time this calls the PRE_START Event.

		//1. Initalize code : State check and load
		// if state is null load default state
		if (_gameState == 0) {

				//default game state GAMERUNNING STATE
				//ChangeState ((int)GameState.GameRunning);

		} else {
				

			GameReset();					// If the game is reloaded this method resets it
		
		}


		//2. Event Handler Initialize Method 

		EventHanlderInit ();				//This method initialized all the Event System used by the GameManage


	

	}
	
	// Update is called once per frame
	void Update () {

		//1. Game State Controller(ref# 3)
		// This method updates the different states
		StateController ();
	
	}


	//Methods


	//STATE Methods 

	//2. State Handlers
	//In this section code that controlls the different states are placed here

	//2.1 Game Running 
	public void GameRunningState(){

		//Code for Game Running State goes here!!
		//1. Time Scale 
		if (Time.timeScale != 1) {
			
			Time.timeScale = 1;	
		}

	}

	//2.2 Game Paused
	public void GamePausedState(){


		//Code for Game Paused State goes here!!
		//1. Time Scale 
		PauseGame (true);
						
	}


	//2.3 Game Over
	public void GameOverState(){


		PauseGame (true);

	}

	//Code for Game Over State goes here!!


	//3. State Controller 
	// This Method should be placed within the update 
	//method and it is responsiable for updateing all the different states

	public void StateController(){

		switch (_gameState) {
				
		case (int)GameState.running:
			GameRunningState();
			break;
		case (int)GameState.paused:
			GamePausedState();
			break;
		case (int)GameState.over:
			GameOverState();
			break;
		
		}

	}

	//4. Pause Method
	//This method pause the game
	public void PauseGame(bool b){
		
		if (b) {
			
			//User would like to pause the game 
			//Check if the game is pasued
			//if game is NOT Paused -> Pause it
			if(!_pause){
				
				_pause = true;
				PAUSE();
			}
			
		} else {
			
			
			//User would like to un-pause so check if game is paused
			//If paused un-pause
			if(_pause){
				 
				_pause = false;
				UNPAUSED();

			}
			
		}
		
	}


}
