using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] float timeBetweenSpawns = 0f;
    WaveConfig currentWave;
    [SerializeField] bool isLooping = false;
    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }
    public WaveConfig GetCurrentWave()
    {
        return currentWave;
    }
    IEnumerator SpawnEnemyWaves()
    {
        do
        {
            foreach (WaveConfig waveConfig in waveConfigs)
            {
                currentWave = waveConfig;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(i), currentWave.GetStartingWayPoint().position, Quaternion.Euler(0,0,180), transform);
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenSpawns);
            }
        } while (isLooping);
    }
}
