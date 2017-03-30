using UnityEngine;
using System.Collections;

public class DetectRadius : MonoBehaviour {

    public PlayerController controller;
    public Player player;
    private bool chasing;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        chasing = false;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (chasing == false)
            {
                if (controller.GetIsDashing())
                {
                    player.increaseSpeedAttribute(1.0f);
                    chasing = true;
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (chasing == true)
            {
                chasing = false;
            }
        }
    }
}
