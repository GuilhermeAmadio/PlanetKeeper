using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Alavanca : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    public AlavancaManager alavancaManager;

    private void Awake()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    }

    public void DragHandler(BaseEventData data)
    {
        if (alavancaManager.win == false)
        {
            PointerEventData pointerData = (PointerEventData)data;

            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)canvas.transform, pointerData.position, canvas.worldCamera, out position);

            transform.position = new Vector3(transform.position.x, canvas.transform.TransformPoint(position).y, transform.position.z);
            if (transform.position.y > 8f)
            {
                transform.position = new Vector3(transform.position.x, 8f, transform.position.z);
            }

            if (transform.position.y < -8f)
            {
                transform.position = new Vector3(transform.position.x, -8f, transform.position.z);
            }
        }
    }

    public void DragEnd()
    {
        alavancaManager.CheckWin();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Alavanca"))
        {
            SoundManager.instance.Play("Lever", 4);
        }
    }
}
