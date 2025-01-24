using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int waveCost, waveCicloQuant, enemiesToSpawnBase;
    [SerializeField] private CharacterStat enemiesToSpawnQuant;
    [SerializeField] private SpawnEnemiesSO enemiesToSpawn;
    private float spawnRate;

    public BoxCollider2D[] spawnCollider;

    private float waveTimer;
    private bool canSpawn = true;
    private int ciclo;

    private void Start()
    {
        waveTimer = LevelManager.instance.GetMaxLevelProgression();
        spawnRate = waveTimer / waveCicloQuant;
        StartCoroutine(SpawnObject());
    }

    private IEnumerator SpawnObject()
    {
        while (canSpawn)
        {
            StartCoroutine(Ciclo());

            yield return new WaitForSeconds(spawnRate);
        }
    }

    private IEnumerator Ciclo()
    {
        ciclo++;

        float cicloTimer = spawnRate / enemiesToSpawnBase;

        for(int i = 0; i < enemiesToSpawnBase; i++)
        {
            Spawn();

            yield return new WaitForSeconds(cicloTimer);
        }
    }

    private void Spawn()
    {
        //checar valor

        BoxCollider2D randomSpawn = spawnCollider[Random.Range(0, spawnCollider.Length)];

        Vector2 pos = new Vector2();
        pos.x = Random.Range(randomSpawn.bounds.min.x, randomSpawn.bounds.max.x);
        pos.y = Random.Range(randomSpawn.bounds.min.y, randomSpawn.bounds.max.y);

        EnemyToSpawn enemy = GetRandomEnemy();
        Instantiate(enemy.prefab, pos, Quaternion.identity);
    }

    private EnemyToSpawn GetRandomEnemy()
    {
        return enemiesToSpawn.GetEnemy(0);
    }
}
