using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float distance = 1.0f;
	public float deltaTimeSpeed = 1.0f;
	public float rotationSpeed = 2.5f;
	public float stamina = 60.0f;
	public float maxStamina = 60.0f;
	public float minStamina = 0.0f;
	public float attackRate = 20.0f;

	public Transform attackArea;

	public bool useInitialCameraDistance = false;

	protected bool isDashing;
	protected bool isAttacking;

	private float actualDistance;

	void Start () {

		isDashing = false;
		isAttacking = false;

		if (useInitialCameraDistance) {
			Vector3 toObjectVector = transform.position - Camera.main.transform.position;
			Vector3 linearDistanceVector = Vector3.Project (toObjectVector, Camera.main.transform.forward);
			actualDistance = linearDistanceVector.magnitude;
		} else {
			actualDistance = distance;
		}
	}
		
	void Update () {
		
		Vector3 mousePosition = Input.mousePosition;
		mousePosition.z = actualDistance;

		// Look towards the direction of the Mouse Position
		Vector3 direction = Camera.main.ScreenToWorldPoint (mousePosition) - transform.position;
		float angle = Mathf.Atan2 (direction.z, direction.x) * Mathf.Rad2Deg - 90f;
		Quaternion rotation = Quaternion.AngleAxis (-angle, Vector3.up);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, rotationSpeed * Time.deltaTime);

		// Look at the mouse position
		//transform.LookAt (Camera.main.ScreenToWorldPoint (mousePosition));

		// Move towards mouse position
		transform.position = Vector3.Lerp (transform.position, Camera.main.ScreenToWorldPoint (mousePosition), Time.deltaTime * deltaTimeSpeed);

		// Dashing
		if (Input.GetMouseButton (1)) {
			if (stamina > minStamina) {
				stamina -= 1;
				deltaTimeSpeed = 3.0f;
			} else if (stamina <= minStamina) {
				stamina = 0;
				deltaTimeSpeed = 1.0f;
			}
			SetIsDashing (true);
		} else {
			if (stamina < maxStamina) {
				stamina += 2;
			} else if (stamina >= maxStamina) {
				stamina = maxStamina;
			}
			deltaTimeSpeed = 1.0f;
			isDashing = false;
			SetIsDashing (false);
		}

		// Attack
		if (Input.GetMouseButtonDown (0)) {
			if (attackRate >= 20) {
				isAttacking = true;
				attackRate = 0;
			}
		} else {
			if (attackRate < 20) {
				attackRate += 1;
			} else if (attackRate >= 20) {
				attackRate = 20;
			}
			isAttacking = false;
		}
	}

	// Get is Dashing
	public bool GetIsDashing() {
		return isDashing;
	}

	// Set is Dashing
	void SetIsDashing(bool dashing) {
		isDashing = dashing; 
	}

	public bool GetIsAttacking() {
		return isAttacking;
	}
}
