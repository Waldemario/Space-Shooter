using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    
    [SerializeField] GameObject healthPowerUp;
    [SerializeField] GameObject shootPowerUp;
    [SerializeField] float speed;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void SpawnPowerUp(Vector3 position, float powerUpProbability)
    {
        float decider = Random.Range(0f, 1f);
        if (decider <= 0.5f)
        {
            float decider2 = Random.Range(0f, 1f);
            if (decider2 <= powerUpProbability)
            {
                GameObject powerUp = Instantiate(healthPowerUp, position, Quaternion.identity);
                powerUp.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
            }
        }
        else
        {
            float decider3 = Random.Range(0f, 1f);
            if (decider3 <= powerUpProbability)
            {
                GameObject powerUp = Instantiate(shootPowerUp, position, Quaternion.identity);
                powerUp.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
            }
        }
    }
}
