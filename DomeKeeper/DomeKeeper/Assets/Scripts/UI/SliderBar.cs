using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SliderBar : MonoBehaviour
{
    public FloatStatsSO statsValue;

    public Image bar;

    public DelegateFuncionSO onValueChanged;

    private void Start()
    {
        bar.fillAmount = statsValue.GetInitialValue() / statsValue.GetMaxValue();
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
