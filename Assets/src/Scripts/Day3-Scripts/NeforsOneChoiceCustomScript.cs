using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeforsOneChoiceCustomScript : MonoBehaviour, ICustomTrigger
{
  
    void ICustomTrigger.Trigger()
    {
        GameManager.Instance.SetReputationListValue("Company", -25);
        GameManager.Instance.SetSomeThingsListValue("DeclineNeforsOne", true);
        
    }

   
}
