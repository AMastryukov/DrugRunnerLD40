using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatCounter : MonoBehaviour {

	public int timeElapsed = 0;

	// Use this for initialization
	void Start () {
		StartCoroutine (CountTime());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator CountTime() {
		while (true) {
			yield return new WaitForSeconds (1);

			timeElapsed += 1;
		}
	}
}
