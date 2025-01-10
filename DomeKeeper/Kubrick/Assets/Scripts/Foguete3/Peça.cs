using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Peça : MonoBehaviour
{
    public Canvas canvas;
    public string peça;

    public Transform connectedPiece;
    public Foguete3Manager foguete3;
    private bool col, canDrag = true;

    public void DragHandler(BaseEventData data)
    {
        if (canDrag)
        {
            PointerEventData pointerData = (PointerEventData)data;

            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)canvas.transform, pointerData.position, canvas.worldCamera, out position);

            transform.position = new Vector3(canvas.transform.TransformPoint(position).x, canvas.transform.TransformPoint(position).y, transform.position.z);
        }
    }

    public void DragEnd()
    {
        if (col && canDrag)
        {
            transform.localPosition = connectedPiece.transform.localPosition;
            transform.localScale *= 2;

            SoundManager.instance.Play("Peça", 1);

            canDrag = false;
            foguete3.Check();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(peça))
        {
            col = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(peça))
        {
            col = false;
        }
    }
}
