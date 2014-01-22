using UnityEngine;
using System.Collections;

public class MovingWallColliderTrigger : MonoBehaviour {
	
	public MovingWallBehavior target;
	public float duration;
	
	void Start () {
		collider.isTrigger = true;
	}
	
	public void OnTriggerEnter (Collider other) {
		if (target) {
			target.Move(duration);
		}
	}
}
