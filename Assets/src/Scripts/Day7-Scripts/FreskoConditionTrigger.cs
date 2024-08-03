using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FreskoConditionTrigger : MonoBehaviour, IConditionHandler
{

    public int StartConditionHandle()
    {
        Debug.Log($"������� �� �� ������ ���� �����?? (true = ��������� �������) {GameManager.Instance.GetSomeThingsListValue("FreskoCorrect")}");

        if (GameManager.Instance.GetSomeThingsListValue("FreskoCorrect"))
        {
            return 0;

        }
        else if (!GameManager.Instance.GetSomeThingsListValue("FreskoCorrect"))
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