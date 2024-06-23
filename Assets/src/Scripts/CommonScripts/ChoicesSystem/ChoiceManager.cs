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
    public GameObject ChoiceBox; // Ссылка на контейнер с кнопками выбора
    public GameObject DialogueBox;  // Ссылка на диалоговое окно

    public GameObject prefab;
    public GameObject ChoiceTimerBar;

    private ChoiceTrigger currentChoiceTrigger;

    

    CancellationTokenSource cts;
 


    private ChoiceParams currentChoice;

    [HideInInspector]
    public int timeForAnswer = 5000;


   
    

    public void StartChoice(ChoiceParams choiceInfo, ChoiceTrigger choiceTrigger)
    {
        this.currentChoiceTrigger = choiceTrigger; // Ссылка на триггер, с которого происходит вызов ChoiceManager'a
        cts = new CancellationTokenSource();
        currentChoice = choiceInfo;
        ChoiceBox.SetActive(true);  // Объект содержащий кнопки выбора появляется
        DialogueBox.SetActive(false);
        foreach (Choice choice in currentChoice.listOfChoices)
        {
            GameObject choiceButton = Instantiate(prefab);
            choiceButton.GetComponentInChildren<TextMeshProUGUI>().text = choice.textOfChoice;    
            choiceButton.transform.SetParent(ChoiceBox.transform);
            choiceButton.transform.localScale = new Vector2(1, 1);
            if(choiceButton.GetComponentInChildren<TextMeshProUGUI>().text != "На Орландо Блума?")
            {
                choiceButton.GetComponent<Button>().onClick.AddListener(() => // Вешаем слушатель на нажатие кнопки выбора
                {
                    EndChoice(currentChoice.listOfChoices.FindIndex(c => c == choice));  // Когда будет сделан выбор вызывается EndOfChoice() с индексом варианта ответа.
                });
            }
           
        }
        if (currentChoice.timer)
        {
            setupTimer();
        }
    }

    public void TriggerAdditionalChoiceScript(Choice.RoleOfChoiceScript additionalChoiceSystem, int choiceIndex)  // Обработчик той системы, которая была выбрана в определенном чойсе
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

                Debug.Log($"Репутация в {choosenChoiceInfo.nameOfCharacter.ToString()} теперь {GameManager.Instance.GetReputationListValue(choosenChoiceInfo.nameOfCharacter.ToString())}");
            }



    public async void setupTimer() // Включает ограничение по времени на ответ.
    {
        ChoiceTimerBar.SetActive(true);
        ChoiceTimerBar.GetComponent<ChoiceTimerIndicator>().startTimer(timeForAnswer / 1000);
        await Task.Delay(timeForAnswer, cts.Token);

        this.EndChoice(currentChoice.listOfChoices.Count - 1);
    }

    void DestroyAllChoiceButtons(Transform parent) // После выбора ответа игроком кнопки должны быть уничтожены со сцены.
    {
        // Создаем копию списка дочерних объектов, чтобы избежать ошибки изменения коллекции во время итерации
        Transform[] children = new Transform[parent.childCount];
        for (int i = 0; i < parent.childCount; i++)
        {
            children[i] = parent.GetChild(i);
        }

        // Уничтожаем каждого ребенка
        foreach (Transform child in children)
        {
            DestroyImmediate(child.gameObject);
        }
    }

    public void EndChoice(int choiceNumber)  // Выбор сделан игроком.
    {
        Choice choosenChoiceInfo = currentChoice.listOfChoices[choiceNumber];
        if (currentChoice.repeat)  // Если нужно зациклить. В основном для отладки.
        {
            currentChoice.resultsOfChoice[choiceNumber].dialogueIsEnded = false; 
        }
        
        if(choosenChoiceInfo.ChoiceInfluenceScript != Choice.RoleOfChoiceScript.None) // Если в выбранном чойсе указана дополнительная система
        {
            TriggerAdditionalChoiceScript(choosenChoiceInfo.ChoiceInfluenceScript, choiceNumber);
        }

        currentChoice.resultsOfChoice[choiceNumber].TriggerDialogue(); // Выходная точка чойса - диалог триггер.

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
