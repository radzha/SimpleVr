using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Переключает стерео/моно режимы.
/// </summary>
public class ToggleStereoMode : MonoBehaviour, IGvrGazeResponder {
	private GvrViewer viewer;

	private void Awake() {
		viewer = FindObjectOfType<GvrViewer>();
	}

	void IGvrGazeResponder.OnGazeEnter() {
		ToggleMode();
	}

	void IGvrGazeResponder.OnGazeExit() {
	}

	void IGvrGazeResponder.OnGazeTrigger() {
	}

	private void ToggleMode() {
		viewer.VRModeEnabled = !viewer.VRModeEnabled;
	}

}
