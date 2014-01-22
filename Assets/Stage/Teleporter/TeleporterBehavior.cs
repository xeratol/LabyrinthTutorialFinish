using UnityEngine;
using System.Collections;

public class TeleporterBehavior : MonoBehaviour {
	
	public TeleporterBehavior target;
	public Transform ballGhost;
	public Transform reconstructParticles;
	public float reconstructDuration = 0.3f;
	public AudioClip reconstructSound;
	
	private bool _on;

	void Start () {
		Activate();
		
		collider.isTrigger = true;
	}
	
	IEnumerator OnTriggerEnter (Collider other) {
		if (other.GetComponent<BallBehavior>() == null || !_on) yield break;
		
		target.Deactivate();
		
		// Get relative position of ball to this teleporter
		Vector3 relPos = transform.InverseTransformPoint(other.transform.position);
		// Get the world position of the ball using the relative position on the other teleporter
		Vector3 newPos = target.transform.TransformPoint(relPos);
		
		// Get velocity of ball relative to this teleporter
		Vector3 relVel = transform.InverseTransformDirection(other.rigidbody.velocity);
		// Convert that relative velocity to world velocity relative to the targetTeleporter
		Vector3 newVel = target.transform.TransformDirection(relVel);
		
		if (ballGhost) {
			// copy other ball and create a ghost
			Transform b = Instantiate(ballGhost, other.transform.position, other.transform.rotation) as Transform;
			b.rigidbody.velocity = other.rigidbody.velocity;
			b.rigidbody.angularVelocity = other.rigidbody.angularVelocity;
		}
		
		if (reconstructSound) {
			AudioSource.PlayClipAtPoint(reconstructSound, newPos);
		}
		
		if (reconstructParticles) {
			Instantiate(reconstructParticles, newPos, other.transform.rotation);
		}
		
		// teleport the ball
		other.transform.position = newPos;

		// keep it hidden first while it's "reconstructing"
		Color c = other.renderer.material.color;
		c.a = 0;
		other.renderer.material.color = c;
	
		// freeze the ball
		other.rigidbody.isKinematic = true;
		
		// minor delay when "reconstructing"
		yield return new WaitForSeconds(reconstructDuration);
		
		// show the ball
		c.a = 1;
		other.renderer.material.color = c;
		
		// unfreeze the ball
		other.rigidbody.isKinematic = false;
		other.rigidbody.velocity = newVel;
		
		// Angular velocity has been ignored since it will never be noticed :)
	}
	
	void OnTriggerExit (Collider other) {
		if (other.GetComponent<BallBehavior>())
			Activate();
	}
	
	public void Activate () {
		if (target)
			_on = true;
		else 
			_on = false;
	}
	
	public void Deactivate () {
		_on = false;
	}
}
