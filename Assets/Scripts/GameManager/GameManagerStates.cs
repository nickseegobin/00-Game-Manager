using UnityEngine;
using System.Collections;

public partial class GameManager : MonoBehaviour {

	//Enum for the game state
	public enum GameState{
		
		GameRunning = 1,
		GamePaused = 2,
		GameOver = 3,
		PreGame = 4,
		LiveGame = 5
		
	}
	
	//Private Variables
	public int _gameState;
	
	
	//Getters & Setters
	//return the the current Read Only GameState
	public int gameState{get{
			
		return _gameState;
	}}
	

	


}
