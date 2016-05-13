using UnityEngine;
using System.Collections;

public class FireWeapon : MonoBehaviour {

    public Rigidbody projectile;
    public float speed;

    public bullet Bullet;
    public GameObject hitAni;
    public GameObject collidingObj;
    bool lensActive;
    Renderer render;
    Color targetColor;
    Ray ray;
    RaycastHit bulletHit;

    GameObject gameManager;

    
    PointSystem pointSystem;
    public HitCheck hitCheck;

    public bool hasFired;

    void Awake()
    {
        gameManager = GameObject.Find("GameManager");
    }

    void Start()
    {

        
        targetColor = Color.cyan;

        lensActive = true;

        hasFired = false;



        pointSystem = gameManager.GetComponent<PointSystem>();
        

    }
	

	void Update () {

      

        if (Input.GetButtonDown("Fire1") || SixenseInput.Controllers[1].Trigger == 1 && hasFired == false)
        {
            print("FIRE");
            hasFired = true;
            ray = new Ray(transform.position, transform.forward);

            if(Physics.Raycast(ray, out bulletHit))
            {
                GameObject newAni = Instantiate(hitAni, bulletHit.point, Quaternion.identity) as GameObject;

            }
            //Rigidbody instantiateBullet = Instantiate(projectile, transform.position, projectile.gameObject.transform.rotation) as Rigidbody;

            // instantiateBullet.velocity = transform.TransformDirection(new Vector3(0, 0, speed));

            // Bullet = instantiateBullet.GetComponent<bullet>();

            //Debug.DrawRay(transform.position, transform.forward * 30, Color.magenta, 200f);

            // Raycast collision check

            if (Physics.Raycast(ray, out bulletHit))
            {
                //Debug.Log("Physics Raycast");
                Debug.DrawRay(transform.position, transform.forward * 30, Color.magenta, 200f);
                if (bulletHit.collider != null)
                {
                    collidingObj = bulletHit.collider.gameObject;
                    Vector3 collPos = collidingObj.transform.position;

                    
                    if (bulletHit.collider.gameObject.name == "centerTarget")
                    {
                        //Debug.Log("collider is target");
                        
                        hitCheck = collidingObj.GetComponent<HitCheck>();

    
                        if (hitCheck.isHit == false)
                        {
                            render = collidingObj.GetComponent<Renderer>();
                            render.material.SetColor("_Color", targetColor);

                            pointSystem.centerHit();
                            hitCheck.isHit = true;

                        }

                        GameObject targetParent = bulletHit.collider.gameObject.transform.parent.gameObject;
                        checkTarget(targetParent);

                        
                        

                    }

                    if (bulletHit.collider.gameObject.name == "1_target")
                    {
                        //Debug.Log("collider is target");
                        

                        hitCheck = collidingObj.GetComponent<HitCheck>();

                        if(hitCheck.isHit == false)
                        {

                            render = collidingObj.GetComponent<Renderer>();
                            render.material.SetColor("_Color", targetColor);

                            pointSystem.innerRingHit();
                            hitCheck.isHit = true;
                        }

                        GameObject targetParent = bulletHit.collider.gameObject.transform.parent.gameObject;
                        checkTarget(targetParent);



                    }

                    if (bulletHit.collider.gameObject.name == "2_target")
                    {
                        //Debug.Log("collider is target");
                        

                        hitCheck = collidingObj.GetComponent<HitCheck>();

                        if(hitCheck.isHit == false)
                        {
                            render = collidingObj.GetComponent<Renderer>();
                            render.material.SetColor("_Color", targetColor);
                            pointSystem.outerRingHit();
                            hitCheck.isHit = true;
                        }

                        GameObject targetParent = bulletHit.collider.gameObject.transform.parent.gameObject;
                        checkTarget(targetParent);



                    }
                   // Bullet.destroyBullet();
                    
                }
            }

           

        }

        if (Input.GetButtonDown("Fire1") == false && SixenseInput.Controllers[1].Trigger == 0)
        {
            hasFired = false;
          
        }








    }

    public void checkTarget(GameObject parent)
    {

        int amountChilds = parent.transform.childCount;
        GameObject[] targetChilds = new GameObject[amountChilds];

        HitCheck targetHit, setTargets;
       

        for(int i = 0; i < amountChilds; i++)
        {
            targetChilds[i] = parent.transform.GetChild(i).gameObject;
        }

        for(int i = 0; i < amountChilds; i++)
        {

            targetHit = targetChilds[i].GetComponent<HitCheck>();

            if(targetHit.isHit == true)
            {
                for(int j = 0; j < amountChilds; j++)
                {
                    setTargets = targetChilds[j].GetComponent<HitCheck>();

                    setTargets.isHit = true;
                }
            }

        }


    }


}
