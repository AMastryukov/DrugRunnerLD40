using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeedEffect : MonoBehaviour {

	public Rigidbody player;
	public int intoxication = 0;

	// Use this for initialization
	void Start () {
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

	IEnumerator SoberUp() {
		while (true) {
			intoxication -= 1;
			yield return new WaitForSeconds (0.25f);
		}
	}
}
