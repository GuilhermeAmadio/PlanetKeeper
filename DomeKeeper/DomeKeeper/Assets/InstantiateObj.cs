using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObj : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    [SerializeField] private Vector2 minRandomPos, maxRandomPos;

    public GameObject InstantiateObject()
    {
        Vector3 randomPos = new Vector3(Random.Range(minRandomPos.x, maxRandomPos.x), Random.Range(minRandomPos.y, maxRandomPos.y), 1f);
        GameObject newObj = Instantiate(obj, transform.position + randomPos, Quaternion.identity, transform);

        return newObj;
    }

    public void InstantiateObjectInPos(Transform pos)
    {
        Vector3 randomPos = new Vector3(Random.Range(minRandomPos.x, maxRandomPos.x), Random.Range(minRandomPos.y, maxRandomPos.y), 1f);
        Instantiate(obj, pos.position + randomPos, Quaternion.identity, transform);
    }

    public void JustInstantiate()
    {
        Vector3 randomPos = new Vector3(Random.Range(minRandomPos.x, maxRandomPos.x), Random.Range(minRandomPos.y, maxRandomPos.y), 1f);
        Instantiate(obj, transform.position + randomPos, Quaternion.identity);
    }
}
