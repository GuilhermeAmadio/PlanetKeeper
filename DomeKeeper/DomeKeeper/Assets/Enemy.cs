using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private TransformSO playerTransform;

    [SerializeField] private GoToTarget goToTarget;
    [SerializeField] private GoToTargetOnTime targetOnTime;


    private void Start()
    {
        if (playerTransform.GetTransform() != null)
        {
            targetOnTime.CalculateSpeed(transform, playerTransform.GetTransform());
            ChaseTarget();
        }
    }

    public void ChaseTarget()
    {
        goToTarget.ChaseTransform(playerTransform.GetTransform());
    }
}
