using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SliderBar : MonoBehaviour
{
    public StatSO statsValue;

    public Image bar;

    public DelegateFuncionSO onValueChanged;

    private void Start()
    {
        UpdateHealth();
    }

    public void UpdateHealth()
    {
        bar.fillAmount = statsValue.GetCurrentValue() / statsValue.GetMaxValue();
    }

    private void OnEnable()
    {
        onValueChanged.onFuncionCalled += UpdateHealth;
    }

    private void OnDisable()
    {
        onValueChanged.onFuncionCalled -= UpdateHealth;
    }
}
