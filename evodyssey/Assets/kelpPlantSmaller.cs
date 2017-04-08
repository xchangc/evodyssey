using UnityEngine;
using System.Collections;

public class kelpPlantSmaller : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.right * Time.deltaTime * 10);
        transform.Rotate(Vector3.left * Time.deltaTime * 5);

    }
}
