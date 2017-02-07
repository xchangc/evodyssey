using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {

	public Player player;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			player.increaseSizeAttribute (1.0f);
			player.increaseHealth (0.5f);
			Destroy (this.gameObject);
		}
	}
}
