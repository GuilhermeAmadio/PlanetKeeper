using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer : MonoBehaviour
{
    public static BasePlayer instance;

    [SerializeField] private TransformSO playerTransform;

    private void Awake()
    {
        instance = this;

        playerTransform.SetTransform(transform);
    }

    public Transform GetPlayerTransform()
    {
        return transform;
    }
}
