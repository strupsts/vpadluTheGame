using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionTrigger : MonoBehaviour
{
  
    public IConditionHandler conditionHandler;
    public GameObject[] resultOfCondition;

    private void Start()
    {
        this.conditionHandler = GetComponent<IConditionHandler>();
    }
    public void TriggerCondition()
    {
        if (this.conditionHandler != null)
        {
            int indexNextTrigger = this.conditionHandler.StartConditionHandle();
            GameManager.Instance.ActivateNextTrigger(this.resultOfCondition[indexNextTrigger]);
        }
        else Debug.LogWarning("[Condition Trigger]: Отсутствует исполнительный скрипт (Condition Handler)");
    }
}


