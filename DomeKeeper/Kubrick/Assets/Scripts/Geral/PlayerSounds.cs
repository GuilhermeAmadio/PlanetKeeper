using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    private void Step()
    {
        SoundManager.instance.Play("PlayerStep", 5);
    }
}
