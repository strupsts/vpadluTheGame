using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WorstEndSceneChange : MonoBehaviour, IConditionHandler
{

    public int BadEnd;


    public int StartConditionHandle()
    {
        SaveManager.SaveGame();

        return endingExamination();

    }


    int endingExamination()
    {
        int companyReputation = GameManager.Instance.GetReputationListValue("Company");
        Debug.Log($"Отношения с компанией имеют {companyReputation} баллов");

        if (companyReputation == 25)
        {
            SceneManager.LoadScene(BadEnd);
            return 0;

        }

        else if (companyReputation == 0)
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


