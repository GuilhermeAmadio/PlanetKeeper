using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fio : MonoBehaviour
{
    private Vector2 startPoint;
    public SpriteRenderer fioEnd;

    private void Start()
    {
        startPoint = transform.position;
        GetComponent<LineRenderer>().renderingLayerMask = 5;
        GetComponent<LineRenderer>().SetPosition(0, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        GetComponent<LineRenderer>().SetPosition(1, startPoint);
    }

    private void OnMouseDrag()
    {
        Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPos.z = 10f;

        transform.position = newPos;

        float dist = Vector2.Distance(startPoint, newPos);
        fioEnd.transform.localScale = new Vector2(dist*10, fioEnd.transform.localScale.y);
    }
}
