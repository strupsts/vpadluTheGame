using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class VladimirHillQuizCondition : MonoBehaviour, IConditionHandler
{
 
    public Sprite AchievmentImage;
   public int StartConditionHandle()
    {
        checkVeterans();
        if (Quiz.getQuizPoints("VladimirHillQuiz") < 3)
        {
            return 0;
        }
        else if (Quiz.getQuizPoints("VladimirHillQuiz") >= 3)
        {
            return 1;
        }
        else {
            Debug.Log("Ошибка в вычислениях проверки VladimirHillQuiz");
            return -1; 
        }
    
    }
     private void checkVeterans()
    {
        if (Quiz.getQuizPoints("Veterans") == 5)
        {
            GameManager.Instance.notifyItemHandler(false, "Гейоргиевский ветеран", AchievmentImage);
        }
    }
    
}
