using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstCondition : MonoBehaviour, IConditionHandler
{
    
   public int StartConditionHandle()
    {
        if (Quiz.getQuizPoints("PickupBattleQuiz") < 10)
        {
            return 0;
        }
        else if (Quiz.getQuizPoints("PickupBattleQuiz") >= 10)
        {
            return 1;
        }
        else {
            Debug.Log("Ошибка в вычислениях проверки");
            return -1; 
        }
    
    }
}
