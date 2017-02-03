using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float startingHealth;
	public float startingStamina;
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

	// Use this for initialization
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
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (1)) {
			
		}
	}

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

		if (attackAttribute < 0.0f) {
			attackAttribute = 0.0f;
		}
		if (defenseAttribute < 0.0f) {
			defenseAttribute = 0.0f;
		}

		Debug.Log ("Attack Level" + attackLevel);
		Debug.Log ("Attack Stats" + attackAttribute);
		Debug.Log ("Defense Level" + defenseLevel);
		Debug.Log ("Defense Stats" + defenseAttribute);
	}

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

		if (attackAttribute < 0.0f) {
			attackAttribute = 0.0f;
		}
		if (defenseAttribute < 0.0f) {
			defenseAttribute = 0.0f;
		}

		Debug.Log ("Attack Level" + attackLevel);
		Debug.Log ("Attack Stats" + attackAttribute);
		Debug.Log ("Defense Level" + defenseLevel);
		Debug.Log ("Defense Stats" + defenseAttribute);
	}

	public void increaseSizeAttribute (float f)
	{
		sizeAttribute += f;
		speedAttribute -= f / 2.0f;
	}

	public void increaseSpeedAttribute (float f)
	{
		speedAttribute += f;
		sizeAttribute -= f / 2.0f;
	}
}
