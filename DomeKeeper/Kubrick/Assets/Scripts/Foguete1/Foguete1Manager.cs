using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foguete1Manager : MonoBehaviour
{
    public Transform canvas;
    public GameObject win, lose;
    public TMPro.TextMeshProUGUI descriText, timerText, countdownText;
    public GameObject[] minigames;
    public string[] descri;
    private int lastMinigame;
    public int minigamesDone, minigamesMax;
    private bool spawned, go;
    public float timer, timerMax;

    private void Start()
    {
        StartCoroutine(Countdown());
        timer = timerMax;
    }

    private void Update()
    {
        if (timer > 0 && !win.activeSelf && go)
        {
            timer -= Time.deltaTime;
            timerText.text = Mathf.RoundToInt(timer).ToString();
        }
        else if (timer <= 0 && !lose.activeSelf && go)
        {
            lose.SetActive(true);
        }
    }

    public void NextMinigame()
    {
        minigamesDone++;

        if (minigamesDone >= minigamesMax)
        {
            win.SetActive(true);
            PlayerPrefs.SetString("Foguete1", "true");
        }
        else
        {
            StartCoroutine(SpawnMinigame());
        }
    }

    private IEnumerator SpawnMinigame()
    {
        spawned = false;
        while (!spawned)
        {
            int chooseMinigame = Random.Range(0, minigames.Length);
            if (chooseMinigame != lastMinigame)
            {
                GameObject minigame = minigames[chooseMinigame];

                descriText.text = descri[chooseMinigame];

                yield return new WaitForSeconds(0.5f);

                descriText.text = "";

                GameObject minigameObj = Instantiate(minigame, transform.position, Quaternion.identity);
                minigameObj.transform.SetParent(canvas);
                minigameObj.GetComponent<MinigameManager>().foguete1Manager = this;
                minigameObj.transform.localScale = new Vector3(1, 1, 1);
                lastMinigame = chooseMinigame;
                spawned = true;
            }
        }
    }

    private IEnumerator StartMinigame()
    {
        yield return new WaitForSeconds(1f);

        StartCoroutine(SpawnMinigame());
    }

    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(1f);
        countdownText.text = "Luz";
        FindObjectOfType<SoundManager>().Play("Luz", 0);

        yield return new WaitForSeconds(1f);
        countdownText.text = "Camera";
        FindObjectOfType<SoundManager>().Play("Camera", 0);

        yield return new WaitForSeconds(1f);
        countdownText.text = "Acao";
        FindObjectOfType<SoundManager>().Play("Ação", 0);
        go = true;
        StartCoroutine(StartMinigame());

        yield return new WaitForSeconds(0.5f);
        countdownText.gameObject.SetActive(false);
    }
}
