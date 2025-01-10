using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seta : MonoBehaviour
{
    public float requiredTimeInArea = 10.0f;
    public float timeInArea = 0.0f;
    private bool playerInArea = false;

    public float vel, minY, maxY, yToGo;

    private bool losed, winned;
    public Cubo cubo;
    public GameObject lose;
    public Foguete2Manager manager;

    void Update()
    {
        if (transform.localPosition.y >= yToGo - 2f && transform.localPosition.y <= yToGo + 2f)
        {
            yToGo = Random.Range(minY, maxY);
        }

        if (yToGo > transform.localPosition.y)
        {
            transform.Translate(Vector3.up * vel * Time.deltaTime, Space.World);
        }
        else if (yToGo < transform.localPosition.y)
        {
            transform.Translate(Vector3.down * vel * Time.deltaTime, Space.World);
        }

        if (playerInArea)
        {
            timeInArea += Time.deltaTime;

            if (timeInArea >= requiredTimeInArea && !winned)
            {
                PlayerWins();
            }
        }

        if (timeInArea > 0 && !playerInArea)
        {
            timeInArea -= Time.deltaTime;
        }
        else if (timeInArea <= 0)
        {
            if (!losed)
            {
                losed = true;
                lose.SetActive(true);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInArea = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInArea = false;
        }
    }

    void PlayerWins()
    {
        FindObjectOfType<SoundManager>().Play("Acerto", 1);
        manager.NextFase();
        winned = true;
        cubo.enabled = false;
        this.enabled = false;
    }
}
