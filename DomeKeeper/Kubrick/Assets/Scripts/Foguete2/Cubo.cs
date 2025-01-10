using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubo : MonoBehaviour
{
    public float fallSpeed = 1.0f;
    public float jumpForce = 2.0f;
    public float minY, maxY;

    void Update()
    {
        if (transform.localPosition.y > minY)
        {
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0))
        {
            Jump();
        }
    }

    void Jump()
    {
        if (transform.localPosition.y < maxY)
        {
            transform.Translate(Vector3.up * jumpForce, Space.World);
        }
    }
}
