using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class BeerEffect : MonoBehaviour {

	public Rigidbody2D player;
	public int intoxication = 0;

	// Use this for initialization
	void Start () {
		StartCoroutine (DrunkSteer());
		StartCoroutine (SoberUp ());
	}
	
	// Update is called once per frame
	void Update () {
		if (intoxication > 100) {
			intoxication = 100;
		}

		if (intoxication < 0) {
			intoxication = 0;
		}
	}

	IEnumerator DrunkSteer() {
		while (true) {
			Vector2 drunkForce = new Vector2 (0, Random.Range (-(intoxication / 1.5f), intoxication / 1.5f) + player.velocity.y * intoxication / 2f);
			player.AddForce (drunkForce);

			yield return new WaitForSeconds (0.1f);
		}
	}

	IEnumerator SoberUp() {
		while (true) {
			intoxication -= 1;
			yield return new WaitForSeconds (0.25f);
		}
	}
}
