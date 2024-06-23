using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeThingItemScript : MonoBehaviour, IConditionHandler
{
    public string thingItem;

    public int StartConditionHandle()
    {
        GameManager.Instance.SetSomeThingsListValue(thingItem, true);
        Debug.Log($"{thingItem} теперь {GameManager.Instance.GetSomeThingsListValue(thingItem)}");

        return 0;
    }


}
