using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���������
public class Day5MindsConditionTrigger : MonoBehaviour, IConditionHandler
{

    public int StartConditionHandle()
    {

        bool vovaChoosen = GameManager.Instance.GetSomeThingsListValue("DeclineNeforsThree");

        if (!vovaChoosen)
        {
            return 0; // - ���� ����

        }
        else if (vovaChoosen)
        {
            return 1; // - ���� ������
        }
        else
        {
            Debug.Log("������ � ����������� ��������");
            return -1;
        }

    }
}