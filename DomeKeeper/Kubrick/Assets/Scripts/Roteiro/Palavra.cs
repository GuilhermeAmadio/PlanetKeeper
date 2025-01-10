using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Palavra : MonoBehaviour
{
    public string palavra;
    public char nextLetra;
    private int index = -1;

    public TextMeshProUGUI roteiroText;
    public RoteiroManager roteiroManager;

    private void Start()
    {
        NextLetra();
    }

    private void Update()
    {
        if (Input.GetKeyDown(nextLetra.ToString())) 
        {
            roteiroText.text += nextLetra;
            SoundManager.instance.Play("Writing", 9);
            NextLetra();
        }
        else if (Input.anyKeyDown)
        {
            roteiroManager.Erro();
        }
    }

    private void NextLetra()
    {
        index++;
        if (index == palavra.Length) 
        {
            roteiroManager.WriteWord();
            Destroy(gameObject);
        }
        else
        {
            nextLetra = palavra[index];
        }
    }
}
