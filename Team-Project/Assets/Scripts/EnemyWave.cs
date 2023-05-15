using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    [SerializeField] private float countdown;

    public GameObject enemyPrefab; // Prefab of the enemy
    public Transform[] spawnPoints; // Array of spawn points
    public float spawnInterval = 2f; // Interval between enemy spawns
    public int waveCount = 5; // Number of waves

    private int currentWave = 0; // Current wave number

    private void Start()
    {
        // Start spawning enemy waves
        StartCoroutine(SpawnEnemyWaves());
    }

    private IEnumerator SpawnEnemyWaves()
    {
        while (currentWave < waveCount)
        {
            yield return new WaitForSeconds(spawnInterval);

            // Spawn enemies for the current wave
            {
                SpawnEnemies();
            }
            currentWave++;
        }
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            // Instantiate an enemy at each spawn point
            GameObject enemy = Instantiate(enemyPrefab, spawnPoints[i].position, spawnPoints[i].rotation);
            // You can also set additional enemy properties here if needed
        }
    }
}
