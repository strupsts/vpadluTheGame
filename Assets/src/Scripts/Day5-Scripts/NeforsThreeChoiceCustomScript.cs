using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeforsThreeChoiceCustomScript : MonoBehaviour, ICustomTrigger
{
    
    void ICustomTrigger.Trigger()
    {
        GameManager.Instance.SetReputationListValue("Company", -25);
        GameManager.Instance.SetSomeThingsListValue("DeclineNeforsThree", true);
    }

   
}
