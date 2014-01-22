using UnityEngine;
using System.Collections;

public class PowerUpEffect : MonoBehaviour {
	
	private int _count = 1;

	void Start () {
		if (GetComponents<PowerUpEffect>().Length > 1) {
			SendMessage("IncreaseCount", _count);
			
			Destroy(this);
		}
	}
	
	void Update () {
		if (Input.GetKeyUp(KeyCode.Mouse1)) {
			rigidbody.velocity = Vector3.zero;
			rigidbody.angularVelocity = Vector3.zero;
			
			// Remove 1 of the particles attached
			foreach (ParticleSystem ps in transform.GetComponentsInChildren<ParticleSystem>() as ParticleSystem []) {
				if (ps.loop) {
					ps.loop = false;
					break;
				}
			}
			
			_count--;
			if (_count < 1)
				Destroy(this);
		}
	}
	
	void IncreaseCount (int count) {
		_count += count;
	}
}
