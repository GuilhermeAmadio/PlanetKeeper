using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineMinigame : MonoBehaviour
{
    public Material[] originalMaterial;
    public Material outlineMaterial;
    private Material[] tempMaterials;

    private MeshRenderer meshMaterial;
    public OutlineMinigame otherOutline;

    private void Awake()
    {
        meshMaterial = GetComponent<MeshRenderer>();

        originalMaterial = meshMaterial.materials;
        tempMaterials = new Material[meshMaterial.materials.Length];
    }

    private void OnEnable()
    {
        for (int i = 0; i < tempMaterials.Length; i++)
        {
            tempMaterials[i] = outlineMaterial;
        }

        meshMaterial.materials = tempMaterials;


        if (otherOutline != null)
        {
            otherOutline.enabled = true;
        }
    }

    private void OnDisable()
    {
        meshMaterial.materials = originalMaterial;

        if (otherOutline != null)
        {
            otherOutline.enabled = false;
        }
    }
}
