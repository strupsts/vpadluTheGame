using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ÓÑÒÀÍÎÂÙÈÊ
public class LieToEfimChoiceCustomScript : MonoBehaviour, ICustomTrigger
{
    
   void ICustomTrigger.Trigger()
    {
        GameManager.Instance.SetSomeThingsListValue("LieToEfim", true); // ÓÑÒÀÍÀÂËÈÂÀÅÌ ÇÍÀ×ÅÍÈÅ
    }

   
}
