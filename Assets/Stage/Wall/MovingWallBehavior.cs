using UnityEngine;
using System.Collections;

public class MovingWallBehavior : MonoBehaviour {
	
	public bool isOscillating = true;
	
	private Vector3 startPosition;
	public Vector3 relativePosition;
	
	private bool isMoving = false;
	private float duration = 0;
	private float currTime = 0;
	
	public void Start () {
		startPosition = transform.localPosition;
	}
	
	public void Update () {
		if (!isMoving) return;
		
		currTime += Time.deltaTime;
		
		// interpolate for the actual increment to be added to startPosition
		Vector3 actualRelPos = relativePosition * currTime / duration;
		transform.localPosition = startPosition + actualRelPos;
		
		if (currTime >= duration) {
			// recompute the new start position (current position)
			startPosition += relativePosition;
			// clean up any possible discrepancy
			transform.localPosition = startPosition;
			
			if (isOscillating) {
				// reverse the relative position (oscillating animation)
				relativePosition = -relativePosition;
			}
			
			isMoving = false;
		}
	}
	
	public void Move (float newDuration) {
		if (isMoving) return;
		
		isMoving = true;
		duration = newDuration;
		currTime = 0;
	}
}
