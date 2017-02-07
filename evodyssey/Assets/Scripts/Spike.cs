using UnityEngine;
using System.Collections;

public class Spike : MonoBehaviour {

	Player player;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.collider.tag == "Player" || other.collider.tag == "Player Body") {
			player.increaseDefenseAttribute (1.0f);
			player.decreaseHealth (1.0f);
		}
	}
}
