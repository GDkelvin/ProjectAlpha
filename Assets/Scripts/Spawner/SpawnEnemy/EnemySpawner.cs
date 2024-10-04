using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    public Transform spawnPoint;

    public void SpawnEnemy()
    {
        if (enemyPrefab != null)
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            Debug.LogWarning("Enemy Prefab is not assigned!");
        }
    }
}
