using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BogdanAdviceConditionTrigger : MonoBehaviour, IConditionHandler
{
    
   public int StartConditionHandle()
    {
        GameManager.Instance.SetSomeThingsListValue("BogdanAdvice", true);   
        return 0;
    }
}
