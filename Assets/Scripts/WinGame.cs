using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour {

	public Rigidbody player;

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "Player") {
			GameControl.instance.WinGame ("You Escaped!");

			player.GetComponent<Rigidbody> ().AddForce(new Vector3(750, 0, 0));
			player.GetComponent<PlayerMovement> ().enabled = false;
		}
	}
}
