using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OzonChoiceCustomScript : MonoBehaviour, ICustomTrigger
{
  
    void ICustomTrigger.Trigger()
    {
        GameManager.Instance.SetSomeThingsListValue("OzonPressure", true);
    }

   
}
