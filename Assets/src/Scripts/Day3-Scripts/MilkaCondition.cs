using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkaCheckCondition : MonoBehaviour, IConditionHandler
{
    
   public int StartConditionHandle()
    {
        if (GameManager.Instance.GetSomeThingsListValue("Tobacco"))
        {
            return 0;
        }
        else if (!GameManager.Instance.GetSomeThingsListValue("Tobacco"))
        {
            return 1;
        }

        else {
            Debug.Log("������ � ����������� ��������");
            return -1; 
        }
    
    }
}
