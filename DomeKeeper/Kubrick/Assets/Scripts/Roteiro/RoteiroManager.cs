using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoteiroManager : MonoBehaviour
{
    public Roteiro[] roteiros;

    public int maxErros;
    private int index = -1, indexRoteiro, erros;

    public GameObject palavraPrefab;
    public TMPro.TextMeshProUGUI roteiroText, palavraText;
    public GameObject win, lose;

    private bool winned;

    private void OnEnable()
    {
        WriteWord();
    }

    public void WriteWord()
    {
        StartCoroutine(Write());
    }

    private IEnumerator Write()
    {
        if (indexRoteiro < roteiros.Length)
        {
            bool canWrite = true;
            index++;
            palavraText.text = "";

            for (int i = 0; i < roteiros[indexRoteiro].indexPalavras.Length; i++)
            {
                if (index == roteiros[indexRoteiro].indexPalavras[i])
                {
                    GameObject palavraObj = Instantiate(palavraPrefab);
                    Palavra palavra = palavraObj.GetComponent<Palavra>();
                    palavra.roteiroManager = this;
                    palavra.roteiroText = roteiroText;
                    palavra.palavra = roteiros[indexRoteiro].palavras[index];
                    palavraText.text = roteiros[indexRoteiro].palavras[index];
                    canWrite = false;
                }
            }

            if (index == roteiros[indexRoteiro].palavras.Length)
            {
                index = -1;
                canWrite = false;
                StartCoroutine(NextRoteiro());
            }

            if (canWrite)
            {
                string palavra = roteiros[indexRoteiro].palavras[index];
                foreach (char c in palavra)
                {
                    yield return new WaitForSeconds(0.085f);
                    SoundManager.instance.Play("Writing", 9);
                    roteiroText.text += c;
                }

                WriteWord();
            }
        }
        else if (indexRoteiro >= roteiros.Length && !winned)
        {
            win.SetActive(true);
            PlayerPrefs.SetString("Roteiro", "true");
            winned = true;
        }
    }

    private IEnumerator NextRoteiro()
    {
        yield return new WaitForSeconds(2f);
        roteiroText.text = "";
        indexRoteiro++;
        WriteWord();
    }

    public void Erro()
    {
        erros++;

        if (erros > maxErros)
        {
            lose.SetActive(true);
            this.enabled = false;
        }
    }
} 
