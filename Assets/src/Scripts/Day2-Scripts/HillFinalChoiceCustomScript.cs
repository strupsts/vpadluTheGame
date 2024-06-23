using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HillFinalChoiceCustomScript : MonoBehaviour, ICustomTrigger
{
  
    void ICustomTrigger.Trigger()
    {
        Quiz.setQuizPoints("Veterans", 1);
        Quiz.setQuizPoints("VladimirHillQuiz", 1);
    }

   
}
