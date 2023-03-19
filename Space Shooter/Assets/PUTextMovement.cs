using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUTextMovement : MonoBehaviour
{
    Vector3 originalPos;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 originalPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

	private void Move()
	{
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(-314, -625 , originalPos.z) , 100*Time.deltaTime);
        
        if (transform.localPosition.y >= -625)
        {
            Destroy(gameObject);
        }
    }
}
