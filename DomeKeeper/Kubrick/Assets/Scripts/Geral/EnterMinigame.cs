using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterMinigame : MonoBehaviour
{
    public string minigame;
    public TMPro.TextMeshProUGUI titleText, descriText;
    public PlayerMovement player;
    public GameObject e;

    private void OnEnable()
    {
        player.enabled = false;
    }

    public void Show(string minigame, string title, string descri)
    {
        this.minigame = minigame;

        titleText.text = title;
        descriText.text = descri;
    }

    public void Trabalhar()
    {
        LevelChanger.instance.FadeToLevel(minigame);
        //SceneManager.LoadScene(minigame);
    }

    public void Fechar()
    {
        Cursor.visible = false;
        e.SetActive(true);
        player.enabled = true;
        gameObject.SetActive(false);
    }
}
