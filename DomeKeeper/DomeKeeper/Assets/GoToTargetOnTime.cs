using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToTargetOnTime : MonoBehaviour
{
    [SerializeField] private float time;

    [SerializeField] private GoToTarget goToTarget;

    public void CalculateSpeed(Transform initialPos, Transform target)
    {
        float distance = Vector2.Distance(initialPos.position, target.position);
        float speed = distance / time;

        goToTarget.ChangeSpeed(speed);
    }
}
