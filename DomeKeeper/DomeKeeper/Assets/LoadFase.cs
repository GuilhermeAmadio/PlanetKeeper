using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadFase : MonoBehaviour
{
    [SerializeField] private string level;

    public void Load()
    {
        SceneManager.LoadScene(level);
    }
}
