using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    [SerializeField] private float pointValue;

    [SerializeField] private FloatStatsSO pointIncrease;

    [SerializeField] private TransformSO playerTransform;

    [SerializeField] private GoToTarget goToTarget;
    [SerializeField] private GoToTargetOnTime targetOnTime;

    private bool take;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Mouse") && !take)
        {
            if (playerTransform.GetTransform() != null)
            {
                targetOnTime.CalculateSpeed(transform, playerTransform.GetTransform());
                goToTarget.ChaseTransform(playerTransform.GetTransform());
            }

            take = true;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            MoneyManager.instance.IncreaseMoney(pointValue + pointIncrease.GetCurrentValue());

            Destroy(gameObject);
        }
    }
}
