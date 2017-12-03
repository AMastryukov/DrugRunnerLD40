using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private Rigidbody player;
	public int steerForce;
	public bool alive = true;

	// Use this for initialization
	void Start () {
		player = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (alive) {
			if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) {
				player.AddForce (new Vector3 (0, steerForce + GetComponent<CocaineEffect> ().intoxication / 100f - GetComponent<WeedEffect> ().intoxication / 100f, 0));
			}

			if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow)) {
				player.AddForce (new Vector3 (0, -(steerForce) - GetComponent<CocaineEffect> ().intoxication / 100f + GetComponent<WeedEffect> ().intoxication / 100f, 0));
			}

			// steering rotation
			player.GetComponent<Transform> ().eulerAngles = new Vector3 (-(player.velocity.y) * 1.5f, 
				player.GetComponent<Transform> ().eulerAngles.y, 
				player.GetComponent<Transform> ().eulerAngles.z);
		}
	}
}
