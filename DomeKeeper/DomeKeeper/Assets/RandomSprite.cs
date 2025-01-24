using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class RandomSprite : MonoBehaviour
{
    [SerializeField] private SpriteLibrary spriteLibrary;
    [SerializeField] private SpriteLibraryAsset[] spriteAssets;

    private void Start()
    {
        spriteLibrary.spriteLibraryAsset = spriteAssets[Random.Range(0, spriteAssets.Length)];
    }
}
