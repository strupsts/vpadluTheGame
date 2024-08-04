using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���������
public class LieOrNoCheckConditionTrigger : MonoBehaviour, IConditionHandler
{

    public int StartConditionHandle()
    {
        bool lieToEfim = GameManager.Instance.GetSomeThingsListValue("LieToEfim");
        
        if (lieToEfim)
        {
            return 0; // - ���� ��

        }
        else if (!lieToEfim)
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