using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderCameras : MonoBehaviour
{
    public Camera[] cameras;

    private void Update()
    {
        foreach (Camera cam in cameras)
        {
            cam.Render();
        }
    }
}
