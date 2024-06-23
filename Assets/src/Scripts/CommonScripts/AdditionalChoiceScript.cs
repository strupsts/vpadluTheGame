using System;
using System.Collections;
using System.Collections.Generic;

using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static AdditionalChoiceScript;
using static UnityEngine.GraphicsBuffer;


public class AdditionalChoiceScript : MonoBehaviour
{

    public enum RoleOfChoiceScript
    {
        None, Quiz, Reputation
    }

    public enum ReputationDecreaseReason
    {
        Family,
        RuslanAndSanya,
        Bogdan,
        Company,
        Neformals
    }

    [HideInInspector]
    public ReputationDecreaseReason selectedReason;
    [HideInInspector]
    public int countOfReputationPoints;

    public RoleOfChoiceScript ChoiceInfluenceScript;

    

 

}



