using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {

	
	public float secondTextWaitMin;
	public float secondTextWaitMax;

	public float thirdTextWaitMin;
	public float thirdTextWaitMax;

	public GameObject textPrompt;
	private TextController textController;

	public GameObject player1;
	private bool player1Hit;
	public GameObject player2;
	private bool player2Hit;


	public GameObject bullet1;
	public GameObject bullet2;

	private bool gameOver = false;
	private GameObject winner;



	private int gameState;
	/*
	1 is "Ready" state
	2 is "Set" state
	3 is "Go!" state
	*/

	void Awake(){		
		
		gameState = 1;
		player1Hit = false;
		player2Hit = false;
		//bool gameOver = false;
	}
	// Use this for initialization
	void Start () {


		textController = textPrompt.GetComponent<TextController>();
		if (textController == null)
			Debug.Log("Could not find textController");

		StartCoroutine("setGameState");
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameOver){
			if (Input.GetKeyDown(KeyCode.A)){
				if (gameState != 3){
					gameOver = true;
					winner = player2;
					FinishGame();

				}
				bullet1.GetComponent<BulletController>().setIsFire(true);
				// the other player lost -> dont need colliders, its just who pressed first.
				//winner = player1;
				//gameOver = true;
				//StopCoroutine("setGameState");
				//textController.updateGameOver("Game Over! " + winner.name + "Won!");

			}

			if (Input.GetKeyDown(KeyCode.L)){
				if (gameState != 3){
					gameOver = true;
					winner = player1;
					FinishGame();

				}
				// the other player lost -> dont need colliders, its just who pressed first.
				//winner = player1;
				//gameOver = true;
				//StopCoroutine("setGameState");
				//textController.updateGameOver("Game Over! " + winner.name + "Won!");

				bullet2.GetComponent<BulletController>().setIsFire(true);

			}

			

		
		}
		
		if (Input.GetKeyDown(KeyCode.R)){
			SceneManager.LoadScene("Main", LoadSceneMode.Single);
		}


	}

	IEnumerator setGameState() {
		yield return new WaitForSeconds(Random.Range(secondTextWaitMin,secondTextWaitMax));
		gameState = 2;
		textController.updateText(gameState);
		//Set text to --
		yield return new WaitForSeconds(Random.Range(thirdTextWaitMin,thirdTextWaitMax));
		gameState = 3;
		textController.updateText(gameState);
		//set text to --

	}

	public void setWinner(GameObject gameWinner) {
		winner = gameWinner;
	}

	public GameObject getWinner(){
		return winner;
	}

	public void setGameOver(bool over) {
		gameOver = over;
	}

	public bool getGameOver() {
		return gameOver;
	}

	public void FinishGame() {
		StopCoroutine("setGameState");
		textController.updateGameOver("Game Over! " + winner.name + "Won! Press R to restart.");
	}

}
