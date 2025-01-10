using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightMinigame : MonoBehaviour
{
    public GameObject cam, objectives, crossesObj;
    public Slider lightSlider;
    public PlayerMovement player;
    public Light lightObj;
    public int[] intensitys;
    public int intensityNeeded;
    public GameObject[] flechas;
    public float[] rotations;
    public float rotationNeeded;
    public GameObject[] crosses;
    public OutlineMinigame[] outlines;

    private void Awake()
    {
        int intensity = Random.Range(0, intensitys.Length);
        intensityNeeded = intensitys[intensity];
        flechas[intensity].SetActive(true);

        int rotation = Random.Range(0, rotations.Length);
        rotationNeeded = rotations[rotation];
        crosses[rotation].SetActive(true);

        if (PlayerPrefs.GetString("Edition1") == "true" && PlayerPrefs.GetString("Ator11") == "true" && PlayerPrefs.GetString("Light2") != "true")
        {
            PlayerPrefs.SetFloat("LightIntensity", 0f);
        }

        if (PlayerPrefs.GetString("Objects") == "true" && PlayerPrefs.GetString("Ator12") == "true" && PlayerPrefs.GetString("Light3") != "true")
        {
            PlayerPrefs.SetFloat("LightIntensity", 0f);
        }

        lightObj.intensity = PlayerPrefs.GetFloat("LightIntensity");
    }

    private void OnEnable()
    {
        lightSlider.gameObject.SetActive(true);
        crossesObj.SetActive(true);
    }

    void Update()
    {
        float movementX = Input.GetAxisRaw("Horizontal")/3;

        transform.Rotate(0, movementX, 0);

        if (Input.GetKeyDown(KeyCode.E))
        {
            LeaveMinigame();
        }
    }

    public void ChangeIntensity()
    {
        lightObj.intensity = lightSlider.value*1000;
        PlayerPrefs.SetFloat("LightIntensity", lightObj.intensity);
    }

    private void LeaveMinigame()
    {
        cam.SetActive(false);
        player.enabled = true;
        lightSlider.gameObject.SetActive(false);
        crossesObj.SetActive(false);

        if (transform.eulerAngles.y >= rotationNeeded - 3 && transform.eulerAngles.y <= rotationNeeded + 3 && lightSlider.value * 10 <= intensityNeeded + 0.3f)
        {
            if (PlayerPrefs.GetString("Light1") != "true")
            {
                PlayerPrefs.SetString("Light1", "true");
            }
            else
            {
                if (PlayerPrefs.GetString("Light2") != "true")
                {
                    PlayerPrefs.SetString("Light2", "true");
                }
                else
                {
                    PlayerPrefs.SetString("Light3", "true");
                }
            }
        }

        for (int i = 0; i < outlines.Length; i++)
        {
            outlines[i].enabled = false;
        }

        objectives.SetActive(true);
        this.enabled = false;
    }
}
