using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ПРОВЕРЩИК
public class LieOrNoCheckConditionTrigger : MonoBehaviour, IConditionHandler
{

    public int StartConditionHandle()
    {
        bool lieToEfim = GameManager.Instance.GetSomeThingsListValue("LieToEfim");
        
        if (lieToEfim)
        {
            return 0; // - ЕСЛИ ДА

        }
        else if (!lieToEfim)
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