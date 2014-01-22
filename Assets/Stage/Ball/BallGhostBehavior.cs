using UnityEngine;
using System.Collections;

public class BallGhostBehavior : MonoBehaviour {
	
	public float duration = 5;
	private float _decrement;
	private float _timeStart;
	private Color _color;

	void Start () {
		_timeStart = Time.time;
		_color = renderer.material.color;
		_decrement = 1/duration;
	}
	
	void Update () {
		if (_timeStart + duration > Time.time) {
			// fade out
			_color.a = Mathf.Lerp(1, 0, (Time.time - _timeStart) * _decrement);
			renderer.material.color = _color;
		} else {
			Destroy(gameObject);
		}
	}
}
