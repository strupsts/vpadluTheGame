using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreskoChoiceCustomScript : MonoBehaviour, ICustomTrigger
{
    
   void ICustomTrigger.Trigger()
    {
        GameManager.Instance.SetSomeThingsListValue("FreskoCorrect", true);
    }

   
}
