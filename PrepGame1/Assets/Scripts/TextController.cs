using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	public string text1;
	public string text2;

	public string text3;


	private Text gameText;



	void Awake(){
		
	}

	// Use this for initialization
	void Start () { 

		gameText = GetComponent<Text>();
		if (gameText == null)
			Debug.Log("Could not find gameText!");
		//Debug.Log("done textcontroller");
		
		gameText = GetComponent<Text>();
		if (gameText == null)
			Debug.Log("Could not find gameText!");
		//Debug.Log("done textcontroller");

		updateText(1);
		
	}
	
	public void updateText(int gameState) {
		switch(gameState){
			case 1:
				//Debug.Log("start");
				gameText.text = text1;
				break;
			case 2:
				gameText.text = text2;
				break;
			case 3:
				gameText.text = text3;
				break;
			default:
				break;


		}
	}

	public void updateGameOver(string text){
		gameText.text = text;
	}

	
}
