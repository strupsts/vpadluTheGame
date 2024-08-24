using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HillFinalChoiceCustomScript : MonoBehaviour, ICustomTrigger
{
  
    void ICustomTrigger.Trigger()
    {
        
        int vetPoints = 1;
        Quiz.setQuizPoints("Veterans", vetPoints);

        int hillPoints = 1;
        Quiz.setQuizPoints("VladimirHillQuiz", hillPoints);
    }

   
}
