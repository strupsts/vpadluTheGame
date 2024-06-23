using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizCheckCondition : MonoBehaviour, IConditionHandler
{
    
   public int StartConditionHandle()
    {
        if (Quiz.getQuizPoints("PickupBattleQuiz") < 7)
        {
            return 0;
        }
        else if (Quiz.getQuizPoints("PickupBattleQuiz") >= 7)
        {
            return 1;
        }
        else {
            Debug.Log("Ошибка в вычислениях проверки");
            return -1; 
        }
    
    }
}
