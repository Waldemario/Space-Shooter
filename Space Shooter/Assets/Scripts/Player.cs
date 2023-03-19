using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float healthPoints = 100;
    [SerializeField] GameObject healthText;
    [SerializeField] bool invincible = false;
    
    [Header("Player Movement")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] GameObject laserPrefab;

    [Header("Projectile")]
    [SerializeField] float laserSpeed = 10f;
    [SerializeField] float projectileFiringPeriod = 45f;
    Coroutine firingCoroutine;

    [Header("Sounds")]
    [SerializeField] AudioClip deathClip;
    [SerializeField] float deathClipVolume = 1;
    [SerializeField] AudioClip shootClip;
    [SerializeField] float shootClipVolume = 1;
    [SerializeField] GameObject explosionVFX;
    [SerializeField] AudioClip damageSound;
    [SerializeField] AudioClip powerUpClip;
    [SerializeField] float pUClipVolume = 1;



    float xMax;
    float xMin;
    float yMax;
    float yMin;

  

    void Start()
    {
        SetUpMoveBoundaries();
        
         
    }

    
    void Update()
    {
        MoveAllDir();
        Fire();
        
        

    }


	/* private void Move() // moving only horizontally with keys
     {
        var deltaXPos = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        Debug.Log(deltaXPos);
         var newXPos = transform.position.x + deltaXPos;
         transform.position = new Vector2(newXPos, transform.position.y);
     } */

	private void MoveAllDir() //moving also vertically with keys
    {
        var deltaXPos = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaYPos = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
       
        var newXPos = Mathf.Clamp(transform.position.x + deltaXPos, xMin, xMax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaYPos, yMin,yMax);
        transform.position = new Vector2(newXPos, newYPos);
    }
    /* private void MoveMouse() // try movement with mouse
    {
        var deltaXPos = Input.GetAxis("Horizontal");
        var deltaYPos = Input.GetAxis("Vertical");
        var newXPos = transform.position.x + deltaXPos;
        var newYPos = transform.position.y + deltaYPos;
        transform.position = new Vector2(newXPos, newYPos); */

    private void SetUpMoveBoundaries() 
    {
        Camera gameCamera = Camera.main;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
         xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + spriteRenderer.bounds.size.x / 2;
         xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - spriteRenderer.bounds.size.x / 2;
         yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + spriteRenderer.bounds.size.y / 4;
         yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - spriteRenderer.bounds.size.y / 2;
      
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            firingCoroutine = StartCoroutine(FireContinuously()); // calling coroutine AND instantiating it, to stop it in the next step

        }
        if (Input.GetButtonUp("Fire1"))
        {
           StopCoroutine(firingCoroutine); // stopping this exact coroutine
        }

    }

    IEnumerator FireContinuously() //creating coroutine
    {
        while (true)
        {
            GameObject laserBeam = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject; // instantiating prefab
            AudioSource.PlayClipAtPoint(shootClip, Camera.main.transform.position, shootClipVolume);
            laserBeam.GetComponent<Rigidbody2D>().velocity = new Vector2(0, laserSpeed); // setting velocity
            yield return new WaitForSeconds(10/projectileFiringPeriod); // waits
        }
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.tag == "Projectile")
        {
            var damageDealer = collision.GetComponent<DamageDealer>();
            if (!damageDealer) { return; }
            damageDealer.Hit();
            ProcessHit(damageDealer);
        }
        else if (collision.tag == "Health")
        {
            PowerUp powerup = collision.GetComponent<PowerUp>();
            powerup.SpawnText("+ health points");
            powerup.Hit();
            AudioSource.PlayClipAtPoint(powerUpClip, Camera.main.transform.position, pUClipVolume);
            healthPoints += 20;
            healthPoints = Mathf.Clamp(healthPoints, 0f, 100f);
        }
        else if (collision.tag == "Shoot")
        {
            PowerUp powerup = collision.GetComponent<PowerUp>();
            powerup.SpawnText("+ shooting rate");
            powerup.Hit();
            AudioSource.PlayClipAtPoint(powerUpClip, Camera.main.transform.position, pUClipVolume);
            projectileFiringPeriod += 4f;
        }

	}

	private void ProcessHit(DamageDealer damageDealer)
	{
        if (invincible == false)
        {
            healthPoints -= damageDealer.GetDamage();
        }
        StartCoroutine(healthText.GetComponent<HealthText>().ShakeCycle());
        AudioSource.PlayClipAtPoint(damageSound, Camera.main.transform.position, deathClipVolume);
        if (healthPoints <= 0)
		{
            healthPoints = Mathf.Clamp(healthPoints, 0f, 100f);
            Die();
		}
	}

	private void Die()
	{
        FindObjectOfType<Level>().LoadGameOver();
        AudioSource.PlayClipAtPoint(deathClip, Camera.main.transform.position, deathClipVolume);
        Instantiate(explosionVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
        
	}

    public float GetHP()
    {
        return healthPoints;
    }
}

    

