using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPoints : MonoBehaviour
{
    [SerializeField] private GameObject point;

    public void Drop()
    {
        Instantiate(point, transform.position, Quaternion.identity);
    }
}
