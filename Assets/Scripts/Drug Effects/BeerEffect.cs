using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerEffect : MonoBehaviour {

	public Rigidbody player;
	public int intoxication = 0;

	// Use this for initialization
	void Start () {
		StartCoroutine (SoberUp ());
	}
	
	// Update is called once per frame
	void Update () {
		if (intoxication > 100) {
			GameControl.instance.LoseGame ("Beer");
		}

		if (intoxication < 0) {
			intoxication = 0;
		}

		Vector2 drunkForce = new Vector3 (0, Mathf.Sign(player.velocity.y) * Random.Range(intoxication / 5f, intoxication / 3f), 0);
		player.AddForce (drunkForce);
	}

	IEnumerator SoberUp() {
		while (true) {
			intoxication -= 1;
			yield return new WaitForSeconds (0.25f);
		}
	}
}
