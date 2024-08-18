using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WarningConditionTrigger : MonoBehaviour, IConditionHandler
{

    public Sprite WorstImage;
    public Sprite BadImage;
    public Sprite GoodImage;
    public Sprite BestImage;

    public int StartConditionHandle()
    {
        int companyReputation = GameManager.Instance.GetReputationListValue("Company");
        Debug.Log($"CompanyReputation `= {companyReputation}");

        if (companyReputation == 100)
        {
            GameManager.Instance.notifyItemHandler(false, "������ �� ����� ���������� �������!", BestImage, true);
            return 0;
        }
        else if (companyReputation == 75 )
        {
            GameManager.Instance.notifyItemHandler(false, "��������, ���� �� ������  ������ �������.", GoodImage, true);
            return 0;
        }
        else if (companyReputation == 50 )
        {
            GameManager.Instance.notifyItemHandler(false, "�������-�� ��� ������ ���������.", BadImage, true);
            return 0;
        }
        else if (companyReputation == 25)
        {
            GameManager.Instance.notifyItemHandler(false, "���-�� � ����� �� ������� �� ����� -_-", WorstImage, true);
            return 0;
        }
        else
        {
            Debug.Log("������ � ����������� �������� WARNING CONDITION TRIGGER (WARNING NOTIFY)");
            return -1;
        }

    }
}
