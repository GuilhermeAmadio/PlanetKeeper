using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFragments : MonoBehaviour
{
    [SerializeField] private GameObject fragment;
    [SerializeField] private float fragmentForce;

    public void Spawn()
    {
        if (ApplyFragments.instance.CheckFragments())
        {
            float amount = ApplyFragments.instance.GetFragmentsAmount();

            for (int i = 0; i < amount; i++)
            {
                Debug.Log(i);
                GameObject frag = Instantiate(fragment, transform.position, Quaternion.identity);

                Vector2 randomDir = new Vector2(Random.Range(0, 359), Random.Range(0, 359));

                frag.GetComponent<Rigidbody2D>().velocity = randomDir.normalized * fragmentForce;
            }
        }
    }
}
