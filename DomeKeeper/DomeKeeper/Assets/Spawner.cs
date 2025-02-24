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

    [SerializeField] private DelegateFuncionSO onWaveEnd;

    private int enemiesAlive;

    private float waveTimer;
    private bool spawning;
    private int ciclo;

    private void Start()
    {
        waveTimer = LevelManager.instance.GetMaxLevelProgression();
        spawnRate = waveTimer / waveCicloQuant;
        StartSpawn();
    }

    private void StartSpawn()
    {
        spawning = true;

        StartCoroutine(SpawnObject());
    }

    private IEnumerator SpawnObject()
    {
        for (int i = 0; i < waveCicloQuant; i++)
        {
            StartCoroutine(Ciclo());

            yield return new WaitForSeconds(spawnRate);
        }

        spawning = false;
    }

    private IEnumerator Ciclo()
    {
        ciclo++;

        float cicloTimer = spawnRate / enemiesToSpawnQuant.GetCurrentStat();

        for(int i = 0; i < enemiesToSpawnQuant.GetCurrentStat(); i++)
        {
            SpawnEnemy();

            yield return new WaitForSeconds(cicloTimer);
        }
    }

    private void SpawnEnemy()
    {
        //checar valor

        Vector2 pos = GetRandomPos();

        EnemyToSpawn enemy = GetRandomEnemy();

        Spawn(enemy.prefab, pos);
    }

    public void SpawnMiniBoss()
    {
        Vector2 pos = GetRandomPos();
        GameObject miniBoss = enemiesToSpawn.MiniBoss();

        Spawn(miniBoss, pos);
    }

    private void Spawn(GameObject obj, Vector2 pos)
    {
        Instantiate(obj, pos, Quaternion.identity);
    }

    private Vector2 GetRandomPos()
    {
        BoxCollider2D randomSpawn = spawnCollider[Random.Range(0, spawnCollider.Length)];

        Vector2 pos = new Vector2();
        pos.x = Random.Range(randomSpawn.bounds.min.x, randomSpawn.bounds.max.x);
        pos.y = Random.Range(randomSpawn.bounds.min.y, randomSpawn.bounds.max.y);

        return pos;
    }

    private EnemyToSpawn GetRandomEnemy()
    {
        return enemiesToSpawn.GetEnemy(Random.Range(0, enemiesToSpawn.EnemiesLength()));
    }

    public void EnemyDead()
    {
        enemiesAlive--;

        if (enemiesAlive <= 0 && spawning)
        {
            onWaveEnd?.onFuncionCalled.Invoke();
        }
    }
}
