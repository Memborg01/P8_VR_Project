using UnityEngine;
using System.Collections;

public class TestSessionManager : MonoBehaviour {

    bool colorChanged = false;

    GameObject[] targets;
    GameObject ironSight, scope;

    GameObject M4A1_Right, M4A1_Left, HydraController;

    public Color checkColor, resetColor1, resetColor2;

    Renderer targetRender;

    bool useIronSight, useScope, currentWeapon, weaponStock, FirstHydraInit;

    int weaponInt = 1;

    SixenseHandsController HydraGunController;

    HitCheck resetTargets;



    // Use this for initialization
    void Start () {
        
        checkColor = Color.cyan;
        resetColor1 = Color.red;
        resetColor2 = Color.white;
  
        targets = GameObject.FindGameObjectsWithTag("target");

        M4A1_Right = GameObject.Find("M4A1 SopmodRight");
        M4A1_Left = GameObject.Find("M4A1 SopmodLeft");
       
        HydraController = GameObject.Find("HydraController");

        HydraGunController = HydraController.GetComponent<SixenseHandsController>();


        useIronSight = true;
        useScope = false;
        currentWeapon = true;
        weaponStock = false;
        FirstHydraInit = true;

   
 

        

        

 


    }

    // Update is called once per frame
    void Update () {

        if(HydraGunController.m_bInitialized == true && FirstHydraInit == true)
        {
            M4A1_Right.SetActive(currentWeapon);
            M4A1_Left.SetActive(weaponStock);

            FirstHydraInit = false;
        }

        CheckTargets();

        if (Input.GetButtonDown("Submit"))
        {
            colorChanged = false;
            for(int j = 0; j < targets.Length; j++)
            {

                resetTargets = targets[j].GetComponent<HitCheck>();

                resetTargets.isHit = false;

                targetRender = targets[j].GetComponent<Renderer>();
                if(targets[j].gameObject.name == "1_target")
                {
                    targetRender.material.SetColor("_Color", resetColor2);
                }
                else
                {
                    targetRender.material.SetColor("_Color", resetColor1);
                }
                
            }
        }

      
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



    public void CycleWeapons()
    {

        if (Input.GetButtonDown("Fire3"))
        {

            weaponInt++;

            if(weaponInt > 3)
            {
                weaponInt = 1;
            }

            if(weaponInt == 1)
            {
                M4A1_Right.SetActive(currentWeapon);
                M4A1_Left.SetActive(weaponStock);
            }
            if(weaponInt == 2)
            {

                M4A1_Right.SetActive(weaponStock);
                M4A1_Left.SetActive(currentWeapon);

            }
            if(weaponInt == 3)
            {
                M4A1_Left.SetActive(currentWeapon);
                M4A1_Right.SetActive(currentWeapon);

            }

        }

    }



}
