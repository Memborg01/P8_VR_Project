using UnityEngine;
using System.Collections;

public class TestSessionManager : MonoBehaviour {

    bool colorChanged = false;

    GameObject[] targets;
    GameObject ironSight, scope;

    public Color checkColor, resetColor;

    Renderer targetRender;

    bool useIronSight, useScope;



    // Use this for initialization
    void Start () {
        
        checkColor = Color.cyan;
        resetColor = Color.red;
        ironSight = GameObject.Find("M4A1_Sopmod_Iron_Sight");
        scope = GameObject.Find("ACOG Sight");
        
        targets = GameObject.FindGameObjectsWithTag("target");


        useIronSight = true;
        useScope = false;


        ironSight.SetActive(useIronSight);
        scope.SetActive(useScope);


    }
	
	// Update is called once per frame
	void Update () {

        CheckTargets();

        if (Input.GetButtonDown("Submit"))
        {
            colorChanged = false;
            for(int j = 0; j < targets.Length; j++)
            {
                targetRender = targets[j].GetComponent<Renderer>();
                targetRender.material.SetColor("_Color", resetColor);
            }
        }

        ToggleSight();
        


    }



    void CheckTargets()
    {

        int i;

        if (colorChanged == false)
        {
            for (i = 0; i < targets.Length; i++)
            {
                targetRender = targets[i].GetComponent<Renderer>();

                if (targetRender.material.color == checkColor)
                {
                    colorChanged = true;
                }
                else if (targetRender.material.color != checkColor)
                {
                    colorChanged = false;
                    i = 0;
                    break;
                }
                //Debug.Log("i = " + i);
            }
        }

        //Debug.Log("colorChanged = " + colorChanged);

      /*  if (colorChanged)
        {
            timeCheck = Time.time;

        }*/


    }

    void OnGUI()
    {
        if (colorChanged)
        {
            //Debug.Log("Entered OnGUI");
            GUI.Label(new Rect((Screen.width/2)-40, (Screen.height/2)+50, Screen.width, Screen.height), "All targets hit");
        }

    }

    public void ToggleSight()
    {

        if (Input.GetButtonDown("num_1"))
        {
            useIronSight = true;
            useScope = false;


            ironSight.SetActive(useIronSight);
            scope.SetActive(useScope);
        }
        if (Input.GetButtonDown("num_2"))
        {
            useIronSight = false;
            useScope = true;


            ironSight.SetActive(useIronSight);
            scope.SetActive(useScope);
        }

    }



}
