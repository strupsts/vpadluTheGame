using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NunchakiConditionScript : MonoBehaviour, ICustomTrigger
{
    public void Start()
    {
        Debug.Log($"�������?? {GameManager.Instance.GetSomeThingsListValue("Nunchaki")}");
    }
    public void Trigger()
    {
        Debug.Log("������� ����� ������� �������");
        GameManager.Instance.SetSomeThingsListValue("Nunchaki", true);
        GameManager.Instance.notifyItemHandler(true,"�������");
        Debug.Log(GameManager.Instance.GetSomeThingsListValue("Nunchaki"));
    }

    
}
