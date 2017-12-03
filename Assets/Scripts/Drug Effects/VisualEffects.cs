using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class VisualEffects : MonoBehaviour {

	public PostProcessingProfile profile;
	public GameObject player;

	void Start () {
		StartCoroutine (ProcessBeerEffect ());
		StartCoroutine (ProcessWeedEffect ());
		StartCoroutine (ProcessCocaineEffect ());
		StartCoroutine (ProcessMushroomEffect ());
	}

	void Update() {
	}

	IEnumerator ProcessBeerEffect() {
		while (true) {
			MotionBlurModel.Settings settings = profile.motionBlur.settings;

			settings.frameBlending = player.GetComponent<BeerEffect>().intoxication / 30f;
			settings.shutterAngle = (player.GetComponent<BeerEffect> ().intoxication / 75f) * 360f;

			profile.motionBlur.settings = settings;

			yield return new WaitForSeconds (0.25f);
		}
	}

	IEnumerator ProcessWeedEffect() {
		while (true) {
			BloomModel.Settings settings = profile.bloom.settings;

			settings.bloom.softKnee = player.GetComponent<WeedEffect>().intoxication / 100f;

			profile.bloom.settings = settings;

			yield return new WaitForSeconds (0.25f);
		}
	}

	IEnumerator ProcessCocaineEffect() {
		while (true) {
			ColorGradingModel.Settings settings = profile.colorGrading.settings;

			settings.basic.contrast = 1f + player.GetComponent<CocaineEffect>().intoxication / 100f;

			profile.colorGrading.settings = settings;

			yield return new WaitForSeconds (0.25f);
		}
	}

	IEnumerator ProcessMushroomEffect() {
		while (true) {
			ChromaticAberrationModel.Settings caSettings = profile.chromaticAberration.settings;
			GrainModel.Settings gSettings = profile.grain.settings;

			caSettings.intensity = player.GetComponent<MushroomEffect>().intoxication / 30f;
			gSettings.intensity = player.GetComponent<MushroomEffect>().intoxication / 60f;

			profile.chromaticAberration.settings = caSettings;
			profile.grain.settings = gSettings;

			yield return new WaitForSeconds (0.25f);
		}
	}
}
