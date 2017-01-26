using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float startingHealth;
	public float startingStamina;
	protected float health;
	protected float stamina;

	// Use this for initialization
	void Start () {
		health = startingHealth;
		stamina = startingStamina;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (1)) {
			
		}
	}
}
