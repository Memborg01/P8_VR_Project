using UnityEngine;
using System.Collections;

public class Calibrate : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Jump"))
        {
            if(Vector3.Angle(Vector3.up, transform.up) != 0)
            {
                transform.up = Vector3.up;
            }
        }


	}
}
