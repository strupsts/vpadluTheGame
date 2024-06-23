using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class ChoiceTrigger: MonoBehaviour
{
    [SerializeField]
    public ChoiceParams ChoiceInfo;

   
    public void TriggerChoice()   // ¬ходна€ точка дл€ начала скрипта (вызывает последний отработанный скрипт в конце)
    {
        FindObjectOfType<ChoiceManager>().StartChoice(ChoiceInfo, this);
    }


}
