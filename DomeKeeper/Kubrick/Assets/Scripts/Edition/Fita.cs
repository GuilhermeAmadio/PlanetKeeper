using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fita : MonoBehaviour
{
    public Vector2 pos;
    public float velocidade;
    public float limite;
    public Sprite[] sprites;

    private void Awake()
    {
        GetComponent<Image>().sprite = sprites[Random.Range(0, sprites.Length)];
    }

    void Update()
    {
        transform.Translate(Vector3.right * velocidade * Time.deltaTime);

        if (transform.localPosition.x > limite)
        {
            transform.localPosition = new Vector3(-limite, transform.localPosition.y, transform.localPosition.z);
        }
    }

    public void ChangePos()
    {
        transform.localPosition = pos;
        transform.localRotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        this.enabled = false;
    }
}
