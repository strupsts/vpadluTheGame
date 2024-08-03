using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ПРОВЕРЩИК
public class Day4MindsConditionTrigger : MonoBehaviour, IConditionHandler
{

    public int StartConditionHandle()
    {

        if (!GameManager.Instance.GetSomeThingsListValue("DeclineNeforsTwo"))
        {
            return 0; // - ЕСЛИ Коля

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