using UnityEngine;
using System.Collections;

public class RotateAround : MonoBehaviour {

	public float speed = 180;

	void Update () {
		transform.Rotate(Vector3.up, Time.deltaTime * speed, Space.Self);
	}
}
