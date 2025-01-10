using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ator1Manager : MonoBehaviour
{
    public int rightValor;
    public string rightSotaque;
    public float rightAltura;

    public Vector2[] posAtores;
    public float[] velAtores;
    public Transform atorPos;
    public List<Ator> atoresPrefab = new List<Ator>();
    public List<int> indexAtores = new List<int>();
    public List<Ator> atoresSpawned = new List<Ator>();
    public GameObject win, lose;
    private bool winned, losed;
    public TMPro.TextMeshProUGUI valor, sotaque, altura;

    private void Awake()
    {
        if (PlayerPrefs.GetString("Ator11") == "true")
        {
            //remover atoresprefab[0]
            valor.text = "Valor: 15K";
            sotaque.text = "Sotaque: Norte";
            altura.text = "Altura: 1.8M";

            rightValor = 15;
            rightSotaque = "Norte";
            rightAltura = 1.8f;
        }
    }

    private void OnEnable()
    {
        NextAtores();
    }

    public void NextAtores()
    {
        indexAtores.Clear();
        if (atoresSpawned != null)
        {
            for (int i = atoresSpawned.Count-1; i > -1; i--)
            {
                atoresSpawned[i].GoAway();
                atoresSpawned.RemoveAt(i);
            }
        }

        for (int i = 0; i < 3; i++)
        {
            bool spawned = false;

            while (!spawned)
            {
                int n = Random.Range(0, atoresPrefab.Count);

                if (!indexAtores.Contains(n))
                {
                    GameObject ator = Instantiate(atoresPrefab[n].gameObject);
                    ator.transform.localPosition = atorPos.position;
                    ator.GetComponent<Ator>().pos = posAtores[i];
                    ator.GetComponent<Ator>().atorManager = this;
                    ator.GetComponent<Ator>().vel = velAtores[i];
                    ator.transform.SetParent(atorPos);
                    atoresSpawned.Add(ator.GetComponent<Ator>());
                    indexAtores.Add(n);

                    spawned = true;
                }
                else
                {
                    spawned = false;
                }
            }
        }
    }

    public void CheckAnswer(int valor, string sotaque, float altura)
    {
        if (valor == rightValor && sotaque == rightSotaque && altura == rightAltura && !winned && !losed)
        {
            win.SetActive(true);
            winned = true;
            if (PlayerPrefs.GetString("Ator11") != "true")
            {
                PlayerPrefs.SetString("Ator11", "true");
            }
            else
            {
                PlayerPrefs.SetString("Ator12", "true");
            }
        } 
        else if (!losed && !winned)
        {
            lose.SetActive(true);
            losed = true;
        }
    }
}
