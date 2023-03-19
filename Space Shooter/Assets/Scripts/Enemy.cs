using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] float powerUpProbability = 0.1f;
	[SerializeField] int killScore;
    [SerializeField] float healthPoints = 100f;
	[SerializeField] GameObject projectilePrefab;
	[SerializeField] float timeBetweenShots = 1f;
	[SerializeField] float firingRandomness = 0.3f;
	[SerializeField] float projectileSpeed = 10;
	[SerializeField] GameObject explosionVFX;
	PowerUpSpawner powerUpSpawner;
	[Header("Sounds")]
	[SerializeField] AudioClip deathClip;
	[SerializeField] float deathClipVolume = 1;
	[SerializeField] AudioClip shootClip;
	[SerializeField] float shootClipVolume = 1;

	private void Start()
	{
		StartCoroutine(Shoot());
		powerUpSpawner = FindObjectOfType<PowerUpSpawner>();
		
	}

	IEnumerator Shoot()
	{
		while (true)
		{
			if (Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x < transform.position.x && transform.position.x  < Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x)
			{ 
				var projectile = Instantiate(projectilePrefab, transform.position, Quaternion.Inverse(Quaternion.identity));
				projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
				AudioSource.PlayClipAtPoint(shootClip, Camera.main.transform.position, shootClipVolume); 
			}
			yield return new WaitForSeconds(UnityEngine.Random.Range(timeBetweenShots - firingRandomness, timeBetweenShots + firingRandomness));
			//yield return new WaitForSeconds(0.5f);
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		
		var damageDealer = other.GetComponent<DamageDealer>();
		if (!damageDealer) { return; }
		ProcessHit(damageDealer);
		
	}

	private void ProcessHit(DamageDealer damageDealer)
	{
		healthPoints -= damageDealer.GetDamage();
		damageDealer.Hit();
		if (healthPoints <= 0)
		{
			DestroyEnemy();
		}
	} 

	private void DestroyEnemy()
	{
		AudioSource.PlayClipAtPoint(deathClip, Camera.main.transform.position, deathClipVolume);
		FindObjectOfType<ScoreCounter>().AddToScore(killScore);
		Instantiate(explosionVFX, transform.position, Quaternion.identity);
		powerUpSpawner.SpawnPowerUp(transform.position, powerUpProbability);
		Destroy(gameObject);
	}

	public void AddHp(float addition)
	{
		healthPoints *= addition; 
	}
}
