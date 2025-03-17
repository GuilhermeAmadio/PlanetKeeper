using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Point : MonoBehaviour
{
    [SerializeField] private float pointValue;
    [SerializeField] private MoneyType type;

    [SerializeField] private StatSO pointIncrease;
    [SerializeField] private Chance bonusChance;

    [SerializeField] private TransformSO playerTransform;

    [SerializeField] private GoToTarget goToTarget;
    [SerializeField] private GoToTargetOnTime targetOnTime;

    [SerializeField] private UnityEvent onPickUp;

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
            float bonusPoint = 0;

            if (bonusChance.CheckChance())
            {
                bonusPoint = pointIncrease.GetValue();
            }

            MoneyManager.instance.IncreaseMoney(type, pointValue + bonusPoint);

            onPickUp?.Invoke();

            Destroy(gameObject);
        }
    }
}
