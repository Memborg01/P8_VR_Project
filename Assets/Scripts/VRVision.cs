using UnityEngine;
using System.Collections;

public class VRVision : MonoBehaviour {


    public GameObject hydraInput, hydraController;

    Vector3 inputPos, controllerPos;

    SixenseHandsController sixenceHandsController;

    bool initializeHydra;


	// Use this for initialization
	void Start () {

        

        initializeHydra = false;

        hydraInput = GameObject.Find("SixenseInput");
        hydraController = GameObject.Find("HydraController");

        sixenceHandsController = hydraController.GetComponent<SixenseHandsController>();

        inputPos = new Vector3(-0.223f, -1.986f, 0.87f);
        controllerPos = new Vector3(0.335f, 3.742f, -0.858f);

    }
	
	// Update is called once per frame
	void Update () {
	
        if(sixenceHandsController.m_bInitialized == true && initializeHydra == false)
        {


            Debug.Log("Controllers Initialized");

            initializeHydra = true;

        }

	}
}
