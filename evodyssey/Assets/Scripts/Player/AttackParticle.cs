using UnityEngine;
using System.Collections;

public class AttackParticle : MonoBehaviour {

	public float lifeSpan = 0.6f;

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, lifeSpan);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
