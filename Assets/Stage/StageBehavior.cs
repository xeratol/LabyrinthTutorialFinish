using UnityEngine;
using System.Collections;

public class StageBehavior : MonoBehaviour {
	
	public float maxAngle = 20;
	
	private bool _isGameOver = false;
	private int _score = 0;
	
	private static StageBehavior _instance = null;
	public static StageBehavior instance {
		get { return _instance; }
	}
	
	void Start () {
		_instance = this;
	}
	
	public void Update () {
		if (_isGameOver) return;
		
		float zAngle = maxAngle * (Screen.width * 0.5f - Input.mousePosition.x) / (Screen.width * 0.5f);
		float xAngle = maxAngle * (Input.mousePosition.y - Screen.height * 0.5f) / (Screen.height * 0.5f);
		zAngle = Mathf.Clamp(zAngle, -maxAngle, maxAngle);
		xAngle = Mathf.Clamp(xAngle, -maxAngle, maxAngle);
		
		Vector3 newEulerAngles = new Vector3(xAngle, 0, zAngle);
		transform.eulerAngles = newEulerAngles;
		//rigidbody.MoveRotation(Quaternion.Euler(newEulerAngles));
	}
	
	void OnGUI () {
		GUI.Box(new Rect(Screen.width - 200, 0, 200, 40), "Score: " + _score);
	}
	
	public void HasWon () {
		_isGameOver = true;
		
		Debug.Log("The player has won!");
		
		// do something spectacular
		// Cause all barrels to explode

		StartCoroutine(ChangeLevel());
	}
	
	public void HasLost () {
		_isGameOver = true;
		
		Debug.Log("The player has lost!");
		
		// do something sad
		
		StartCoroutine(RestartLevel());
	}
	
	IEnumerator ChangeLevel () {
		yield return new WaitForSeconds(3);
		
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	IEnumerator RestartLevel () {
		yield return new WaitForSeconds(3);
		
		Application.LoadLevel(Application.loadedLevel);
	}
	
	public int AddScore (int amount) {
		_score += amount;
		return _score;
	}
}
