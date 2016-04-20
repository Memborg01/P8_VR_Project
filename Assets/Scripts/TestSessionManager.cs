using UnityEngine;
using System.Collections;

public class TestSessionManager : MonoBehaviour {

    bool colorChanged = false;

    GameObject[] targets;
    GameObject ironSight, scope;

    GameObject M4A1, UMP45, HydraController;

    public Color checkColor, resetColor;

    Renderer targetRender;

    bool useIronSight, useScope, currentWeapon, weaponStock, FirstHydraInit;

    int weaponInt = 1;

    SixenseHandsController HydraGunController;

    // Use this for initialization
    void Start () {
        
        checkColor = Color.cyan;
        resetColor = Color.red;
        ironSight = GameObject.Find("M4A1_Sopmod_Iron_Sight");
        scope = GameObject.Find("ACOG Sight");
        
        targets = GameObject.FindGameObjectsWithTag("target");

        M4A1 = GameObject.Find("M4A1 Sopmod");
        UMP45 = GameObject.Find("UMP-45");
        HydraController = GameObject.Find("HydraController");

        HydraGunController = HydraController.GetComponent<SixenseHandsController>();


        useIronSight = true;
        useScope = false;
        currentWeapon = true;
        weaponStock = false;
        FirstHydraInit = true;

        ironSight.SetActive(useIronSight);
        scope.SetActive(useScope);

        

        

 


    }

    // Update is called once per frame
    void Update () {

        if(HydraGunController.m_bInitialized == true && FirstHydraInit == true)
        {
            M4A1.SetActive(currentWeapon);
            UMP45.SetActive(weaponStock);

            FirstHydraInit = false;
        }

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
        CycleWeapons();


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

    public void CycleWeapons()
    {

        if (Input.GetButtonDown("Fire3"))
        {

            weaponInt++;

            if(weaponInt > 2)
            {
                weaponInt = 1;
            }

            if(weaponInt == 1)
            {
                M4A1.SetActive(currentWeapon);
                UMP45.SetActive(weaponStock);
            }
            if(weaponInt == 2)
            {
                M4A1.SetActive(weaponStock);
                UMP45.SetActive(currentWeapon);
            }

        }

    }

}
