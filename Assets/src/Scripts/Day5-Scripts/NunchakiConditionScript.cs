using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NunchakiConditionScript : MonoBehaviour, ICustomTrigger
{
    public void Start()
    {
        Debug.Log($"Нунчаки?? {GameManager.Instance.GetSomeThingsListValue("Nunchaki")}");
    }
    public void Trigger()
    {
        Debug.Log("Получен новый предмет Нунчаки");
        GameManager.Instance.SetSomeThingsListValue("Nunchaki", true);
        GameManager.Instance.notifyItemHandler(true,"Нунчаки");
        Debug.Log(GameManager.Instance.GetSomeThingsListValue("Nunchaki"));
    }

    
}
