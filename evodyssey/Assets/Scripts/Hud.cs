using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hud : MonoBehaviour {

	public Text text;
	public LivingPlayer player;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<LivingPlayer>();
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "Health: " + player.GetHealth().ToString() + "\n" +
					"Stamina: " + player.GetStamina().ToString() + "\n" +
                    "Attack Level: " + player.GetAttackLevel().ToString() + "\n" +
                    "Defense Level: " + player.GetDefenseLevel().ToString() + "\n" +
                    "Size Level: " + player.GetSizeLevel().ToString() + "\n" + 
                    "Speed Level: " + player.GetSpeedLevel().ToString() + "\n" + "\n" +
                    "Attack Stats: " + player.GetAttackAttribute().ToString() + "\n" +
                    "Defense Stats: " + player.GetDefenseAttribute().ToString() + "\n" +
                    "Size Stats: " + player.GetSizeAttribute().ToString() + "\n" +
                    "Speed Stats: " + player.GetSpeedAttribute().ToString() + "\n";
        //test test test
        //int lol = 1;
	}
}
