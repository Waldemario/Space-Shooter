using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigList;
    [SerializeField] int startingWave = 0;
    [SerializeField] bool looping = false;
    float additionalHp = 1;
    
    
    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
            additionalHp += 0.25f;
        }
        while (looping);
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        yield return new WaitForSeconds(waveConfig.GetTimeBeforeSpawns());
        for (int i = 0; i < waveConfig.GetEnemiesCount(); i++)
        {
            GameObject enemy =  Instantiate(waveConfig.GetEnemyPrefab(), waveConfig.GetWaypoints()[0].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
            enemy.GetComponent<Enemy>().AddHp(additionalHp);
            yield return new WaitForSeconds(Random.Range(waveConfig.GetTimeBtwSpawns() - waveConfig.GetRandomFactor(), waveConfig.GetTimeBtwSpawns() + waveConfig.GetRandomFactor()));
            
        }
        
    }

    private IEnumerator SpawnAllWaves()
    {
        for (int waveIndex = startingWave; waveIndex < waveConfigList.Count; waveIndex++)
        {
            var currentWaveConfig = waveConfigList[waveIndex];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWaveConfig));
        }

    }


}
