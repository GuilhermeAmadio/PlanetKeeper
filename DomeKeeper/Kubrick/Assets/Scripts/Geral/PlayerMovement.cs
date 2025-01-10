using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public Animator anim;
    public GameObject e, lightCam, camCam, objectives, objects;
    public EnterMinigame enterMinigame;
    public LightMinigame lightMinigame;
    public CamMinigame camMinigame;
    public Ator2Minigame ator2;
    public Papel papel;
    public DialogueSystem kubrickDialogue;

    public float speed, turnSmoothTime;
    private float turnSmoothVelocity;

    public string miniGameToGo, title, descri;

    private void Awake()
    {
        miniGameToGo = null;
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);

            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }

        if (Input.GetKeyDown(KeyCode.E) && miniGameToGo != null)
        {
            anim.SetBool("Run", false);

            if (miniGameToGo == "Light")
            {
                MinigameLight();
                return;
            }

            if (miniGameToGo == "Cam")
            {
                MinigameCam();
                return;
            }

            if (miniGameToGo == "Ator2")
            {
                MinigameAtor2();
                return;
            }

            if (miniGameToGo == "Objects")
            {
                PlayerPrefs.SetString("Objects", "true");
                FindObjectOfType<SoundManager>().Play("Acerto", 1);
                objectives.SetActive(false);
                objectives.SetActive(true);
                objects.SetActive(false);
                e.SetActive(false);
                return;
            }

            if (miniGameToGo == "Papel")
            {
                papel.TakePapel();
                e.SetActive(false);
                return;
            }

            if (miniGameToGo == "Final")
            {
                PlayerPrefs.DeleteAll();
                e.SetActive(false);
                SceneManager.LoadScene("CutsceneFinal");
                return;
            }

            if (miniGameToGo == "Kubrick")
            {
                kubrickDialogue.enabled = true;
                kubrickDialogue.PlayDialogue();
                e.SetActive(false);
                return;
            }

            GoToMiniGame(miniGameToGo, title, descri);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Foguete1"))
        {
            MiniGameColl("Foguete1", "Conserto do Foguete", "Faca o que e pedido!");
        }

        if (other.gameObject.CompareTag("Foguete2"))
        {
            MiniGameColl("Foguete2", "Ida a Lua", "Faca o que e pedido!");
        }

        if (other.gameObject.CompareTag("Foguete3"))
        {
            MiniGameColl("Foguete3", "Arrumar Cenario", "Coloque as pecas no local correto!");
        }

        if (other.gameObject.CompareTag("Chroma"))
        {
            MiniGameColl("Chroma", "Ajustar Chroma Key", "Bata nas dobras!");
        }

        if (other.gameObject.CompareTag("Roteiro"))
        {
            MiniGameColl("Roteiro", "Escrever Roteiro", "Escreva a palavra indicada!");
        }

        if (other.gameObject.CompareTag("Edition"))
        {
            MiniGameColl("Edition", "Editar Filme", "Clique no momento certo!");
        }

        if (other.gameObject.CompareTag("Telefone"))
        {
            MiniGameColl("Telefone", "Telefonar", "Tecle o numero pedido!");
        }

        if (other.gameObject.CompareTag("Ator1"))
        {
            MiniGameColl("Ator1", "Escalar Ator", "Escolha o ator de acordo com as especificacoes!");
        }

        if (other.gameObject.CompareTag("Light"))
        {
            MiniGameColl("Light", "", "");
        }

        if (other.gameObject.CompareTag("Cam"))
        {
            MiniGameColl("Cam", "", "");
        }

        if (other.gameObject.CompareTag("Ator2"))
        {
            MiniGameColl("Ator2", "", "");
        }

        if (other.gameObject.CompareTag("Objects"))
        {
            MiniGameColl("Objects", "", "");
        }

        if (other.gameObject.CompareTag("Papel"))
        {
            papel = other.GetComponent<Papel>();
            MiniGameColl("Papel", "", "");
        }

        if (other.gameObject.CompareTag("Kubrick"))
        {
            MiniGameColl("Kubrick", "", "");
        }

        if (other.gameObject.CompareTag("Final"))
        {
            MiniGameColl("Final", "", "");
        }

        if (other.gameObject.GetComponent<OutlineMinigame>() != null)
        {
            other.gameObject.GetComponent<OutlineMinigame>().enabled = true;
        }
        else if (other.gameObject.GetComponent<AtorOutline>() != null)
        {
            other.gameObject.GetComponent<AtorOutline>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        miniGameToGo = null;
        e.SetActive(false);
        papel = null;
        if (other.gameObject.GetComponent<OutlineMinigame>() != null)
        {
            other.gameObject.GetComponent<OutlineMinigame>().enabled = false;
        }
        else if (other.gameObject.GetComponent<AtorOutline>() != null)
        {
            other.gameObject.GetComponent<AtorOutline>().enabled = false;
        }
    }

    private void GoToMiniGame(string minigame, string title, string descri)
    {
        Cursor.visible = true;
        enterMinigame.gameObject.SetActive(true);
        enterMinigame.Show(minigame, title, descri);
        e.SetActive(false);
    }

    private void MiniGameColl(string minigame, string title, string descri)
    {
        e.SetActive(true);
        miniGameToGo = minigame;
        this.title = title;
        this.descri = descri;
    }

    private void MinigameLight() 
    {
        objectives.SetActive(false);
        e.SetActive(false);
        lightCam.SetActive(true);
        lightMinigame.enabled = true;
        this.enabled = false;
    }

    private void MinigameCam()
    {
        objectives.SetActive(false);
        e.SetActive(false);
        camCam.SetActive(true);
        camMinigame.enabled = true;
        this.enabled = false;
    }

    private void MinigameAtor2()
    {
        objectives.SetActive(false);
        e.SetActive(false);
        ator2.enabled = true;
        this.enabled = false;
    }

    private void OnEnable()
    {
        Cursor.visible = false;
        miniGameToGo = null;
        e.SetActive(false);
    }

    private void OnDisable()
    {
        Cursor.visible = true;
    }
}
