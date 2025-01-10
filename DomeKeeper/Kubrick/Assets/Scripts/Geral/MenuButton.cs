using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MenuButton : MonoBehaviour
{
    public GameObject video, all;
    public VideoPlayer player;

    private void Start()
    {
        Cursor.visible = true;
    }

    public void LoadScene(string scene)
    {
        if (PlayerPrefs.GetString("CutsceneInicial") != "true") 
        {
            PlayerPrefs.SetString("CutsceneInicial", "true");
            Cursor.visible = false;
            all.SetActive(false);
            video.SetActive(true);
            FindObjectOfType<SoundManager>().Play("Botão", 1);
            StartCoroutine(StartGame(scene));
        }
        else
        {
            SceneManager.LoadScene(scene);
        }
    }

    private IEnumerator StartGame(string scene)
    {
        yield return new WaitForSeconds((float)player.length);
        SceneManager.LoadScene(scene);
    }

    public void ExitGame()
    {
        FindObjectOfType<SoundManager>().Play("Botão", 1);
        Application.Quit();
    }

    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
    }
}
