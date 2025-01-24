using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICameraMovement : MonoBehaviour
{
    [SerializeField] private float zoomStep, minCamSize, maxCamSize;

    [SerializeField] private Vector2 minPos, maxPos;
    [SerializeField] private Camera cam;

    private Vector3 dragOrigin;

    private bool isMoving;

    private void Update()
    {
        PanCamera();
    }

    private void PanCamera()
    {
        if (isMoving)
        {
            Vector3 diff = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);

            cam.transform.position += diff;

            ClampCamera();
        }
    }

    public void StartMovement()
    {
        dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);   

        isMoving = true;
    }

    public void CancelMovement()
    {
        dragOrigin = Vector3.zero; 
        
        isMoving = false;
    }

    public void Zoom(float step)
    {
        if (step < 0)
        {
            step = -1;
        }
        else
        {
            step = 1;
        }

        float newSize = cam.orthographicSize - (zoomStep * step);

        cam.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);

        ClampCamera();
    }
    
    private void ClampCamera()
    {
        float newX = Mathf.Clamp(cam.transform.position.x, minPos.x, maxPos.x);
        float newY = Mathf.Clamp(cam.transform.position.y, minPos.y, maxPos.y);

        cam.transform.position = new Vector3(newX, newY, cam.transform.position.z);
    }
}
