using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kolyaWinOrLoseConditionTrigger : MonoBehaviour, IConditionHandler
{

    public int StartConditionHandle()
    {
        if (Quiz.getQuizPoints("MamaQuiz") < 5)
        {
            
            return 0;
        }
        else if (Quiz.getQuizPoints("MamaQuiz") == 5)
        {

            return 1;
        }
        else
        {
            Debug.Log("������ � ����������� ��������");
            return -1;
        }

    }
}
