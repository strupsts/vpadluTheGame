using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BestEndSceneChange : MonoBehaviour, IConditionHandler
{

    public int GoodEnd;


    public int StartConditionHandle()
    {
        SaveManager.SaveGame();

        return endingExamination();

    }


    int endingExamination()
    {
        int companyReputation = GameManager.Instance.GetReputationListValue("Company");
        Debug.Log($"Отношения с компанией имеют {companyReputation} баллов");

        if (companyReputation == 75)
        {
            SceneManager.LoadScene(GoodEnd);
            return 0;

        }

        else if (companyReputation == 100)
        {
            return 1;
        }

        else
        {
            Debug.Log("Ошибка в вычислении КОНЦОВКИ! Проблема с репутацией!");
            return 0;
        }
    }


}
