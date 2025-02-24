using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;

    [SerializeField] private FloatSO rockStat, circuitStat, matterStat;

    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private UpdateText diffRock, diffCircuit, diffMatter;

    private float startRock, startCircuit, startMatter;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        startRock = rockStat.GetValue();
        startCircuit = circuitStat.GetValue();
        startMatter = matterStat.GetValue();
    }

    public void IncreaseMoney(MoneyType moneyType, float amount)
    {
        if (moneyType == MoneyType.ROCK)
        {
            rockStat.IncreaseValue(amount);
        }
        else if (moneyType == MoneyType.CIRCUIT)
        {
            circuitStat.IncreaseValue(amount);
        }
        else if (moneyType == MoneyType.MATTER)
        {
            matterStat.IncreaseValue(amount);
        }
    }

    public void CalculateDiffRock()
    {
        if (diffRock == null)
        {
            return;
        }

        float diff = rockStat.GetValue() - startRock;

        diffRock.UpdateMiddleText(diff.ToString());
    }

    public void CalculateDiffCircuit()
    {
        if (diffCircuit == null)
        {
            return;
        }

        float diff = circuitStat.GetValue() - startCircuit;

        diffCircuit.UpdateMiddleText(diff.ToString());
    }

    public void CalculateDiffMatter()
    {
        if (diffMatter == null)
        {
            return;
        }

        float diff = matterStat.GetValue() - startMatter;

        diffMatter.UpdateMiddleText(diff.ToString());
    }
}

public enum MoneyType
{
    ROCK,
    CIRCUIT,
    MATTER
}
