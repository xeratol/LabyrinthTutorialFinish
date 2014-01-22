using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	public float zoomDistance = 10;
	public float transitionSpeed = 0.5f;
	
	[SerializeField]
	private bool _isFollowing = false;
	private bool _isGameOver = false;
	private BallBehavior [] _balls;
	private Vector3 _startPos;

	// Use this for initialization
	void Start () {
		_balls = GameObject.FindObjectsOfType(typeof(BallBehavior)) as BallBehavior [];
		_startPos = transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (Input.GetKeyDown(KeyCode.Tab) && !_isGameOver) {
			StartStopFollow();
		}
		
		if (_isFollowing) {
			Vector3 targetPos = Vector3.zero;
			for (int i = 0; i < _balls.Length; i++)
				targetPos += _balls[i].transform.position;
			targetPos /= _balls.Length;
			targetPos += (Vector3.up * zoomDistance) * _balls.Length;
			transform.position = Vector3.MoveTowards(transform.position, targetPos, transitionSpeed);
		} else {
			transform.position = Vector3.MoveTowards(transform.position, _startPos, transitionSpeed);
		}
	}
	
	private void StartStopFollow () {
		if (_balls.Length > 0)
			_isFollowing = !_isFollowing;
	}
	
	void HasLost () {
		_isFollowing = false;
		_isGameOver = true;
	}
	
	void HasWon () {
		_isFollowing = false;
		_isGameOver = true;
	}
	
	void OnPause () {
		enabled = false;
	}
	
	void OnResume () {
		enabled = true;
	}
}
