using UnityEngine;
using System.Collections;

public partial class GameManager : MonoBehaviour {

	//Enum for the game state
	public enum GameState{
		
		running = 1,					//Running State Of the Game, start and live state
		paused = 2,						//Paused State Of The Game
		over = 3,						//Game Over State Of The Game, End the game here
		pre_start = 4,					//This is the Pre Start, The point where you load or just do pre-game stuff
		pre_over = 5					//Pre Game Over, Do all post game calculations here
		
	}
	
	//Private Variables
	private int _gameState;				//The GameState Variable, This holds a refference to the game state
	
	
	//Getters & Setters
	//return the the current READ ONLY GameState
	public int gameState{get{
			
		return _gameState;
	}}


	//1. Change State Method
	// This method is used to change the state of the game
	public void ChangeState(int state){
		
		switch (state) {
			
		case (int)GameState.running:
			//a. Game Running State
			if(state == (int)GameState.running){
				
				//Game Running Code Goes Here
				_gameState = (int)GameState.running;
				
			}
			break;
		case (int)GameState.paused:
			//b. Game Paused State
			if(state == (int)GameState.paused){
				
				//Game Paused Code Goes Here
				_gameState = (int)GameState.paused;
				
			}
			break;
		case (int)GameState.over:
			//c. Game Ended State
			if(state == (int)GameState.over){
				
				//Game Ended   Code Goes Here
				_gameState = (int)GameState.over;
				
			}
			break;
			
		}
		
		//State Changed
		Debug.Log("State Hase Been Changed" + "  " + (GameState)_gameState);
	} // End of the Change State Method


	


}
