using UnityEngine;
using System.Collections;

public class BallShadowBehavior : MonoBehaviour {
	
	private Transform _ball;
	
	void Start () {
		_ball = transform.parent;
		transform.parent = _ball.parent;
	}
	
	void Update () {
		// copy only the x and z position of the ball
		Vector3 newPos = transform.localPosition;
		newPos.x = _ball.localPosition.x;
		newPos.z = _ball.localPosition.z;
		transform.localPosition = newPos;
	}
	
	void HasLost () {
		gameObject.SetActive(false);
	}
}
