using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class VisualEffects : MonoBehaviour {

	public PostProcessingProfile profile;
	public GameObject player;

	void Start () {
		StartCoroutine (ProcessBeerEffect ());
	}

	void Update() {
	}

	IEnumerator ProcessBeerEffect() {
		while (true) {
			MotionBlurModel.Settings settings = profile.motionBlur.settings;

			settings.frameBlending = player.GetComponent<BeerEffect>().intoxication / 50f;
			settings.shutterAngle = (player.GetComponent<BeerEffect> ().intoxication / 100f) * 360f;

			profile.motionBlur.settings = settings;

			yield return new WaitForSeconds (0.25f);
		}
	}
}
