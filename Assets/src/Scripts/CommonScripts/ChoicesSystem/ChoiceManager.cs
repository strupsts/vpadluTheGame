    using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using System.Threading;
using Unity.VisualScripting;

public class ChoiceManager : MonoBehaviour
{
    public GameObject ChoiceBox; // ������ �� ��������� � �������� ������
    public GameObject DialogueBox;  // ������ �� ���������� ����

    public GameObject prefab;
    public GameObject ChoiceTimerBar;

    private ChoiceTrigger currentChoiceTrigger;

    

    CancellationTokenSource cts;
 


    private ChoiceParams currentChoice;

    [HideInInspector]
    public int timeForAnswer = 5000;


   
    

    public void StartChoice(ChoiceParams choiceInfo, ChoiceTrigger choiceTrigger)
    {
        this.currentChoiceTrigger = choiceTrigger; // ������ �� �������, � �������� ���������� ����� ChoiceManager'a
        cts = new CancellationTokenSource();
        currentChoice = choiceInfo;
        ChoiceBox.SetActive(true);  // ������ ���������� ������ ������ ����������
        DialogueBox.SetActive(false);
        foreach (Choice choice in currentChoice.listOfChoices)
        {
            GameObject choiceButton = Instantiate(prefab);
            choiceButton.GetComponentInChildren<TextMeshProUGUI>().text = choice.textOfChoice;    
            choiceButton.transform.SetParent(ChoiceBox.transform);
            choiceButton.transform.localScale = new Vector2(1, 1);
            if(choiceButton.GetComponentInChildren<TextMeshProUGUI>().text != "�� ������� �����?")
            {
                choiceButton.GetComponent<Button>().onClick.AddListener(() => // ������ ��������� �� ������� ������ ������
                {
                    EndChoice(currentChoice.listOfChoices.FindIndex(c => c == choice));  // ����� ����� ������ ����� ���������� EndOfChoice() � �������� �������� ������.
                });
            }
           
        }
        if (currentChoice.timer)
        {
            setupTimer();
        }
    }

    public void TriggerAdditionalChoiceScript(Choice.RoleOfChoiceScript additionalChoiceSystem, int choiceIndex)  // ���������� ��� �������, ������� ���� ������� � ������������ �����
    {
        switch (additionalChoiceSystem)
        {
            case Choice.RoleOfChoiceScript.Quiz:
                QuizHandler(choiceIndex);
                break;
            case Choice.RoleOfChoiceScript.Reputation:
                ReputationHandler(choiceIndex);
                break;
            case Choice.RoleOfChoiceScript.CustomScript:
                currentChoice.listOfChoices[choiceIndex].customScript.GetComponent<ICustomTrigger>().Trigger();     
                break;
        }
    }
             public void QuizHandler(int choiceIndex)
            {
                Choice choosenChoiceInfo = currentChoice.listOfChoices[choiceIndex];

                Quiz.setQuizPoints(choosenChoiceInfo.quizNames.ToString(), choosenChoiceInfo.countOfQuizPoints);

            }
            public void ReputationHandler(int choiceIndex)
            {
                Choice choosenChoiceInfo = currentChoice.listOfChoices[choiceIndex];
      
                GameManager.Instance.SetReputationListValue(choosenChoiceInfo.nameOfCharacter.ToString(), choosenChoiceInfo.countOfReputationPoints);

                Debug.Log($"��������� � {choosenChoiceInfo.nameOfCharacter.ToString()} ������ {GameManager.Instance.GetReputationListValue(choosenChoiceInfo.nameOfCharacter.ToString())}");
            }



    public async void setupTimer() // �������� ����������� �� ������� �� �����.
    {
        ChoiceTimerBar.SetActive(true);
        ChoiceTimerBar.GetComponent<ChoiceTimerIndicator>().startTimer(timeForAnswer / 1000);
        await Task.Delay(timeForAnswer, cts.Token);

        this.EndChoice(currentChoice.listOfChoices.Count - 1);
    }

    void DestroyAllChoiceButtons(Transform parent) // ����� ������ ������ ������� ������ ������ ���� ���������� �� �����.
    {
        // ������� ����� ������ �������� ��������, ����� �������� ������ ��������� ��������� �� ����� ��������
        Transform[] children = new Transform[parent.childCount];
        for (int i = 0; i < parent.childCount; i++)
        {
            children[i] = parent.GetChild(i);
        }

        // ���������� ������� �������
        foreach (Transform child in children)
        {
            DestroyImmediate(child.gameObject);
        }
    }

    public void EndChoice(int choiceNumber)  // ����� ������ �������.
    {
        Choice choosenChoiceInfo = currentChoice.listOfChoices[choiceNumber];
        if (currentChoice.repeat)  // ���� ����� ���������. � �������� ��� �������.
        {
            currentChoice.resultsOfChoice[choiceNumber].dialogueIsEnded = false; 
        }
        
        if(choosenChoiceInfo.ChoiceInfluenceScript != Choice.RoleOfChoiceScript.None) // ���� � ��������� ����� ������� �������������� �������
        {
            TriggerAdditionalChoiceScript(choosenChoiceInfo.ChoiceInfluenceScript, choiceNumber);
        }

        currentChoice.resultsOfChoice[choiceNumber].TriggerDialogue(); // �������� ����� ����� - ������ �������.

        this.DestroyAllChoiceButtons(ChoiceBox.transform);
        this.ChoiceBox.SetActive(false);
        DialogueBox.SetActive(true);

        if (currentChoice.timer) 
        {
            ChoiceTimerBar.SetActive(false);
            cts.Cancel();
        }; 
    }

}
