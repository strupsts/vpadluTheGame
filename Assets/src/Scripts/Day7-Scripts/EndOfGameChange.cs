using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndOfGameSceneChange : MonoBehaviour, IConditionHandler
{
  
    public int GoodEnd;
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

        if (companyReputation > 50 && companyReputation <= 100 )
        {

            SceneManager.LoadScene(GoodEnd);
            return 0;
        }

        else if (companyReputation == 50)
        {
            return 1; // Продолжение этой сцены -- средняя концовка
        }

        else if (companyReputation >= 0 && companyReputation < 50 )
        {
            SceneManager.LoadScene(BadEnd);
            return 0;
        }
        else
        {
            Debug.Log("Ошибка в вычислении КОНЦОВКИ! Проблема с репутацией!");
            return 0;
        }
    }

   
}
    
   
