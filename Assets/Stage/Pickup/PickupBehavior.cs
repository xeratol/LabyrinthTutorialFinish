using UnityEngine;
using System.Collections;

public class PickupBehavior : MonoBehaviour {
	
	public AudioClip sound;
	public int score = 100;
	
	void Start () {
		collider.isTrigger = true;
	}
	
	void OnTriggerEnter (Collider other) {
		if (other.GetComponent<BallBehavior>()) {
			// Play Sound
			if (sound) {
				AudioSource.PlayClipAtPoint(sound, transform.position);
			}
			
			// Increase Score
			StageBehavior.instance.AddScore(score);
			
			// Destroy pickup
			Destroy(gameObject);
		}
	}
	
	void HasLost () {
		collider.enabled = false;
	}
}
