using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

	public static GameControl instance;
	public float scrollSpeed;
	public GameObject player;

	public Text gameOverText;

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

		if (gameOver) {
			if (Input.GetKey (KeyCode.Space)) {
				SceneManager.LoadScene ("GameScene");
			}
		}
	}

	public void LoseGame(string cause) {
		if (!gameOver) {
			gameOverText.text = "GAME OVER\n";

			if (cause == "Cocaine") {
				gameOverText.text += "You died at the wheel due to a cocaine overdose.\n";

				player.GetComponent<PlayerMovement> ().alive = false;
				StartCoroutine (DeadSteer ());
			}

			if (cause == "Beer") {
				gameOverText.text += "You died at the wheel due to severe alcohol poisoning.\n";

				player.GetComponent<PlayerMovement> ().alive = false;
				StartCoroutine (DeadSteer ());
			}
		}

		if (cause == "Crash") {
			gameOverText.text += "You crashed going at " + (GameControl.instance.scrollSpeed * 4).ToString() + " km/h.\n";

			if (player.GetComponent<BeerEffect> ().intoxication > 25) {
				gameOverText.text += "Your blood alcohol content was " + (player.GetComponent<BeerEffect>().intoxication * 0.005).ToString() + "%.\n";
			}

			gameOverText.text += "\nPress Space to try again.";

			crashedCar = true;

			player.GetComponent<PlayerMovement> ().alive = false;
		}

		GetComponent<DrugSpawner> ().enabled = false;
		gameOver = true;
	}

	public void WinGame(string winText) {
		if (!gameOver) {
			gameOverText.text = "GAME OVER\n";
			gameOverText.text += "You successfully escaped to Mexico alive.\n\n";
			gameOverText.text += "Press space to play again.";

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
