using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Spawn/New SpawnEnemies")]
public class SpawnEnemiesSO : ScriptableObject
{
    public EnemyToSpawn[] enemiesToSpawn;

    public EnemyToSpawn GetEnemy(int index)
    {
        return enemiesToSpawn[index];
    }
}
