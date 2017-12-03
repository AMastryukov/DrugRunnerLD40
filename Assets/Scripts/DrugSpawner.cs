﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrugSpawner : MonoBehaviour {

	public static DrugSpawner instance;

	public Transform[] drugs;
	public Transform parent;

	void Awake() 
	{
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnRoll ());
	}

	// Update is called once per frame
	void Update () {

	}

	// 'roll the die' to decide whether to spawn drug or not
	IEnumerator SpawnRoll() {
		while (true) {
			yield return new WaitForSeconds (1.5f / GameControl.instance.scrollSpeed);

			if (Random.Range (1, 100) < 50) {
				SpawnDrug ();
			}
		}
	}

	private void SpawnDrug() {
		Vector3 spawnVector = new Vector3 (10, Random.Range (0.0f, 8.0f) - 4.0f, -1);
		Transform drug = Instantiate (drugs[Random.Range(0,4)], spawnVector, Quaternion.identity);
		drug.transform.parent = parent;
	}
}
