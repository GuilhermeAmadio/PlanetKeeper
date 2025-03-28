using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class AimWeapon : MonoBehaviour
{
    public CharacterStat speed;

    [SerializeField] private float offset;

    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 aimDir = (Vector2)transform.position - mousePos;

        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg + 180f + offset;

        Quaternion newRot = Quaternion.Euler(0f, 0f, angle);
        
        transform.rotation = Quaternion.Slerp(transform.rotation, newRot, Time.deltaTime * speed.GetCurrentValue());
    }
}
