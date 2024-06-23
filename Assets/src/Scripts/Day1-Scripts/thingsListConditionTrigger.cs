using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thingsListConditionTrigger : MonoBehaviour, IConditionHandler
{
    public string thingItem;
    public void Start()
    {
        Debug.Log($"���������� �� {thingItem}?? {GameManager.Instance.GetSomeThingsListValue(thingItem)}");
    }
   
    public int StartConditionHandle()
    {
        if (GameManager.Instance.GetSomeThingsListValue(thingItem))
        {
            return 0;
        }
        else if (!GameManager.Instance.GetSomeThingsListValue(thingItem))
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
