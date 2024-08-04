using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ПРОВЕРЩИК
public class Day5MindsConditionTrigger : MonoBehaviour, IConditionHandler
{

    public int StartConditionHandle()
    {

        if (!GameManager.Instance.GetSomeThingsListValue("DeclineNeforsThree"))
        {
            return 0; // - ЕСЛИ Вова

        }
        else if (GameManager.Instance.GetSomeThingsListValue("CHANGE-THIS"))
        {
            return 1; // - ЕСЛИ Нефоры
        }
        else
        {
            Debug.Log("Ошибка в вычислениях проверки");
            return -1;
        }

    }
}