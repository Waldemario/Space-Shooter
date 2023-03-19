using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserProjectile : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( gameObject.transform.position.y > Camera.main.ViewportToWorldPoint(new Vector3(0, 1.2f, 0)).y || gameObject.transform.position.y < Camera.main.ViewportToWorldPoint(new Vector3(0, -0.2f, 0)).y )
        {
            
            Destroy(gameObject);
        }
    }
}
