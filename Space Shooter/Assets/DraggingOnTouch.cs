using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggingOnTouch : MonoBehaviour
{
	float deltax; 
	float deltay;

	bool dragging = false;
    void Start()
    {
        
    }

    
    void Update()
	{
		Drag();
	}

	private void Drag()
	{
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);

			Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

			if (touch.phase == TouchPhase.Began)
			{
				
				if (GetComponent<Rigidbody2D>() == Physics2D.OverlapPoint(touchPos))
				{
					dragging = true;
					deltax = transform.position.x - touchPos.x;
					deltay = transform.position.y - touchPos.y;

				}
			}
			else if (touch.phase == TouchPhase.Moved)
			{
				if (dragging == true) 
				{
					transform.position = new Vector3(touchPos.x + deltax, touchPos.y + deltay, transform.position.z);
				}
			}
			else if (touch.phase == TouchPhase.Ended)
			{
				dragging = false;
			}
			
		}
	}
}
