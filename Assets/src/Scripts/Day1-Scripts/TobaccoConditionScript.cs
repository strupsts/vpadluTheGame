using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TobaccoConditionScript : MonoBehaviour, ICustomTrigger
{
    public void Start()
    {
        Debug.Log($"���������� �� �����?? {GameManager.Instance.GetSomeThingsListValue("Tobacco")}");
    }
    public void Trigger()
    {
        Debug.Log("����� ��������");
        GameManager.Instance.SetSomeThingsListValue("Tobacco", true);
        GameManager.Instance.notifyItemHandler(true,"��������");
        Debug.Log(GameManager.Instance.GetSomeThingsListValue("Tobacco"));
    }

    
}
