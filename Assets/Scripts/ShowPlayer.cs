using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Показывает/скрывает плеер.
/// </summary>
public class ShowPlayer : MonoBehaviour, IGvrGazeResponder {
	public float ShowDelay = 1f;

	private bool showed;
	private Material material;

	private void Awake() {
		material = GetComponent<MeshRenderer>().material;
	}

	void IGvrGazeResponder.OnGazeEnter() {
		Show(true);
	}

	void IGvrGazeResponder.OnGazeExit() {
		Show(false);
	}

	void IGvrGazeResponder.OnGazeTrigger() {
	}

	private void Show(bool show) {
		showed = show;
		if (this != null) {
			StartCoroutine(ShowSlowly(show));
		}
	}

	/// <summary>
	/// Корутина, плавно показывающая/скрывающая изображение.
	/// </summary>
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
