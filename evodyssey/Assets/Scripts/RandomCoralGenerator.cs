using UnityEngine;
using System.Collections;

public class RandomCoralGenerator : MonoBehaviour {

	public GameObject coral;
	private int maxNumber;
	private float minX = -100;
	private float maxX = 100;
	private float minY = -50;
	private float maxY = -15;
	private float minZ = -100;
	private float maxZ = 100;

	// Use this for initialization
	void Start () {
		maxNumber = 50;
		for (int i = 0; i < maxNumber; i++) {
			Instantiate (coral, new Vector3(Random.Range (minX, maxX), Random.Range (minY, maxY), Random.Range (minZ, maxZ)), Quaternion.identity);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
