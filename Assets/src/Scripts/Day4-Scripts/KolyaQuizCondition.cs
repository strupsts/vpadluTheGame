using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class KolyaQuizCondition : MonoBehaviour, IConditionHandler
{
 
    public Sprite AchievmentImageGood;
    public Sprite AchievmentImageBad;
   public int StartConditionHandle()
    {
        checkVeterans();
        return 0;
        
       

    }
     private void checkVeterans()
    {
        if (Quiz.getQuizPoints("MamaQuiz") < 3)
        {
            GameManager.Instance.notifyItemHandler(false, "Позор семьи", AchievmentImageBad);
        }
        else
        {
            GameManager.Instance.notifyItemHandler(false, "Мамина гордость", AchievmentImageGood);
        }
    }
    
}
