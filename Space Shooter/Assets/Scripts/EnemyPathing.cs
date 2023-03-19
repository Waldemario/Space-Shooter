using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    WaveConfig waveConfig;
    List<Transform> waypoints;
    int currentIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[currentIndex].transform.position;
    }



    // Update is called once per frame
   void Update()
	{
		Move();
	}

	private void Move()
	{
		if (currentIndex <= waypoints.Count-1)
		{
			var targetPosition = waypoints[currentIndex].transform.position;
			var movementThisFrame = waveConfig.GetMoveSpeed() * Time.deltaTime;
			transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
			if (transform.position == targetPosition)
			{
				currentIndex++;
			}
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public void SetWaveConfig(WaveConfig waveConfig1) 
	{
		this.waveConfig = waveConfig1;
	}

	
}
