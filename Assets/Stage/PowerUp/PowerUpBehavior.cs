using UnityEngine;
using System.Collections;

[RequireComponent(typeof(RotateAround))]

public class PowerUpBehavior : MonoBehaviour {
	
	public AudioClip sound;

	void Start () {
		collider.isTrigger = true;
	}
	
	void OnTriggerEnter (Collider other) {
		if (other.GetComponent<BallBehavior>()) {
			other.gameObject.AddComponent<PowerUpEffect>(); // unfortunately, type of power up is hardcoded
			
			if (sound) {
				AudioSource.PlayClipAtPoint(sound, Vector3.zero);
			}
			
			// Transfer particles to ball
			Transform particles = transform.GetComponentInChildren<ParticleSystem>().transform;
			particles.parent = other.transform;
			particles.localScale = new Vector3(1, 0.05f, 1); // FIXME: I don't know why?!
			particles.localPosition = Vector3.zero;
			particles.localRotation = Quaternion.Euler(Vector3.zero);
			
			Destroy(gameObject);
		}
	}
	
	void HasLost () {
		collider.enabled = false;
	}
}
