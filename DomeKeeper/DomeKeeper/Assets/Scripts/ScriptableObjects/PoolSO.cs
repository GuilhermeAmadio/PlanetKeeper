using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pool", menuName = "Objects/New Pool")]
public class PoolSO : ScriptableObject
{
    public string tag;
    public GameObject prefab;
    public int size;
}
