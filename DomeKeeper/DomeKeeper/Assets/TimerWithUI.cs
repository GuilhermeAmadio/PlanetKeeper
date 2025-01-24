using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimerWithUI : MonoBehaviour
{
    [SerializeField] private float maxTimer;
    [SerializeField] private CharacterStat timerStat;
    [SerializeField] private UnityEvent onTimerEnd;

    private bool finished;

    private void Update()
    {
        if (timerStat.GetCurrentStat() < maxTimer)
        {
            timerStat.IncreaseStat(Time.deltaTime);
        }
        else
        {
            if (!finished)
            {
                onTimerEnd?.Invoke();

                finished = true;
            }
        }
    }
}
