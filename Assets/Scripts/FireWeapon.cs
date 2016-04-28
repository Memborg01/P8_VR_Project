using UnityEngine;
using System.Collections;

public class FireWeapon : MonoBehaviour {

    public Rigidbody projectile;
    public float speed;

    public bullet Bullet;

    public GameObject collidingObj, zoomLens;
    bool lensActive;
    Renderer render;
    Color targetColor;
    Ray ray;
    RaycastHit bulletHit;

    GameObject gameManager;

    
    PointSystem pointSystem;
    public HitCheck hitCheck;

    void Awake()
    {
        zoomLens = GameObject.Find("LensZoom");
        gameManager = GameObject.Find("GameManager");
    }

    void Start()
    {

        
        targetColor = Color.cyan;

        lensActive = true;

        zoomLens.SetActive(lensActive);

        pointSystem = gameManager.GetComponent<PointSystem>();
        

    }
	

	void Update () {

        ray = new Ray(transform.position, transform.forward);
        

        if (Input.GetButtonDown("Fire1") || SixenseInput.Controllers[1].Trigger == 1)
        {
            Rigidbody instantiateBullet = Instantiate(projectile, transform.position, projectile.gameObject.transform.rotation) as Rigidbody;

            instantiateBullet.velocity = transform.TransformDirection(new Vector3(0, 0, speed));

            Bullet = instantiateBullet.GetComponent<bullet>();

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
                        render = collidingObj.GetComponent<Renderer>();
                        render.material.SetColor("_Color", targetColor);

                        hitCheck = collidingObj.GetComponent<HitCheck>();


                        if (hitCheck.isHit == false)
                        {
                            pointSystem.centerHit();
                            hitCheck.isHit = true;

                        }

                        
                        

                    }

                    if (bulletHit.collider.gameObject.name == "1_target")
                    {
                        //Debug.Log("collider is target");
                        render = collidingObj.GetComponent<Renderer>();
                        render.material.SetColor("_Color", targetColor);

                        hitCheck = collidingObj.GetComponent<HitCheck>();

                        if(hitCheck.isHit == false)
                        {
                            pointSystem.innerRingHit();
                            hitCheck.isHit = true;
                        }
                       


                    }

                    if (bulletHit.collider.gameObject.name == "2_target")
                    {
                        //Debug.Log("collider is target");
                        render = collidingObj.GetComponent<Renderer>();
                        render.material.SetColor("_Color", targetColor);

                        hitCheck = collidingObj.GetComponent<HitCheck>();

                        if(hitCheck.isHit == false)
                        {
                            pointSystem.outerRingHit();
                            hitCheck.isHit = true;
                        }
                        



                    }
                    Bullet.destroyBullet();
                    
                }
            }


        }


        





	}

    
}
