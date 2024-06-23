using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Quiz;

[System.Serializable]
public class ChoiceParams
{
    [SerializeField]
    public List<Choice> listOfChoices;


    public StartDialogueTrigger[] resultsOfChoice;

    public bool timer;
    public bool repeat;

}

[System.Serializable]
public class Choice
{
    [SerializeField]
    public string textOfChoice;
    public enum RoleOfChoiceScript
    {
        None, Reputation, Quiz, CustomScript
    }

    public enum ReputationDecreaseReason
    {
        Family,
        RuslanAndSanya,
        Bogdan,
        Company,
        Neformals
    }
    [SerializeField]
    public RoleOfChoiceScript ChoiceInfluenceScript;
    [SerializeField]
    public ReputationDecreaseReason nameOfCharacter;
    [SerializeField]
    public int countOfReputationPoints;
    [SerializeField]
    public GameObject customScript; 
    [SerializeField]
    public quizList quizNames;
    [SerializeField]
    public int countOfQuizPoints;


}

