using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

	public static GameControl instance;
	public float scrollSpeed;
	public GameObject player;

	public bool gameOver = false;
	public bool crashedCar = false;

	void Awake() 
	{
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (crashedCar) {
			player.GetComponent<Rigidbody>().velocity = new Vector3(-(GameControl.instance.scrollSpeed), 0, 0);
		}
	}

	public void LoseGame(string cause) {
		if (!gameOver) {
			if (cause == "Cocaine") {
				Debug.Log ("You died at the wheel due to a cocaine overdose.");

				player.GetComponent<PlayerMovement> ().alive = false;
				StartCoroutine (DeadSteer ());
			}

			if (cause == "Beer") {
				Debug.Log ("You died at the wheel due to severe alcohol poisoning.");

				player.GetComponent<PlayerMovement> ().alive = false;
				StartCoroutine (DeadSteer ());
			}
		}

		if (cause == "Crash") {
			Debug.Log ("You crashed going at " + (GameControl.instance.scrollSpeed * 4).ToString() + " km/h.");

			crashedCar = true;
			player.GetComponent<PlayerMovement> ().alive = false;
		}

		GetComponent<DrugSpawner> ().enabled = false;
		gameOver = true;
	}

	public void WinGame(string winText) {
		if (!gameOver) {
			Debug.Log ("You win: " + winText);

			GetComponent<DrugSpawner> ().enabled = false;
			gameOver = true;
		}
	}

	IEnumerator DeadSteer() {
		while (!crashedCar) {
			player.GetComponent<Rigidbody> ().AddForce (new Vector3(0, Mathf.Sign(player.GetComponent<Rigidbody>().velocity.y) * 65f, 0));

			yield return new WaitForSeconds (0.05f);
		}
	}
}
