using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hud : MonoBehaviour {

	public Text text;
	public Player player;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		text.text = player.getPlayerHealth().ToString();

	}
	
	// Update is called once per frame
	void Update () {
		text.text = player.getPlayerHealth().ToString();
	}
}
