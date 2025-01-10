using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOverTime : MonoBehaviour
{
    public float rotateSpeed;

    private void Start()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 359f));
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, Time.deltaTime * rotateSpeed));
    }
}
