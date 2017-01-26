using UnityEngine;
using System.Collections;

public class LookAtFollow : MonoBehaviour {

	public Transform mTarget;
	public float rotationSpeed = 5.0f;

	private Vector3 mTargetVector;

	public float deltaTimeSpeed;

	// Use this for initialization
	void Start () {
		deltaTimeSpeed = 100.0f;
	}
	
	// Update is called once per frame
	void Update () {

		//Look towards the target's position
		Vector3 direction = mTarget.position - transform.position;
		float angle = Mathf.Atan2 (direction.z, direction.x) * Mathf.Rad2Deg - 90f;
		Quaternion rotation = Quaternion.AngleAxis (-angle, Vector3.up);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, rotationSpeed * Time.deltaTime);

		//Look at the target's position
		//transform.LookAt (mTarget.position);

		// Move towards the target's position
		mTargetVector = new Vector3 (mTarget.position.x, mTarget.position.y, mTarget.position.z);
		transform.position = Vector3.Lerp (transform.position, mTargetVector, Time.deltaTime * deltaTimeSpeed);
	}
}
