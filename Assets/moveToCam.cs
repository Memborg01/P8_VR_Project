using UnityEngine;
using System.Collections;

public class moveToCam : MonoBehaviour {

    public Quaternion adjustVec;
    Quaternion sQ, aQ, pQ;
    public float threshold = 0.1f;
    float splitSecond = 0f;
    public float rotSpeed = 10f;
    bool moving;
	void Awake () {
        pQ = transform.rotation;
        aQ = Quaternion.identity;
        sQ = aQ;
        // transform.position = transform.parent.GetChild(0).position;
    }

    // Update is called once per frame
    void Update() {
        transform.position = transform.parent.GetChild(0).position;
        splitSecond += rotSpeed * Time.deltaTime;
        if (splitSecond > 1)
            splitSecond = 1;

        transform.rotation = Quaternion.Lerp(pQ, sQ, splitSecond);

        if(transform.rotation == sQ)
        {
            splitSecond = 0;
            sQ = aQ;
            pQ = transform.rotation;
        }
            aQ = SixenseInput.Controllers[0].Rotation * adjustVec;
            
    }
}
