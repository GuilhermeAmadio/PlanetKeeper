using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    public GameObject objectives;
    public GameObject[] cams; 
    public PlayerMovement player;
    public Cinemachine.CinemachineBrain cameraBrain;
    public Vector3 playerPos;
    public TMPro.TextMeshProUGUI dialogue;
    public AtorOutline outline;

    public Dialogue[] kubricksDialogues;

    private void OnEnable()
    {
        outline.enabled = false;
    }

    public void PlayDialogue()
    {
        for (int index = 0; index < kubricksDialogues.Length; index++)
        {
            if (PlayerPrefs.GetString("Kubrick" + index) != "true")
            {
                KubrickDialogue(index);
                PlayerPrefs.SetString("Kubrick" + index, "true");
                break;
            }
        }
    }

    private void KubrickDialogue(int index)
    {
        //if ((index == 10 && PlayerPrefs.GetString("AtorDemitido") != "true") || (index == 8 && PlayerPrefs.GetString("Telefone") == "true"))
        //{
        //    EndMinigame();
        //}
        //else
        //{
        //    if (!kubricksDialogues[index].dontPlay)
        //    {
        //        StartCoroutine(KubrickTalking(index));
        //    }
        //    else
        //    {
        //        EndMinigame();
        //    }
        //}

        StartCoroutine(KubrickTalking(index));

        dialogue.gameObject.SetActive(true);
        player.enabled = false;
        objectives.SetActive(false);
        player.transform.position = playerPos;
        player.transform.rotation = Quaternion.Euler(0, 180, 0);
        player.GetComponent<SaveData>().Save(player.transform.localPosition.x, player.transform.localPosition.y, player.transform.localPosition.z,
            player.transform.eulerAngles.x, player.transform.eulerAngles.y, player.transform.eulerAngles.z);
    }

    private IEnumerator KubrickTalking(int index)
    {
        for (int i = 0; i < kubricksDialogues[index].dialogue.Length; i++)
        {
            FindObjectOfType<SoundManager>().Play(kubricksDialogues[index].audio[i], 0);
            cameraBrain.m_DefaultBlend.m_Time = kubricksDialogues[index].camTimer[i];
            dialogue.text = kubricksDialogues[index].dialogue[i];

            if (kubricksDialogues[index].cam[i] == "Player")
            {
                ActivateCam(0);
            }
            else if (kubricksDialogues[index].cam[i] == "Kubrick")
            {
                ActivateCam(1);
            }
            else if (kubricksDialogues[index].cam[i] == "Fim")
            {
                EndMinigame();
            }

            yield return new WaitForSeconds(kubricksDialogues[index].timer[i]);
        }
    }

    private void ActivateCam(int cam)
    {
        for (int i = 0; i < cams.Length; i++)
        {
            if (i == cam)
            {
                if (!cams[i].activeSelf) 
                {
                    cams[i].SetActive(true);
                }
            }
            else
            {
                if (cams[i].activeSelf)
                {
                    cams[i].SetActive(false);
                }
            }
        }
    }

    private void EndMinigame()
    {
        for (int i = 0; i < cams.Length; i++)
        {
            cams[i].SetActive(false);
        }
        this.enabled = false;
    }

    private void OnDisable()
    {
        if (player != null) 
            player.enabled = true;

        if (objectives != null)
            objectives.SetActive(true);
    }
}
