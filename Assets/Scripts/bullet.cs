using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {

    public Renderer render;
    public Color targetColor = Color.cyan;


    public void destroyBullet()
    {
        Destroy(this.gameObject);
    }

   

}
