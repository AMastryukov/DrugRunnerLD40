using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour {

	public Rigidbody2D player;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.name == "Player") {
			GameControl.instance.WinGame ("You Escaped!");

			player.GetComponent<Rigidbody2D> ().AddForce(new Vector2(750, 0));
			player.GetComponent<PlayerMovement> ().enabled = false;
		}
	}
}
