using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

	public static GameControl instance;
	public float scrollSpeed;
	public GameObject player;
	public bool gameOver = false;

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
		
	}

	public void LoseGame(string cause) {
		if (!gameOver) {
			if (cause == "Cocaine") {
				Debug.Log ("You died at the wheel due to a cocaine overdose.");

				StartCoroutine (CrashCar());
				player.GetComponent<PlayerMovement> ().enabled = false;
			}

			if (cause == "Beer") {
				Debug.Log ("You died at the wheel due to severe alcohol poisoning.");

				StartCoroutine (CrashCar());
				player.GetComponent<PlayerMovement> ().enabled = false;
			}

			if (cause == "Crash") {
				Debug.Log ("You crashed going at " + (GameControl.instance.scrollSpeed * 5).ToString() + " km/h.");

				player.GetComponent<PlayerMovement> ().enabled = false;
			}

			GetComponent<DrugSpawner> ().enabled = false;
			gameOver = true;
		}
	}

	public void WinGame(string winText) {
		if (!gameOver) {
			Debug.Log ("You win: " + winText);

			GetComponent<DrugSpawner> ().enabled = false;
			gameOver = true;
		}
	}

	IEnumerator CrashCar() {
		while (true) {
			player.GetComponent<Rigidbody2D> ().AddForce(player.GetComponent<Rigidbody2D> ().velocity * 25f);

			yield return new WaitForSeconds (0.1f);
		}
	}
}
