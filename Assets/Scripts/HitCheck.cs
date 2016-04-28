using UnityEngine;
using System.Collections;

public class HitCheck : MonoBehaviour {

    public bool isHit;

	// Use this for initialization
	void Start () {

        isHit = false;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool setHit(bool targetHit)
    {
        isHit = targetHit;

        return isHit;
    }

}
