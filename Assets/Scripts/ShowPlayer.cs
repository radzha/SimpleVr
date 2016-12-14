using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPlayer : MonoBehaviour, IGvrGazeResponder {
	public float ShowDelay = 1f;
	private GvrViewer viewer;

	private bool showed;
	private Material material;

	private void Awake() {
		material = GetComponent<MeshRenderer>().material;
		viewer = FindObjectOfType<GvrViewer>();
		print(viewer);
	}

	void IGvrGazeResponder.OnGazeEnter() {
		Show(true);
	}

	void IGvrGazeResponder.OnGazeExit() {
		Show(false);
	}

	void IGvrGazeResponder.OnGazeTrigger() {
		print("Trigger");
	}

	private void Show(bool show) {
		showed = show;
//		viewer.VRModeEnabled = !viewer.VRModeEnabled;
		if (this != null) {
			StartCoroutine(ShowSlowly(show));
		}
	}

	private IEnumerator ShowSlowly(bool show) {
		var time = ShowDelay;

		while (time > 0f && this != null && show == showed) {
			time -= Time.deltaTime;
			var color = material.color;
			color.a = show ? 1 - time / ShowDelay : time / ShowDelay;
			material.color = color;
			yield return null;
		}
	}

}
