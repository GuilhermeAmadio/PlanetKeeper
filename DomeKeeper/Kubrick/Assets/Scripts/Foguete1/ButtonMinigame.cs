using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMinigame : MonoBehaviour
{
    public bool on;
    private Animator anim;
    public Animator[] lampAnim;
    public ButtonsManager buttonManager;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Click()
    {
        if (!buttonManager.win)
        {
            if (on)
            {
                on = false;
                anim.SetBool("On", false);
            }
            else
            {
                on = true;
                anim.SetBool("On", true);
            }

            for (int i = 0; i < lampAnim.Length; i++)
            {
                lampAnim[i].SetBool("On", !lampAnim[i].GetBool("On"));
            }

            SoundManager.instance.Play("Interruptor", 1);

            buttonManager.CheckWin();
        }
    }
}
