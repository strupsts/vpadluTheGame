using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ПРОВЕРЩИК
public class CheckConditionTrigger : MonoBehaviour, IConditionHandler
{

    public int StartConditionHandle()
    {

        if (GameManager.Instance.GetSomeThingsListValue("CHANGE-THIS"))
        {
            return 0; // - ЕСЛИ ДА

        }
        else if (!GameManager.Instance.GetSomeThingsListValue("CHANGE-THIS"))
        {
            return 1; // - ЕСЛИ НЕТ
        }
        else
        {
            Debug.Log("Ошибка в вычислениях проверки");
            return -1;
        }

    }
}