using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BogdanFINALConditionTrigger : MonoBehaviour, IConditionHandler
{

    public int StartConditionHandle()
    {
        Debug.Log($"������� �� �� ������ ���� �����?? (true = ��������� �������) {GameManager.Instance.GetSomeThingsListValue("FreskoCorrect")}");

        int bogdanRep = GameManager.Instance.GetReputationListValue("Bogdan");
        if (bogdanRep > 30)
        {
            return 0;

        }
        else if (bogdanRep == 30)
        {
            return 1;
        }
        else if (bogdanRep < 30)
        {
            return 2;
        }

        else
        {
            Debug.Log("������ � ����������� ��������");
            return -1;
        }

    }
}