using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ПРОВЕРЩИК
public class WasGermanConditionTrigger : MonoBehaviour, IConditionHandler
{

    public int StartConditionHandle()
    {
        bool wasGerman = GameManager.Instance.GetSomeThingsListValue("DeclineNeforsOne");

        if (!wasGerman)
        {
            return 0; // - ЕСЛИ ДА

        }
       
        else if (wasGerman)
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