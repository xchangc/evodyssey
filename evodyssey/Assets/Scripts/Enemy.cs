using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float enemyHealth;

	// Use this for initialization
	void Start () {
		enemyHealth = 6;
	}
	
	// Update is called once per frame
	void Update () {
		if (enemyHealth <= 0) {
			Destroy (this.gameObject);
		}
	}

	void takeDamage(float dmg) {
		enemyHealth -= dmg;
	}
}
