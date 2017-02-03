using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float startingHealth = 10;
	public float startingStamina = 10;
	protected float health;
	protected float stamina;
	private float attackAttribute;
	private float defenseAttribute;
	private float sizeAttribute;
	private float speedAttribute;
	private int attackLevel;
	private int defenseLevel;
	private int sizeLevel;
	private int speedLevel;

	void Start () {
		health = startingHealth;
		stamina = startingStamina;
		attackAttribute = 0.0f;
		defenseAttribute = 0.0f;
		sizeAttribute = 0.0f;
		speedAttribute = 0.0f;
		attackLevel = 0;
		defenseLevel = 0;
		sizeLevel = 0;
		speedLevel = 0;
	}

	void Update () {
	}

	// Increase Attack Attribute
	public void increaseAttackAttribute (float f)
	{
		if (attackLevel == 0 && defenseLevel == 0) {
			attackAttribute += f;
			defenseAttribute -= f / 2.0f;
		} else if (attackLevel == 0 && defenseLevel > 0) {
			attackAttribute += f;
		} else if (attackLevel == 1 && defenseLevel < 1) {
			attackAttribute += f;
		} else if (attackLevel == 1 && defenseLevel == 1) {
			attackAttribute += f;
			defenseAttribute -= f / 2.0f;
		} else if (attackLevel == 1 && defenseLevel > 1) {
			attackAttribute += f;
		} else if (attackLevel == 2 && defenseLevel < 2) {
			attackAttribute += f;
		} else if (attackLevel == 2 && defenseLevel == 2) {
			attackAttribute += f;
			defenseAttribute -= f / 2.0f;
		} else if (attackLevel == 2 && defenseLevel > 2) {
			attackAttribute += f;
		} else if (attackLevel == 3 && defenseLevel < 2) {
			attackAttribute += f;
		} else if (attackLevel == 3 && defenseLevel >= 2 && defenseLevel <= 3) {
			attackAttribute += f;
			defenseAttribute -= f / 2.0f;
		} else if (attackLevel == 3 && defenseLevel > 3) {
			attackAttribute += f;
			defenseAttribute -= f / 2.0f;
		} else if (attackLevel == 4 && defenseLevel >= 3 && defenseLevel <= 4) {
			attackAttribute += f;
			defenseAttribute -= f / 2.0f;
		} else if (attackLevel == 4 && defenseLevel > 4) {
			attackAttribute += f;
			defenseAttribute -= f / 2.0f;
		} else if (attackLevel == 5 && defenseLevel >= 3 && defenseLevel <= 5) {
			attackAttribute += f;
			defenseAttribute -= f / 2.0f;
		}
			
		checkAttributes();
	}

	// Increase Defense Attribute
	public void increaseDefenseAttribute (float f)
	{
		if (defenseLevel == 0 &&  attackLevel == 0) {
			defenseAttribute += f;
			attackAttribute -= f / 2.0f;
		} else if (defenseLevel == 0 && attackLevel > 0) {
			defenseAttribute += f;
		} else if (defenseLevel == 1 && attackLevel < 1) {
			defenseAttribute += f;
		} else if (defenseLevel == 1 && attackLevel == 1) {
			defenseAttribute += f;
			attackAttribute -= f / 2.0f;
		} else if (defenseLevel == 1 && attackLevel > 1) {
			defenseAttribute += f;
		} else if (defenseLevel == 2 && attackLevel < 2) {
			defenseAttribute += f;
		} else if (defenseLevel == 2 && attackLevel == 2) {
			defenseAttribute += f;
			attackAttribute -= f / 2.0f;
		} else if (defenseLevel == 2 && attackLevel > 2) {
			defenseAttribute += f;
		} else if (defenseLevel == 3 && attackLevel < 2) {
			defenseAttribute += f;
		} else if (defenseLevel == 3 && attackLevel >= 2 && attackLevel <= 3) {
			defenseAttribute += f;
			attackAttribute -= f / 2.0f;
		} else if (defenseLevel == 3 && attackLevel > 3) {
			defenseAttribute += f;
			attackAttribute -= f / 2.0f;
		} else if (defenseLevel == 4 && attackLevel >= 3 && attackLevel <= 4) {
			defenseAttribute += f;
			attackAttribute -= f / 2.0f;
		} else if (defenseLevel == 4 && attackLevel > 4) {
			defenseAttribute += f;
			attackAttribute -= f / 2.0f;
		} else if (defenseLevel == 5 && attackLevel >= 3 && attackLevel <= 5) {
			defenseAttribute += f;
			attackAttribute -= f / 2.0f;
		}

		checkAttributes();
	}

	// Increase Size Attribute
	public void increaseSizeAttribute (float f)
	{
		if (sizeLevel == 0 &&  speedLevel == 0) {
			sizeAttribute += f;
			speedAttribute -= f / 2.0f;
		} else if (sizeLevel == 0 && speedLevel > 0) {
			sizeAttribute += f;
		} else if (sizeLevel == 1 && speedLevel < 1) {
			sizeAttribute += f;
		} else if (sizeLevel == 1 && speedLevel == 1) {
			sizeAttribute += f;
			speedAttribute -= f / 2.0f;
		} else if (sizeLevel == 1 && speedLevel > 1) {
			sizeAttribute += f;
		} else if (sizeLevel == 2 && speedLevel < 2) {
			sizeAttribute += f;
		} else if (sizeLevel == 2 && speedLevel == 2) {
			sizeAttribute += f;
			speedAttribute -= f / 2.0f;
		} else if (sizeLevel == 2 && speedLevel > 2) {
			sizeAttribute += f;
		} else if (sizeLevel == 3 && speedLevel < 2) {
			sizeAttribute += f;
		} else if (sizeLevel == 3 && speedLevel >= 2 && speedLevel <= 3) {
			sizeAttribute += f;
			speedAttribute -= f / 2.0f;
		} else if (sizeLevel == 3 && speedLevel > 3) {
			sizeAttribute += f;
			speedAttribute -= f / 2.0f;
		} else if (sizeLevel == 4 && speedLevel >= 3 && speedLevel <= 4) {
			sizeAttribute += f;
			speedAttribute -= f / 2.0f;
		} else if (sizeLevel == 4 && speedLevel > 4) {
			sizeAttribute += f;
			speedAttribute -= f / 2.0f;
		} else if (sizeLevel == 5 && speedLevel >= 3 && speedLevel <= 5) {
			sizeAttribute += f;
			speedAttribute -= f / 2.0f;
		}

		checkAttributes();
	}

	// Increase Speed Attribute
	public void increaseSpeedAttribute (float f)
	{
		if (speedLevel == 0 &&  sizeLevel == 0) {
			speedAttribute += f;
			sizeAttribute -= f / 2.0f;
		} else if (speedLevel == 0 && sizeLevel > 0) {
			speedAttribute += f;
		} else if (speedLevel == 1 && sizeLevel < 1) {
			speedAttribute += f;
		} else if (speedLevel == 1 && sizeLevel == 1) {
			speedAttribute += f;
			sizeAttribute -= f / 2.0f;
		} else if (speedLevel == 1 && sizeLevel > 1) {
			speedAttribute += f;
		} else if (speedLevel == 2 && sizeLevel < 2) {
			speedAttribute += f;
		} else if (speedLevel == 2 && sizeLevel == 2) {
			speedAttribute += f;
			sizeAttribute -= f / 2.0f;
		} else if (speedLevel == 2 && sizeLevel > 2) {
			speedAttribute += f;
		} else if (speedLevel == 3 && sizeLevel < 2) {
			speedAttribute += f;
		} else if (speedLevel == 3 && sizeLevel >= 2 && sizeLevel <= 3) {
			speedAttribute += f;
			sizeAttribute -= f / 2.0f;
		} else if (speedLevel == 3 && sizeLevel > 3) {
			speedAttribute += f;
			sizeAttribute -= f / 2.0f;
		} else if (speedLevel == 4 && sizeLevel >= 3 && sizeLevel <= 4) {
			speedAttribute += f;
			sizeAttribute -= f / 2.0f;
		} else if (speedLevel == 4 && sizeLevel > 4) {
			speedAttribute += f;
			sizeAttribute -= f / 2.0f;
		} else if (speedLevel == 5 && sizeLevel >= 3 && sizeLevel <= 5) {
			speedAttribute += f;
			sizeAttribute -= f / 2.0f;
		}

		checkAttributes();
	}

	// Check The Attributes
	public void checkAttributes()
	{
		if (attackAttribute < 5.0f) {
			attackLevel = 0;
		} else if (attackAttribute >= 5.0f && attackAttribute < 10.0f) {
			attackLevel = 1;
		} else if (attackAttribute >= 10.0f && attackAttribute < 20.0f) {
			attackLevel = 2;
		} else if (attackAttribute >= 20.0f && attackAttribute < 40.0f) {
			attackLevel = 3;
		} else if (attackAttribute >= 40.0f && attackAttribute < 80.0f) {
			attackLevel = 4;
		} else if (attackAttribute >= 80.0f) {
			attackLevel = 5;	
		}

		if (defenseAttribute < 5.0f) {
			defenseLevel = 0;
		} else if (defenseAttribute >= 5.0f && defenseAttribute < 10.0f) {
			defenseLevel = 1;
		} else if (defenseAttribute >= 10.0f && defenseAttribute < 20.0f) {
			defenseLevel = 2;
		} else if (defenseAttribute >= 20.0f && defenseAttribute < 40.0f) {
			defenseLevel = 3;
		} else if (defenseAttribute >= 40.0f && defenseAttribute < 80.0f) {
			defenseLevel = 4;
		} else if (defenseAttribute >= 80.0f) {
			defenseLevel = 5;	
		}

		if (sizeAttribute < 5.0f) {
			sizeLevel = 0;
		} else if (sizeAttribute >= 5.0f && sizeAttribute < 10.0f) {
			sizeLevel = 1;
		} else if (sizeAttribute >= 10.0f && sizeAttribute < 20.0f) {
			sizeLevel = 2;
		} else if (sizeAttribute >= 20.0f && sizeAttribute < 40.0f) {
			sizeLevel = 3;
		} else if (sizeAttribute >= 40.0f && sizeAttribute < 80.0f) {
			sizeLevel = 4;
		} else if (sizeAttribute >= 80.0f) {
			sizeLevel = 5;	
		}

		if (speedAttribute < 5.0f) {
			speedLevel = 0;
		} else if (speedAttribute >= 5.0f && speedAttribute < 10.0f) {
			speedLevel = 1;
		} else if (speedAttribute >= 10.0f && speedAttribute < 20.0f) {
			speedLevel = 2;
		} else if (speedAttribute >= 20.0f && speedAttribute < 40.0f) {
			speedLevel = 3;
		} else if (speedAttribute >= 40.0f && speedAttribute < 80.0f) {
			speedLevel = 4;
		} else if (speedAttribute >= 80.0f) {
			speedLevel = 5;	
		}

		if (attackAttribute < 0.0f) {
			attackAttribute = 0.0f;
		}
		if (defenseAttribute < 0.0f) {
			defenseAttribute = 0.0f;
		}
		if (sizeAttribute < 0.0f) {
			sizeAttribute = 0.0f;
		}
		if (speedAttribute < 0.0f) {
			speedAttribute = 0.0f;
		}

		Debug.Log ("Attack Level " + attackLevel);
		Debug.Log ("Attack Stats " + attackAttribute);
		Debug.Log ("Defense Level " + defenseLevel);
		Debug.Log ("Defense Stats " + defenseAttribute);
		Debug.Log ("Size Level " + sizeLevel);
		Debug.Log ("Size Stats " + sizeAttribute);
		Debug.Log ("Speed Level " + speedLevel);
		Debug.Log ("SPee Stats " + speedAttribute);
	}

	// Trigger Collision
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Food")
		{
			increaseSizeAttribute(1.0f);
			health += 0.5f;
			Destroy(other.gameObject);
		}

		if (other.tag == "Spike")
		{
			increaseDefenseAttribute(1.0f);
			health -= 1.0f;
		}
	}
	
    // Get Player Health	
	public float getPlayerHealth()
	{
		return health;
	}

    // Get Player Stamina
    public float getPlayerStamina()
    {
        return stamina;
    }

    public int getPlayerAttackLevel()
    {
        return attackLevel;
    }

    public int getPlayerDefenseLevel()
    {
        return defenseLevel;
    }

    public int getPlayerSizeLevel()
    {
        return sizeLevel;
    }

    public int getPlayerSpeedLevel()
    {
        return speedLevel;
    }

    public float getPlayerAttackStats()
    {
        return attackAttribute;
    }

    public float getPlayerDefenseStats()
    {
        return defenseAttribute;
    }

    public float getPlayerSizeStats()
    {
        return sizeAttribute;
    }

    public float getPlayerSpeedStats()
    {
        return speedAttribute;
    }
}
