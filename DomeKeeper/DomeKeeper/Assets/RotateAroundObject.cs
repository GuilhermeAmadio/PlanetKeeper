using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundObject : MonoBehaviour
{
    [SerializeField] private FloatStatsSO rotateSpeed;

    [SerializeField] private Transform objectToRotateAround;

    private bool rotate = true;

    private void Update()
    {
        if (rotate)
        {
            transform.RotateAround(objectToRotateAround.position, Vector3.forward, rotateSpeed.GetCurrentValue() * Time.deltaTime);
        }
    }
}
