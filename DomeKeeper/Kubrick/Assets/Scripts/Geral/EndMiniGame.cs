using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMiniGame : MonoBehaviour
{
    public bool win;

    private void OnEnable()
    {
        if (win && FindObjectOfType<SoundManager>() != null)
        {
            FindObjectOfType<SoundManager>().Play("Acerto", 1);
        }
    }

    public void Back()
    {
        FindObjectOfType<SoundManager>().Play("Botão", 1);
        Time.timeScale = 1f;
        LevelChanger.instance.FadeToLevel("Lobby");
        //SceneManager.LoadScene("Lobby");
    }

    public void Retry()
    {
        FindObjectOfType<SoundManager>().Play("Botão", 1);
        Time.timeScale = 1f;
        LevelChanger.instance.FadeToLevel(SceneManager.GetActiveScene().name);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
