using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderCameras : MonoBehaviour
{
    public Camera cameraMain, cameraFlecha;

    private void Update()
    {
        cameraMain.Render();
        cameraFlecha.Render();  
    }
}
