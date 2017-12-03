using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrugPickup : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.name == "Player") {
			if (gameObject.tag == "Beer") {
				other.gameObject.GetComponent<BeerEffect> ().intoxication += 20;
			}

			if (gameObject.tag == "Weed") {
				other.gameObject.GetComponent<WeedEffect> ().intoxication += 20;

				// move the player back a little bit
				other.GetComponent<Rigidbody2D>().AddForce(new Vector2(-100, 0));

				// slow down scrolling speed a little bit
				GameControl.instance.scrollSpeed -= 0.5f;
			}

			if (gameObject.tag == "Cocaine") {
				other.gameObject.GetComponent<CocaineEffect> ().intoxication += 20;

				// move the player back a little bit
				other.GetComponent<Rigidbody2D>().AddForce(new Vector2(150, 0));

				// increase scrolling speed
				GameControl.instance.scrollSpeed += 0.75f;
			}

			Destroy (gameObject);
		}
	}
}
