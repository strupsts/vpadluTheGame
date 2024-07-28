using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NunchakiConditionTrigger : MonoBehaviour, IConditionHandler
{

    public int StartConditionHandle()
    {
        Debug.Log($"Нунчаки?? (false = они есть) {GameManager.Instance.GetSomeThingsListValue("DeclineNeforsThree")}");

        if (!GameManager.Instance.GetSomeThingsListValue("DeclineNeforsThree"))
        {
            return 0;

        }
        else if (GameManager.Instance.GetSomeThingsListValue("DeclineNeforsThree"))
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