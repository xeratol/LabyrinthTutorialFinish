using UnityEngine;
using System.Collections;

[RequireComponent (typeof(MovingWallBehavior)) ]

public class MovingWallTimeTrigger : MonoBehaviour {

	public float timeStationary = 2;
	public float timeMove = 0.5f;
	private float currTime = 0;

	private enum WallState {
		STATIONARY,
		MOVING,
	};
	private WallState _state = WallState.STATIONARY;
	
	void Update () {
		currTime += Time.deltaTime;
		
		switch (_state) {
		case WallState.STATIONARY:
			// simply wait until it's time to move
			if (currTime >= timeStationary) {
				_state = WallState.MOVING;
				currTime = 0;
				
				// Call Move() of MoveWallBehavior
				gameObject.GetComponent<MovingWallBehavior>().Move(timeMove);
				//gameObject.SendMessage("Move", timeMove);
			}
			break;
		case WallState.MOVING:
			// simply wait until it's time to stop
			if (currTime >= timeMove) {
				_state = WallState.STATIONARY;
				currTime = 0;
			}
			break;
		}
	}
}
