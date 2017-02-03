using UnityEngine;
using System.Collections;

public class AttackArea : MonoBehaviour {

	public PlayerController controller;
	public ParticleSystem attackParticle;
	public Player player;
	public Enemy enemy;

	private float damage;

	// Use this for initialization
	void Start () {
		damage = 3.0f;
		player = player.GetComponent<Player> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Food") {
			Destroy (other.gameObject);
			player.increaseDefenseAttribute (1.0f);
		} else if (other.tag == "Power") {
			SetDamage (3.0f);
			Destroy (other.gameObject);
		}
	}

	void OnTriggerStay(Collider other) {
		if (other.tag == "Enemy") {
			if (controller.GetIsAttacking ()) {
				Instantiate (attackParticle, transform.position, attackParticle.transform.rotation);
				other.SendMessage ("takeDamage", damage);
			}
		}
	}

	void SetDamage(float dmg) {
		damage += dmg;
	}
}	
