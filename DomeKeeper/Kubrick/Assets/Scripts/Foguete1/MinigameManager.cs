using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    public Foguete1Manager foguete1Manager;

    public IEnumerator NextMinigame()
    {
        yield return new WaitForSeconds(1f);

        foguete1Manager.NextMinigame();
        Destroy(this.gameObject);
    }
}
