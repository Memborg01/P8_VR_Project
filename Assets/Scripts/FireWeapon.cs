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


    void Start()
    {

        zoomLens = GameObject.Find("LensZoom");
        targetColor = Color.cyan;

        lensActive = false;

        zoomLens.SetActive(lensActive);
        

    }
	

	void Update () {

        ray = new Ray(transform.position, transform.forward);
        

        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody instantiateBullet = Instantiate(projectile, transform.position, projectile.gameObject.transform.rotation) as Rigidbody;

            instantiateBullet.velocity = transform.TransformDirection(new Vector3(0, 0, speed));

            Bullet = instantiateBullet.GetComponent<bullet>();

            // Debug.DrawRay(transform.position, transform.forward * 30, Color.magenta, 200f);

            // Raycast collision check

            if (Physics.Raycast(ray, out bulletHit))
            {
                Debug.Log("Physics Raycast");
               
                if (bulletHit.collider != null)
                {
                    collidingObj = bulletHit.collider.gameObject;
                    Vector3 collPos = collidingObj.transform.position;

                    
                    if (bulletHit.collider.gameObject.tag == "target")
                    {
                        Debug.Log("collider is target");
                        render = collidingObj.GetComponent<Renderer>();
                        render.material.SetColor("_Color", targetColor);
                    }
                    Bullet.destroyBullet();
                    
                }
            }


        }


        ToggleZoom();





	}

    public void ToggleZoom()
    {



        if (Input.GetButtonDown("Fire2"))
        {

            lensActive = !lensActive;

            zoomLens.SetActive(lensActive);

        }
    }

    
}
