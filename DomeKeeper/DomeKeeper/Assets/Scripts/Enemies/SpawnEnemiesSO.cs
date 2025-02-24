using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Spawn/New SpawnEnemies")]
public class SpawnEnemiesSO : ScriptableObject
{
    public EnemyToSpawn[] enemiesToSpawn;
    public GameObject miniBoss;

    public EnemyToSpawn GetEnemy(int index)
    {
        return enemiesToSpawn[index];
    }

    public GameObject MiniBoss()
    {
        return miniBoss;
    }

    public int EnemiesLength()
    {
        return enemiesToSpawn.Length;
    }
}
