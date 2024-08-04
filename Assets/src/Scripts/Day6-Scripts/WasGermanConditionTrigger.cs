using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���������
public class WasGermanConditionTrigger : MonoBehaviour, IConditionHandler
{

    public int StartConditionHandle()
    {
        bool wasGerman = GameManager.Instance.GetSomeThingsListValue("DeclineNeforsOne");

        if (!wasGerman)
        {
            return 0; // - ���� ��

        }
       
        else if (wasGerman)
        {
            return 1; // - ���� ��� 
        }
        else
        {
            Debug.Log("������ � ����������� ��������");
            return -1;
        }

    }
}