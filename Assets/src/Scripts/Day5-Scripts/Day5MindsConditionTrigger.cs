using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���������
public class Day5MindsConditionTrigger : MonoBehaviour, IConditionHandler
{

    public int StartConditionHandle()
    {

        if (!GameManager.Instance.GetSomeThingsListValue("DeclineNeforsThree"))
        {
            return 0; // - ���� ����

        }
        else if (GameManager.Instance.GetSomeThingsListValue("CHANGE-THIS"))
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