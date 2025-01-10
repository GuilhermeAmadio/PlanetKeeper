using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtorOutline : MonoBehaviour
{
    public Material[] originalMaterial;
    public Material outlineMaterial;
    private Material[] tempMaterials;

    public SkinnedMeshRenderer meshMaterial;

    private void Awake()
    {
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
    }

    private void OnDisable()
    {
        meshMaterial.materials = originalMaterial;
    }
}
