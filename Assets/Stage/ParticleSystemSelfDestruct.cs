using UnityEngine;
using System.Collections;

public class ParticleSystemSelfDestruct : MonoBehaviour {

	void Start () {
		if (!particleSystem) Destroy(this);
	}
	
	void Update () {
		if (!particleSystem.isPlaying)
			Destroy(gameObject);
	}
}
