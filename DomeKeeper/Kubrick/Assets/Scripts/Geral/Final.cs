using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Final : MonoBehaviour
{
    public VideoPlayer player;

    private void Start()
    {
        Cursor.visible = false;
        PlayerPrefs.DeleteAll();
        StartCoroutine(StartGame());
    }

    private IEnumerator StartGame()
    {
        yield return new WaitForSeconds((float)player.length);
        SceneManager.LoadScene("Menu");
    }
}
