using UnityEngine;
using System.Collections;

public class BGMBehavior : MonoBehaviour {

	void Start () {
		if (GameObject.FindObjectsOfType(typeof(BGMBehavior)).Length > 1) {
			Destroy(gameObject);
		}
		
		DontDestroyOnLoad(gameObject);
	}
}
