using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFoguete : MonoBehaviour
{
    public int[] numbers;
    public Transform[] spawns;
    public Transform choosenSpawn;
    public int choosenNumber;
    public int maxNumber;
    public GameObject papel;
    public bool flip;

    private void Awake()
    {
        int num = Random.Range(0, maxNumber);
        choosenNumber = numbers[num];
        choosenSpawn = spawns[num];
        GameObject papelObj = Instantiate(papel, choosenSpawn.position, Quaternion.identity);
        papelObj.transform.SetParent(this.transform);

        if (flip)
            papelObj.GetComponent<Transform>().localScale = new Vector3(GetComponent<Transform>().localScale.x * -1, GetComponent<Transform>().localScale.y, GetComponent<Transform>().localScale.z);
        else
        {
            papelObj.GetComponent<Transform>().localScale = new Vector3(GetComponent<Transform>().localScale.x, GetComponent<Transform>().localScale.y, GetComponent<Transform>().localScale.z);
        }
    }
}
