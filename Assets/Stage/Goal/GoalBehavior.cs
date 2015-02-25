using UnityEngine;
using System.Collections;

public class GoalBehavior : MonoBehaviour {

	void Start () {
		collider.isTrigger = true;
	}
	
	void OnTriggerEnter (Collider other) {
		if (other.GetComponent<BallBehavior>()) {
			// ball has reached the goal
			//StageBehavior.instance.HasWon();
			foreach (MonoBehaviour script in GameObject.FindObjectsOfType(typeof(MonoBehaviour)))
				script.SendMessage("HasWon", SendMessageOptions.DontRequireReceiver);
				
			StageBehavior.instance.AddScore(500);
		}
	}
}
