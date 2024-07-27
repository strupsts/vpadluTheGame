using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OzonCheckConditionTrigger : MonoBehaviour, IConditionHandler
{

    public int StartConditionHandle()
    {
        bool ozonPressure = GameManager.Instance.GetSomeThingsListValue("OzonPressure");
        if (ozonPressure)
        {
            return 0;
        }
        else if (!ozonPressure)
        {

            return 1;
        }
        else
        {
            Debug.Log("Ошибка в вычислениях проверки");
            return -1;
        }

    }
}
