using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPlayer : MonoBehaviour, IGvrGazeResponder {
	void IGvrGazeResponder.OnGazeEnter() {
		print("Enter");
	}

	void IGvrGazeResponder.OnGazeExit() {
		print("Exit");
	}

	void IGvrGazeResponder.OnGazeTrigger() {
		print("Trigger");
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
