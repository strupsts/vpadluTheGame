using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���������
public class Day4MindsConditionTrigger : MonoBehaviour, IConditionHandler
{

    public int StartConditionHandle()
    {

        if (!GameManager.Instance.GetSomeThingsListValue("DeclineNeforsTwo"))
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