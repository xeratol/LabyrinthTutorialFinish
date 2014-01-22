using UnityEngine;
using System.Collections;

public class InGameMenu : MonoBehaviour {
	
	private bool isPaused = false;
	private StageBehavior stage;
	
	void Start () {
		stage = GameObject.FindObjectOfType(typeof(StageBehavior)) as StageBehavior;
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (isPaused) {
				Resume();
			} else {
				Pause();
			}
		}
	}

	void OnGUI () {
		if (isPaused) {
			GUI.Box(new Rect(Screen.width * 0.5f - 100, Screen.height * 0.5f - 50, 200, 100),
				"PAUSED");
			if (GUI.Button(new Rect(Screen.width * 0.5f - 80, Screen.height * 0.5f - 20, 160, 30),
				"RESUME")) {
				Resume();
			}
			if (GUI.Button(new Rect(Screen.width * 0.5f - 80, Screen.height * 0.5f + 10, 160, 30),
				"QUIT")) {
				Time.timeScale = 1;
				Application.LoadLevel(0);
			}
		}
	}
	
	void Pause () {
		isPaused = true;
		Time.timeScale = 0;
		stage.enabled = false;
		foreach (MonoBehaviour script in GameObject.FindObjectsOfType(typeof(MonoBehaviour)))
			script.SendMessage("OnPause", SendMessageOptions.DontRequireReceiver);
	}
	
	void Resume () {
		isPaused = false;
		Time.timeScale = 1;
		stage.enabled = true;
		foreach (MonoBehaviour script in GameObject.FindObjectsOfType(typeof(MonoBehaviour)))
			script.SendMessage("OnResume", SendMessageOptions.DontRequireReceiver);
	}
}
