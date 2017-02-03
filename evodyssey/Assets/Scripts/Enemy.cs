using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float enemyHealth;
	public GameObject player;


	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	// Use this for initialization
	void Start () {
		enemyHealth = 6;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void takeDamage(float dmg) {

		enemyHealth -= dmg;

		if (enemyHealth <= 0) {
			Destroy (this.gameObject);
			player.GetComponent<Player> ().increaseAttackAttribute (1.0f);
		}
	}
}
