using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hasCucumbersConditionTrigger : MonoBehaviour, IConditionHandler
{

    public int StartConditionHandle()
    {
        bool cucumbersExist = GameManager.Instance.GetSomeThingsListValue("hasCucumbers");
        if (cucumbersExist)
        {
            GameManager.Instance.SetReputationListValue("Parents", 20);
            return 0;
        }
        else if (!cucumbersExist)
        {
            GameManager.Instance.SetReputationListValue("Parents", -20);
            return 1;
        }
        else
        {
            Debug.Log("Ошибка в вычислениях проверки");
            return -1;
        }

    }
}
