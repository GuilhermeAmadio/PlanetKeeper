using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ator : MonoBehaviour
{
    public int valor;
    public string sotaque;
    public float altura;

    public float vel;
    public float y;

    public Vector2 pos, posAway;
    private bool inPos, goAway;
    public Ator1Manager atorManager;
    public Image col;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, y, transform.localPosition.z);
    }

    private void Update()
    {
        if (transform.localPosition.x > pos.x - 3f && transform.localPosition.x < pos.x + 3f && !inPos)
        {
            inPos = true;
            anim.SetTrigger("Idle");
            col.raycastTarget = true;
        }
        else if (!inPos)
        {
            transform.Translate(transform.right * vel, Space.World);
        }

        if (goAway)
        {
            transform.Translate(transform.right * vel, Space.World);

            if (transform.localPosition.x > posAway.x - 25f && transform.localPosition.x < posAway.x + 50f)
            {
                Destroy(gameObject);
            }
        }
    }

    public void MouseEnter()
    {
        anim.SetTrigger("Glow");
    }

    public void MouseExit()
    {
        anim.SetTrigger("Idle");
    }

    public void Check()
    {
        atorManager.CheckAnswer(valor, sotaque, altura);
    }

    public void GoAway()
    {
        goAway = true;
        col.raycastTarget = false;
        anim.SetTrigger("Walk");
        vel = 20f;
    }

    public void Step()
    {
        FindObjectOfType<SoundManager>().Play("PlayerStep", 5);
    }
}
