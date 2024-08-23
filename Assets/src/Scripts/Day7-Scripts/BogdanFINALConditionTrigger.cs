using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BogdanFINALConditionTrigger : MonoBehaviour, IConditionHandler
{

    public int StartConditionHandle()
    {
        Debug.Log($"Ответил ли на вопрос Жака верно?? (true = Правильно ответил) {GameManager.Instance.GetSomeThingsListValue("FreskoCorrect")}");

        int bogdanRep = GameManager.Instance.GetReputationListValue("Bogdan");
        if (bogdanRep > 30)
        {
            return 0;

        }
        else if (bogdanRep == 30)
        {
            return 1;
        }
        else if (bogdanRep < 30)
        {
            return 2;
        }

        else
        {
            Debug.Log("Ошибка в вычислениях проверки");
            return -1;
        }

    }
}