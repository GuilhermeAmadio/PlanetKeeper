using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase4Foguete : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float spawnInterval = 1.5f;
    public float xMin, xMax, timer;

    private bool losed, winned;
    public GameObject lose;
    public FogueteMovement foguete;
    public Foguete2Manager manager;

    void Start()
    {
        foguete.enabled = true;
        InvokeRepeating("SpawnAsteroid", 0.5f, spawnInterval);
    }

    private void Update()
    {
        if (timer > 0 && !losed)
        {
            timer -= Time.deltaTime;
        }
        else if (timer <= 0 && !losed && !winned)
        {
            winned = true;
            manager.NextFase();
        }
    }

    void SpawnAsteroid()
    {
        if (!losed && !winned)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(xMin, xMax), 0f, transform.position.z);
            GameObject asteroide = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
            asteroide.transform.SetParent(this.transform);
            asteroide.transform.localPosition = spawnPosition;
        }
    }

    public void Lose()
    {
        if (!losed && !winned)
        {
            lose.SetActive(true);
            losed = true;
        }
    }
}
