using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnRate;

    public GameObject objectToSpawn;
    public BoxCollider2D[] spawnCollider;

    private bool canSpawn = true;

    private void Start()
    {
        StartCoroutine(SpawnObject());
    }

    private IEnumerator SpawnObject()
    {
        while (canSpawn)
        {
            BoxCollider2D randomSpawn = spawnCollider[Random.Range(0, spawnCollider.Length)];

            Vector2 pos = new Vector2();
            pos.x = Random.Range(randomSpawn.bounds.min.x, randomSpawn.bounds.max.x);
            pos.y = Random.Range(randomSpawn.bounds.min.y, randomSpawn.bounds.max.y);

            Instantiate(objectToSpawn, pos, Quaternion.identity);

            yield return new WaitForSeconds(spawnRate);
        }
    }
}
