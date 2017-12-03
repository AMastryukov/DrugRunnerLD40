using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCrash : MonoBehaviour {

	public Rigidbody2D player;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.name == "Player") {
			GameControl.instance.LoseGame ("Crash");

			player.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Kinematic;
			player.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-(GameControl.instance.scrollSpeed), 0);
		}
	}
}
