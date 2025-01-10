using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase3Foguete : MonoBehaviour
{
    public float force;
    public Rigidbody rb;
    public Animator desacoplada;
    public Foguete2Manager manager;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0))
        {
            FindObjectOfType<SoundManager>().Play("Acerto", 1);
            SoundManager.instance.Stop("Foguete1");
            rb.useGravity = true;
            rb.AddForce(Vector2.right * force, ForceMode.Impulse);
            rb.AddForce(Vector2.down * force, ForceMode.Impulse);
            desacoplada.SetTrigger("Desacoplado");
            manager.NextFase();
            this.enabled = false;
        }
    }
}
