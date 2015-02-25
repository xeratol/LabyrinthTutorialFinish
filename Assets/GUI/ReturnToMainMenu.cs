using UnityEngine;
using System.Collections;

public class ReturnToMainMenu : MonoBehaviour {

	public void OnClick () {
		Application.LoadLevel(0);
	}
}
