using UnityEngine;
using System.Collections;

public class AttackArea : MonoBehaviour {

	public PlayerController controller;
	public ParticleSystem attackParticle;
	public Player player;
	public Enemy enemy;
	private float attackRate;
	private float maxAttackRate;
	private float minAttackRate;

	private float damage;

	// Use this for initialization
	void Start () {
		damage = 3.0f;
		maxAttackRate = 60.0f;
		attackRate = maxAttackRate;
		player = player.GetComponent<Player> ();
	}

	// Update is called once per frame
	void Update () {
		if (attackRate < maxAttackRate)
		{
			attackRate += 1.0f;
		}
		else if (attackRate >= maxAttackRate)
		{
			attackRate = maxAttackRate;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Enemy") {
			if (controller.GetIsAttacking ()) {
				if (attackRate >= maxAttackRate)
				{
					Instantiate (attackParticle, transform.position, attackParticle.transform.rotation);
					other.SendMessage ("takeDamage", damage);
					attackRate = 0.0f;
				}
			}
		}
	}

	void OnTriggerStay(Collider other) {
		if (other.tag == "Enemy") {
			if (controller.GetIsAttacking ()) {
				if (attackRate >= maxAttackRate)
				{
					Instantiate (attackParticle, transform.position, attackParticle.transform.rotation);
					other.SendMessage ("takeDamage", damage);
					attackRate = 0.0f;
				}
			}
		}
	}

	void SetDamage(float dmg) {
		damage += dmg;
	}
}	
