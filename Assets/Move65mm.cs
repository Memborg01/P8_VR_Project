using UnityEngine;
using System.Collections;

public class Move65mm : MonoBehaviour {

    float tx, ty, tz;
    bool split= false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (split)
            tx = transform.parent.GetChild(0).position.x - 0.065f;
        else
            tx = transform.parent.GetChild(0).position.x;
        ty = transform.parent.GetChild(0).position.y;
        tz = transform.parent.GetChild(0).position.z;
        transform.position = new Vector3(tx, ty, tz);
        if (Input.GetButtonDown("num_3"))
            split = !split;
	}
}
