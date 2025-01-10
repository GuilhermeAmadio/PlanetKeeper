using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogueteMovement : MonoBehaviour
{
    public float speed, xMin, xMax;
    public GameObject desacoplada;

    private void OnEnable()
    {
        desacoplada.SetActive(false);
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("FogueteHorizontal");

        var movement = new Vector3(moveHorizontal, 0.0f);
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = movement * speed;

        rigidbody.transform.localPosition = new Vector2
         (
           Mathf.Clamp(rigidbody.transform.localPosition.x, xMin, xMax),
           rigidbody.transform.localPosition.y
         );
    }
}
