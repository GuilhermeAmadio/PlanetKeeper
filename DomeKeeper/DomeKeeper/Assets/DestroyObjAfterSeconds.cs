using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjAfterSeconds : DestroyObj
{
    [SerializeField] private float seconds;

    private void Start()
    {
        Invoke("DestroyThis", seconds);
    }
}
