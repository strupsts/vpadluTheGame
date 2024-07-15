using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kolyaWinOrLoseConditionTrigger : MonoBehaviour, IConditionHandler
{

    public int StartConditionHandle()
    {
        if (GameManager.Instance.GetSomeThingsListValue("Tobacco"))
        {
            GameManager.Instance.SetSomeThingsListValue("Chocolate", true);
            return 0;
        }
        else if (!GameManager.Instance.GetSomeThingsListValue("Tobacco"))
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
