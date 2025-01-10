using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ator2Minigame : MonoBehaviour
{
    public GameObject atorCam, playerCam, objectives;
    public PlayerMovement player;
    public Cinemachine.CinemachineBrain cameraBrain;
    public Vector3 playerPos;
    public TMPro.TextMeshProUGUI dialogue;
    public GameObject choices;
    public AtorOutline outline;

    private void OnEnable()
    {
        outline.enabled = false;
        dialogue.gameObject.SetActive(true);
        cameraBrain.m_DefaultBlend.m_Time = 0f;
        playerCam.SetActive(true);
        player.enabled = false;
        objectives.SetActive(false);
        player.transform.position = playerPos;
        player.transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    private void Start()
    {

        StartCoroutine(FalaInicial());
    }

    private IEnumerator FalaInicial()
    {
        yield return new WaitForSeconds(1.5f);
        dialogue.text = "Para criar, destrui-me.";
        FindObjectOfType<SoundManager>().Play("Ator1", 0);

        yield return new WaitForSeconds(2.8f);
        dialogue.text = "Tanto me exteriorizei dentro de mim, que dentro de mim nao existo senao exteriormente.";

        yield return new WaitForSeconds(5.7f);
        dialogue.text = "Sou a cena viva onde passam varios atores representando varias pecas.";

        yield return new WaitForSeconds(5f);
        choices.SetActive(true);
        playerCam.SetActive(false);
        atorCam.SetActive(true);
        dialogue.text = "";
    }

    private IEnumerator A()
    {
        choices.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        dialogue.text = "Para a consciencia-de-si independente, sua essencia e somente a pura abstracao do Eu.";
        FindObjectOfType<SoundManager>().Play("Consciencia1", 0);

        yield return new WaitForSeconds(4.3f);
        dialogue.text = "Mas quando essa abstracao se cultiva e se outorga diferencas,";
        FindObjectOfType<SoundManager>().Play("Consciencia2", 0);

        yield return new WaitForSeconds(3.5f);
        dialogue.text = "esse diferenciar nao se lhe torna essencia objetiva em-si-essente.";
        FindObjectOfType<SoundManager>().Play("Consciencia3", 0);

        yield return new WaitForSeconds(3f);
        dialogue.text = "";

        yield return new WaitForSeconds(1f);
        atorCam.SetActive(false);
        playerCam.SetActive(true);

        yield return new WaitForSeconds(1.5f);
        dialogue.text = "O eu e livre para fazer de sua vida o que quiser.";
        FindObjectOfType<SoundManager>().Play("Ator1.a", 0);

        yield return new WaitForSeconds(3f);
        dialogue.text = "Mas a liberdade nao esta em fazer o que se quer.";

        yield return new WaitForSeconds(3f);
        dialogue.text = "E sim em nunca ter de fazer o que nao se quer.";

        yield return new WaitForSeconds(2.5f);
        dialogue.text = "";

        yield return new WaitForSeconds(1f);
        atorCam.SetActive(true);
        playerCam.SetActive(false);

        yield return new WaitForSeconds(3f);
        atorCam.SetActive(false);
        playerCam.SetActive(true);

        yield return new WaitForSeconds(2f);
        atorCam.SetActive(true);
        playerCam.SetActive(false);

        yield return new WaitForSeconds(2f);
        atorCam.SetActive(false);
        playerCam.SetActive(true);

        yield return new WaitForSeconds(1f);
        dialogue.text = "Obrigado.";
        FindObjectOfType<SoundManager>().Play("Obrigado", 0);

        yield return new WaitForSeconds(1.5f);
        dialogue.text = "";

        yield return new WaitForSeconds(1.5f);
        playerCam.SetActive(false);
        PlayerPrefs.SetString("AtorDemitido", "true");
        FimMinigame();
    }

    private IEnumerator B()
    {
        choices.SetActive(false);
        yield return new WaitForSeconds(1f);
        dialogue.text = "Profundo.";
        FindObjectOfType<SoundManager>().Play("Profundo", 0);

        yield return new WaitForSeconds(1.5f);
        dialogue.text = "";
        atorCam.SetActive(false);
        playerCam.SetActive(true);

        yield return new WaitForSeconds(1f);
        dialogue.text = "Plastico demora quatrocentos anos para se decompor.";
        FindObjectOfType<SoundManager>().Play("Ator1.b", 0);

        yield return new WaitForSeconds(3.5f);
        dialogue.text = "Porem a humanidade ainda nao viveu quatrocentos anos desde sua criacao.";

        yield return new WaitForSeconds(4.2f);
        dialogue.text = "O primeiro plastico feito pelos humanos ainda esta por ai.";

        yield return new WaitForSeconds(3.5f);
        dialogue.text = "";

        yield return new WaitForSeconds(2f);
        atorCam.SetActive(true);
        playerCam.SetActive(false);

        yield return new WaitForSeconds(2f);
        atorCam.SetActive(false);
        playerCam.SetActive(true);

        yield return new WaitForSeconds(2f);
        dialogue.text = "O segundo tambem.";
        FindObjectOfType<SoundManager>().Play("OSegundo", 0);

        yield return new WaitForSeconds(2.5f);
        dialogue.text = "";

        yield return new WaitForSeconds(1.5f);
        playerCam.SetActive(false);
        PlayerPrefs.SetString("AtorDemitido", "true");
        FimMinigame();
    }

    private IEnumerator C()
    {
        choices.SetActive(false);
        yield return new WaitForSeconds(2f);
        dialogue.text = "...";

        yield return new WaitForSeconds(2f);
        dialogue.text = "";

        yield return new WaitForSeconds(1f);
        atorCam.SetActive(false);
        playerCam.SetActive(true);

        yield return new WaitForSeconds(1f);
        dialogue.text = "Voce esta certo.";
        FindObjectOfType<SoundManager>().Play("Ator1.c", 0);

        yield return new WaitForSeconds(1.5f);
        dialogue.text = "Preciso parar de fumar.";

        yield return new WaitForSeconds(1f);
        dialogue.text = "";

        yield return new WaitForSeconds(1f);
        playerCam.SetActive(false);
        PlayerPrefs.SetString("Ator12", "true");
        PlayerPrefs.SetString("Kubrick7", "true");
        FimMinigame();
    }

    private void FimMinigame()
    {
        PlayerPrefs.SetString("Ator2", "true");
        this.enabled = false;
    }

    private void OnDisable()
    {
        cameraBrain.m_DefaultBlend.m_Time = 0.4f;
        playerCam.SetActive(false);
        player.enabled = true;
        objectives.SetActive(true);
    }

    public void DialogueA()
    {
        StartCoroutine(A());
    }

    public void DialogueB()
    {
        StartCoroutine(B());
    }

    public void DialogueC()
    {
        StartCoroutine(C());
    }
}
