using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TobaccoConditionScript : MonoBehaviour, ICustomTrigger
{
    public void Start()
    {
        Debug.Log($"Существует ли табак?? {GameManager.Instance.GetSomeThingsListValue("Tobacco")}");
    }
    public void Trigger()
    {
        Debug.Log("Тобак добавлен");
        GameManager.Instance.SetSomeThingsListValue("Tobacco", true);
        GameManager.Instance.notifyItemHandler(true,"Сигареты");
        Debug.Log(GameManager.Instance.GetSomeThingsListValue("Tobacco"));
    }

    
}
