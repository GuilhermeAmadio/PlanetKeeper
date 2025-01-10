using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamMinigame : MonoBehaviour
{
    public GameObject cam, objectives, crossesObj;
    public Slider fovSlider;
    public PlayerMovement player;
    public Cinemachine.CinemachineVirtualCamera fovObj;
    public int[] fovs;
    public int fovNeeded;
    public GameObject[] flechas;
    public float[] rotations;
    public float rotationNeeded;
    public GameObject[] crosses;
    public OutlineMinigame[] outlines;

    private void Awake()
    {
        int intensity = Random.Range(0, fovs.Length);
        fovNeeded = fovs[intensity];
        flechas[intensity].SetActive(true);

        int rotation = Random.Range(0, rotations.Length);
        rotationNeeded = rotations[rotation];
        crosses[rotation].SetActive(true);
    }

    private void OnEnable()
    {
        fovSlider.gameObject.SetActive(true);
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
        fovObj.m_Lens.FieldOfView = fovSlider.value;
    }

    private void LeaveMinigame()
    {
        cam.SetActive(false);
        player.enabled = true;
        fovSlider.gameObject.SetActive(false);
        crossesObj.SetActive(false);

        if (transform.eulerAngles.y-180 >= rotationNeeded - 8 && transform.eulerAngles.y-180 <= rotationNeeded + 8 && fovSlider.value <= fovNeeded + 1f && fovSlider.value >= fovNeeded - 1f)
        {
            if (PlayerPrefs.GetString("Cam1") != "true")
            {
                PlayerPrefs.SetString("Cam1", "true");
            }
            else
            {
                if (PlayerPrefs.GetString("Cam2") != "true")
                {
                    PlayerPrefs.SetString("Cam2", "true");
                }
                else
                {
                    PlayerPrefs.SetString("Cam3", "true");
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
