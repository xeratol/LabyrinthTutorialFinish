using UnityEngine;
using System.Collections;

public class TitleBehavior : MonoBehaviour {
	
	public Texture2D logo;
	private enum MenuState {
		Main = 0,
		Play,
		Credits,
	}
	private MenuState menu = MenuState.Main;
	private string [] levels = new string [] {"01", "02", "03"};
	private int selLevel = -1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (selLevel > -1) {
			Application.LoadLevel(1 + selLevel);
		}
	}
	
	void OnGUI () {
		GUI.Label(new Rect(Screen.width * 0.5f - 200, Screen.height * 0.5f - 200, 400, 100), logo);
		
		switch (menu) {
		case MenuState.Main:
			DisplayMainMenu();			
			break;
		case MenuState.Play:
			DisplayPlayMenu();
			break;
		case MenuState.Credits:
			DisplayCredits();
			break;
		}
	}
	
	void DisplayMainMenu () {
		if (GUI.Button(
			new Rect(Screen.width * 0.5f - 150, Screen.height * 0.5f, 300, 75),
			"Play")) {
			menu = MenuState.Play;
		}
		
		if (GUI.Button(
			new Rect(Screen.width * 0.5f - 150, Screen.height * 0.5f + 80, 300, 75),
			"Credits")) {
			menu = MenuState.Credits;
		}
	}
	
	void DisplayPlayMenu () {
		selLevel = GUI.Toolbar(new Rect(Screen.width * 0.5f - 200, Screen.height * 0.5f, 400, 100),
			selLevel, levels);
		if (GUI.Button(
			new Rect(Screen.width * 0.5f - 50, Screen.height * 0.5f + 120, 100, 50),
			"Back")) {
			menu = MenuState.Main;
		}
	}
	
	void DisplayCredits () {
		GUI.Box(
			new Rect(Screen.width * 0.5f - 150, Screen.height * 0.5f, 300, 100),
			"Francis Serina");
		if (GUI.Button(
			new Rect(Screen.width * 0.5f - 50, Screen.height * 0.5f + 120, 100, 50),
			"Back")) {
			menu = MenuState.Main;
		}
	}
}
