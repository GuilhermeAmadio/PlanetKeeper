using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Transform", menuName = "Components/New Transform")]
public class TransformSO : ScriptableObject
{
    [SerializeField] private Transform savedTransform;

    public void SetTransform(Transform newTransform)
    {
        savedTransform = newTransform;  
    }

    public Transform GetTransform()
    {
        return savedTransform;
    }
}
