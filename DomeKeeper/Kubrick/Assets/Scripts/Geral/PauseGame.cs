using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public static PauseGame Instance { get; private set; }

    public static bool gameIsPaused = false;
    public bool canotPause;

    public GameObject pauseMenuUI;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && canotPause == false)
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else if (!gameIsPaused)
            {
                Pause();
            }
        }

    }

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;

        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            Cursor.visible = false;
        }
    }

    void Pause()
    {
        Cursor.visible = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Menu()
    {
        FindObjectOfType<SoundManager>().Play("Botão", 1);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
