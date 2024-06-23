using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeforsTwoChoiceCustomScript : MonoBehaviour, ICustomTrigger
{
    
    void ICustomTrigger.Trigger()
    {
        GameManager.Instance.SetReputationListValue("Company", -25);
        GameManager.Instance.SetSomeThingsListValue("DeclineNeforsTwo", true);
    }

   
}
