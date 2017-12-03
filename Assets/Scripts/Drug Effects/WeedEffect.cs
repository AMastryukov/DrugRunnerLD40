using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeedEffect : MonoBehaviour {

	public Rigidbody2D player;
	public int intoxication = 0;

	private int defaultSteerForce;

	// Use this for initialization
	void Start () {
		StartCoroutine (SoberUp ());
		defaultSteerForce = player.GetComponent<PlayerMovement> ().steerForce;
	}

	// Update is called once per frame
	void Update () {
		if (intoxication > 100) {
			intoxication = 100;
		}

		if (intoxication < 0) {
			intoxication = 0;
		}

		// impair the player's steering force
		player.GetComponent<PlayerMovement> ().steerForce = defaultSteerForce - defaultSteerForce * intoxication / 100;
	}

	IEnumerator SoberUp() {
		while (true) {
			intoxication -= 1;
			yield return new WaitForSeconds (0.25f);
		}
	}
}
