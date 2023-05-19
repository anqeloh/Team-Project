using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WaveSpawner : MonoBehaviour
{
    [SerializeField] public float countdown;
    public Wave[] waves;
    public int currentWaveIndex = 0;
    private bool readyToCountDown;
    public Transform[] spawnPoints;
    public GameObject enemyPrefab;
    private int enemyCount;
    private int waveNumber = 1;
    public int targetObjectCount = 5;
    private int destroyedObjectCount = 0;
    private bool triggeredEvent = false;
    
 
    public float timeBetweenEnemySpawn;
    public float timeBetweenWaves;
    bool spawningWave;

    private void Start()
    
    {
     readyToCountDown = true;

        for(int i = 0; i < waves.Length; i++)
        {
            waves[i].enemiesLeft = waves[i].enemies.Length;
        }
    }

    private void Update()
    {
        if (currentWaveIndex >= waves.Length)
        {
            Debug.Log("You survived every wave!");
            return;
        }
        
        if (!triggeredEvent && destroyedObjectCount >= targetObjectCount)
        {
            // Trigger your event or do something when the target object count is reached
            Debug.Log("Target object count reached!");
            triggeredEvent = true;
        }
        enemyCount = FindObjectsOfType<Enemy>().Length;
 
        if (enemyCount == 0 && !spawningWave)
        {
            waveNumber++;
            StartCoroutine(SpawnEnemyWave(waveNumber));
        }
        
         if (waves[currentWaveIndex].enemiesLeft == 0)
        {
            readyToCountDown = true;
            currentWaveIndex++;
        }
        if (readyToCountDown == true)
        {
            countdown -= Time.deltaTime;
        }
        if (enemyPrefab == null)
        {
            
        } 
     if (countdown <= 0)
     {
        readyToCountDown = false;
        countdown = waves[currentWaveIndex].timeToNextWave;
        StartCoroutine(SpawnEnemyWave(waveNumber));
     }   

     void ObjectDestroyed()
    {
        destroyedObjectCount++;
    }
    }

    IEnumerator SpawnEnemyWave(int enemiesToSpawn)
    {
        spawningWave = true;
        yield return new WaitForSeconds(timeBetweenWaves); //We wait here to pause between wave spawning
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, enemyPrefab.transform.rotation);
            yield return new WaitForSeconds(timeBetweenEnemySpawn); //We wait here to give a bit of time between each enemy spawn
        }
        spawningWave = false;
    }


        
    
}

[System.Serializable]
public class Wave
{
    public Enemy[] enemies;
    public float timeToNextEnemy;
    public float timeToNextWave;
    [HideInInspector] public int enemiesLeft;
}