using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCrash : MonoBehaviour {

	public Rigidbody player;

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "Player") {
			GameControl.instance.LoseGame ("Crash");
		}
	}
}
