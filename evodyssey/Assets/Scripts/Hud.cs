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
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "Health: " + player.getPlayerHealth().ToString() + "\n" + "\n" +
                    "Attack Level: " + player.getPlayerAttackLevel().ToString() + "\n" +
                    "Defense Level: " + player.getPlayerDefenseLevel().ToString() + "\n" +
                    "Size Level: " + player.getPlayerSizeLevel().ToString() + "\n" + 
                    "Speed Level: " + player.getPlayerSpeedLevel().ToString() + "\n" + "\n" +
                    "Attack Stats: " + player.getPlayerAttackStats().ToString() + "\n" +
                    "Defense Stats: " + player.getPlayerDefenseStats().ToString() + "\n" +
                    "Size Stats: " + player.getPlayerSizeStats().ToString() + "\n" +
                    "Speed Stats: " + player.getPlayerSpeedStats().ToString() + "\n";
	}
}
