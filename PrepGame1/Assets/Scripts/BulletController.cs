using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	public Vector3 targetDestination;

	private Rigidbody rigidBody;

	private bool isFire;

	public float speed;

	public GameObject gameManager;
	private GameManager gameManagerScript;

	public int direction;


	void Awake() {
	
	}
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody>();
		if (rigidBody == null){
			Debug.Log("Could not find rigidbody");
		}

		gameManagerScript = gameManager.GetComponent<GameManager>();
		if (gameManagerScript == null) {
			Debug.Log("Could not find gameManagerScript");
		}
		
		isFire = false;

	}
	
	// Update is called once per frame
	void Update () {


	}

	void FixedUpdate() {
		if (isFire && !gameManagerScript.getGameOver()) {

			if (Vector3.Distance(transform.position,targetDestination) > 0.5f)
			{
				rigidBody.MovePosition((transform.position) + (new Vector3((1f* direction),0f,0f)* speed * Time.deltaTime));
			
			}
		}
		
		

	}


	public void setIsFire(bool fire) {
		isFire = fire;
	}

	public void OnTriggerEnter(Collider other) {
		Debug.Log("hit " + other.name);
		if (other.tag == "Player") {
			//stop the game
			//set one player as the winner

			
			gameManagerScript.setWinner(other.gameObject);
			gameManagerScript.setGameOver(true);
			gameManagerScript.FinishGame();
		}
	}

	
}
