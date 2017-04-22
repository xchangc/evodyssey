using UnityEngine;
using System.Collections;

public class AttackArea : MonoBehaviour {

	public ParticleSystem attackParticle;
	public LivingPlayer player;
	public Enemy enemy;
	private float attackRate;
	private float maxAttackRate;
	private float minAttackRate;

	private float damage;

	// Use this for initialization
	void Start () {
		damage = player.mAttack;
		maxAttackRate = 60.0f;
		attackRate = maxAttackRate;
		player = player.GetComponent<LivingPlayer> ();
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
		if (other.tag == "Entity") {
			if (player.IsAttacking()) {
				if (attackRate >= maxAttackRate)
				{
					Instantiate (attackParticle, transform.position, attackParticle.transform.rotation);
                    LivingEnemy livEnemy = other.GetComponent<LivingEnemy>();
                    livEnemy.Damage(damage);
					attackRate = 0.0f;
				}
			}
		}
	}

	void OnTriggerStay(Collider other) {
		if (other.tag == "Entity") {
			if (player.IsAttacking()) {
				if (attackRate >= maxAttackRate)
				{
					Instantiate (attackParticle, transform.position, attackParticle.transform.rotation);
                    LivingEnemy livEnemy = other.GetComponent<LivingEnemy>();
                    livEnemy.Damage(damage);
                    attackRate = 0.0f;
				}
			}
		}
	}

	void SetDamage(int dmg) {
		damage += dmg;
	}
}	
