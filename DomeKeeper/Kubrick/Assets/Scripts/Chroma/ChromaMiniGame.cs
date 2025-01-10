using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChromaMiniGame : MonoBehaviour
{
    public Dobra[] dobras;
    public GameObject win, lose;
    public TMPro.TextMeshProUGUI dobrasText;
    public float spawnTimeMin, spawnTimeMax;
    public bool canSpawn = true, spawned;

    public int numDobras, maxDobras, dobrasToUnfold;

    //public List<GameObject> dobrasSpawned = new List<GameObject>();

    //private void Awake()
    //{
    //    for (int i = 0; i < spawns.Length; i++)
    //    {
    //        dobrasSpawned.Add(null);
    //    }
    //}

    //private void Start()
    //{
    //    StartCoroutine(SpawnDobra());
    //}

    //public IEnumerator SpawnDobra()
    //{
    //    while (canSpawn)
    //    {
    //        yield return new WaitForSeconds(Random.Range(spawnTimeMin, spawnTimeMax));

    //        if (numDobras < maxDobras)
    //        {
    //            spawned = false;

    //            while (!spawned)
    //            {
    //                int spawnPos = Random.Range(0, dobras.Length);
                    
    //                if (dobras[spawnPos].subir == false)
    //                {
    //                    //dobras[spawnPos].Subir();
    //                    //Transform pos = spawns[spawnPos];
    //                    //GameObject dobraObj = Instantiate(dobra, new Vector3(0, 0, 0), Quaternion.identity);
    //                    //dobraObj.transform.SetParent(GameObject.Find("Canvas").transform, false);
    //                    //dobraObj.transform.position = pos.position;
    //                    //dobraObj.GetComponent<Dobra>().chroma = this;

    //                    //dobrasSpawned[spawnPos] = dobraObj;
    //                    Dobras(1);

    //                    spawned = true;
    //                }

    //                //if (dobrasSpawned[spawnPos] == null)
    //                //{
    //                //}
    //            }
    //        }
    //    }
    //}

    //public void Dobras(int amount)
    //{
    //    numDobras += amount;

    //    if (numDobras >= maxDobras)
    //    {
    //        End();
    //        canSpawn = false;
    //        lose.SetActive(true);
    //    }
    //}

    public void Unfold()
    {
        dobrasToUnfold -= 1;
        //dobrasText.text = "Dobras: " + dobrasToUnfold;

        if (dobrasToUnfold == 0)
        {
            canSpawn = false;
            PlayerPrefs.SetString("Chroma", "true");
            win.SetActive(true);
            End();
        }
    }

    private void End()
    {
        //foreach (Dobra dobra in dobras)
        //{
        //    //if (dobra != null)
        //        //dobra.GetComponent<Dobra>().Descer();
        //}

        gameObject.SetActive(false);
    }
}
