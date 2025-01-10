using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class AimWeapon : MonoBehaviour
{
    public CharacterStat speed;

    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 aimDir = (Vector2)transform.position - mousePos;

        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg + 180f;

        //if (angle > 180)
        //{
        //    if (angle > 270)
        //    {
        //        angle = 0f;
        //    }
        //    else if (angle < 270)
        //    {
        //        angle = 180f;
        //    }
        //}

        Quaternion newRot = Quaternion.Euler(0f, 0f, angle);
        
        transform.rotation = Quaternion.Slerp(transform.rotation, newRot, Time.deltaTime * speed.GetCurrentStat());
    }
}
