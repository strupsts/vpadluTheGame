using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ÓÑÒÀÍÎÂÙÈÊ
public class SetupChoiceCustomScript : MonoBehaviour, ICustomTrigger
{
    
   void ICustomTrigger.Trigger()
    {
        GameManager.Instance.SetSomeThingsListValue("CHANGE-THIS", true); // ÓÑÒÀÍÀÂËÈÂÀÅÌ ÇÍÀ×ÅÍÈÅ
    }

   
}
