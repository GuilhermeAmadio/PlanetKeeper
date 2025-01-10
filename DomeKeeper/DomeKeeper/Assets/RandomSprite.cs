using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSprite : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;

    [SerializeField] private SpriteRenderer sr;

    private void Start()
    {
        ChooseRandomSprite();
    }

    public void ChooseRandomSprite()
    {
        sr.sprite = sprites[Random.Range(0, sprites.Length)];
    }
}
