using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class ChoiceTrigger: MonoBehaviour
{
    [SerializeField]
    public ChoiceParams ChoiceInfo;

   
    public void TriggerChoice()   // ������� ����� ��� ������ ������� (�������� ��������� ������������ ������ � �����)
    {
        FindObjectOfType<ChoiceManager>().StartChoice(ChoiceInfo, this);
    }


}
