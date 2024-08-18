using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WarningConditionTrigger : MonoBehaviour, IConditionHandler
{

    public Sprite WorstImage;
    public Sprite BadImage;
    public Sprite GoodImage;
    public Sprite BestImage;

    public int StartConditionHandle()
    {
        int companyReputation = GameManager.Instance.GetReputationListValue("Company");
        Debug.Log($"CompanyReputation `= {companyReputation}");

        if (companyReputation == 100)
        {
            GameManager.Instance.notifyItemHandler(false, "Похоже ты идешь правильной дорогой!", BestImage, true);
            return 0;
        }
        else if (companyReputation == 75 )
        {
            GameManager.Instance.notifyItemHandler(false, "Поднажми, если не хочешь  старых проблем.", GoodImage, true);
            return 0;
        }
        else if (companyReputation == 50 )
        {
            GameManager.Instance.notifyItemHandler(false, "Подумай-ка над своими решениями.", BadImage, true);
            return 0;
        }
        else if (companyReputation == 25)
        {
            GameManager.Instance.notifyItemHandler(false, "Где-то в жизни ты свернул не туда… -_-", WorstImage, true);
            return 0;
        }
        else
        {
            Debug.Log("Ошибка в вычислениях проверки WARNING CONDITION TRIGGER (WARNING NOTIFY)");
            return -1;
        }

    }
}
