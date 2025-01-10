using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroide : MonoBehaviour
{
    public float fallSpeed = 5.0f;
    public float rotateSpeed;
    public Rigidbody rb;

    private void Start()
    {
        transform.localRotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        rotateSpeed = Random.Range(0.1f, 1f);
        fallSpeed = Random.Range(fallSpeed - 20f, fallSpeed + 20f);
        rb.velocity = Vector2.down * fallSpeed;
    }

    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed);

        if (transform.localPosition.y < -1300f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<Fase4Foguete>().Lose();
            Destroy(gameObject);
            //colocar particula
        }
    }
}
