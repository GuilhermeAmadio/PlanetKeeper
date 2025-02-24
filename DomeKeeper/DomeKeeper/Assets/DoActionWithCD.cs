using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoActionWithCD : MonoBehaviour
{
    [SerializeField] private UnityEvent action;

    [SerializeField] private CharacterStat cdStat;

    private bool canDoAction = true, doingAction;

    private void Update()
    {
        if (doingAction)
        {
            DoAction();
        }
    }

    public void DoAction()
    {
        if (canDoAction)
        {
            StartCoroutine(DoActionCD());
        }
    }

    public void DoActionAlways()
    {
        InvokeRepeating("DoAction", 0f, cdStat.GetCurrentStat());
    }

    private IEnumerator DoActionCD()
    {
        canDoAction = false;
        action.Invoke();

        yield return new WaitForSeconds(cdStat.GetCurrentStat());

        canDoAction = true;
    }

    public void DoingAction(bool doing)
    {
        doingAction = doing;
    }
}
