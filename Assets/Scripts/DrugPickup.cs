using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrugPickup : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "Player") {
			if (gameObject.tag == "Beer") {
				other.gameObject.GetComponent<BeerEffect> ().intoxication += 20;
			}

			if (gameObject.tag == "Weed") {
				other.gameObject.GetComponent<WeedEffect> ().intoxication += 20;

				// move the player back a little bit
				other.GetComponent<Rigidbody>().AddForce(new Vector3(-100, 0, 0));

				// slow down scrolling speed a little bit
				GameControl.instance.scrollSpeed -= 0.75f;
			}

			if (gameObject.tag == "Cocaine") {
				other.gameObject.GetComponent<CocaineEffect> ().intoxication += 20;

				// move the player back a little bit
				other.GetComponent<Rigidbody>().AddForce(new Vector3(225, 0, 0));

				// increase scrolling speed
				GameControl.instance.scrollSpeed += 1.5f;
			}

			Destroy (gameObject);
		}
	}
}
