using UnityEngine;
using System.Collections;

public class moveToCam : MonoBehaviour {

    public Quaternion adjustVec;
	// Use this for initialization
	void Start () {
       // transform.position = transform.parent.GetChild(0).position;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = transform.parent.GetChild(0).position;
        transform.rotation = SixenseInput.Controllers[0].Rotation* adjustVec;
    }
}
