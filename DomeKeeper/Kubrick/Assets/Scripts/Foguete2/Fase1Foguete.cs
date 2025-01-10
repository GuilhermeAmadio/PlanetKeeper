using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase1Foguete : MonoBehaviour
{
    public float timer, timerToPress;
    public TMPro.TextMeshProUGUI timerText;

    private bool pressed, canPress, losed;
    public Animator desacoplada;
    public GameObject lose, smoke;
    public Foguete2Manager manager;

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)) && canPress) 
        {
            FindObjectOfType<SoundManager>().Play("Acerto", 1);
            SoundManager.instance.Play("Foguete", 1);
            manager.NextFase();
            pressed = true;
            canPress = false;
            smoke.SetActive(true);
            desacoplada.SetTrigger("Voando");
            gameObject.SetActive(false);
        }
        else if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)) && !canPress)
        {
            losed = true;
            lose.SetActive(true);
        }

        if (timer > 0 && !losed)
        {
            timer -= Time.deltaTime;
            timerText.text = Mathf.RoundToInt(timer).ToString();

            if (timer <= 0.6f)
            {
                canPress = true;
            }
        }
        else if (timer <= 0 && !losed)
        {
            if (timerToPress > 0 && !pressed)
            {
                timerToPress -= Time.deltaTime;
            }
            else if (timerToPress <= 0 && !pressed)
            {
                canPress = false;
                lose.SetActive(true);
            }
        }
    }
}
