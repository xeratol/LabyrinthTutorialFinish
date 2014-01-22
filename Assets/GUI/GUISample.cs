using UnityEngine;
using System.Collections;

public class GUISample : MonoBehaviour {
	
	public GUIStyle style;
	public GUISkin skin;
	
	void Start () {
	
	}
	
	void Update () {
	
	}
	
	void OnGUI () {
		GUI.skin = skin;
		
		GUI.Label(new Rect(10, 10, 200, 40), "Label", style);
		GUI.Box(new Rect(10, 60, 200, 40), "Box", style);
		GUI.Button(new Rect(10, 110, 200, 40), "Button", style);
		
		GUI.Label(new Rect(220, 10, 200, 40), "Label");
		GUI.Box(new Rect(220, 60, 200, 40), "Box");
		GUI.Button(new Rect(220, 110, 200, 40), "Button");
		
	}
}
