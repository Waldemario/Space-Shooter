using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] int enemiesCount = 5;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float timeBeforeSpawns = 2f;

    public GameObject GetEnemyPrefab() { return enemyPrefab; }
    public List<Transform> GetWaypoints()
    {
        var waypoints = new List<Transform>();

        foreach (Transform child in pathPrefab.transform)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }
    
    public float GetTimeBtwSpawns() { return timeBetweenSpawns; }
    public float GetRandomFactor() { return spawnRandomFactor; }
    public int GetEnemiesCount() { return enemiesCount; }
    public float GetMoveSpeed() { return moveSpeed; }
    public float GetTimeBeforeSpawns() { return timeBeforeSpawns; }
}
