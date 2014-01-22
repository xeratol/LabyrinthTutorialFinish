using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour {
	
	public float duration = 1;

	void Start () {
		Destroy(gameObject, duration);
	}
}
