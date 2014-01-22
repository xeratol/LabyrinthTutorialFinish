using UnityEngine;
using System.Collections;

public class BarrelBehavior : MonoBehaviour {
	
	public float explosionMagnitude = 2000;
	public Transform explosion;
	public AudioClip explosionSound;
	
	void OnCollisionEnter (Collision info) {
		if (info.gameObject.GetComponent<BallBehavior>()) {
			// Ball receives explosion force
			
			info.transform.parent = null; // detach ball from stage
			info.transform.localScale = Vector3.one; // reset scale
			
			Rigidbody ball = info.rigidbody;
			ball.AddForce(Vector3.up * explosionMagnitude); // throw ball upwards
			
			// Game Over (stage)
			//(GameObject.FindObjectOfType(typeof(StageBehavior)) as StageBehavior).HasLost();
			foreach (MonoBehaviour script in GameObject.FindObjectsOfType(typeof(MonoBehaviour)))
				script.SendMessage("HasLost", SendMessageOptions.DontRequireReceiver);
			
			Explode();
		}
	}
	
	void HasWon () {
		Explode();
	}
	
	public void Explode () {
		// Barrel receives explosion force
		
		// Show explosion
		if (explosion) {
			Instantiate(explosion, transform.position, transform.parent.rotation);
		}
		
		transform.parent = null; // detach barrel from stage
		//transform.localScale = Vector3.one; // reset scale
		
		// Play explosion sound
		if (explosionSound) {
			gameObject.AddComponent<AudioSource>().PlayOneShot(explosionSound);
		}
		
		gameObject.AddComponent<Rigidbody>();
		rigidbody.AddForce(Vector3.up * explosionMagnitude); // throw barrel upwards
		rigidbody.AddTorque(Random.onUnitSphere * explosionMagnitude); // add a bit of rotation
		
		// Detach this script to prevent multiple explosions in midair
		Destroy(this);
	}
}
