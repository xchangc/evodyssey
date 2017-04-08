using UnityEngine;
using System.Collections;

public class kelpPlantRotation : MonoBehaviour {
    public Transform from;
    public Transform to;
    public float speed = 0.4f;
	// Use this for initialization
	void Start () {

        
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(50,0,0), Time.deltaTime * speed);
        if(Quaternion.Euler(50,0,0) == transform.rotation)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(-50, 0, 0), Time.deltaTime * speed);
        }
        else
        {
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(50, 0, 0), Time.deltaTime * speed);
        }


        /*if ()
        {
            transform.Rotate(Vector3.right * Time.deltaTime * 5);
            //transform.Rotate(Vector3.left * Time.deltaTime * 25);
            //transform.Rotate(Vector3.up * Time.deltaTime * 15);
        }
        else if(transform.rotation.eulerAngles.x > -35)
        {
            transform.Rotate(Vector3.left * Time.deltaTime * 10);
        }
        else
        {
            transform.Rotate(Vector3.right * Time.deltaTime * 5);
        }
        */

    }
}
