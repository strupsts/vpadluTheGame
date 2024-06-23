using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class StartDialogueTrigger : MonoBehaviour
{
    public Dialogue[] dialogues; // Массив диалогов

    [SerializeField]
    public GameObject nextTrigger;

    private int currentDialogueIndex = 0; // Индекс текущего диалога

    [HideInInspector]
    public bool dialogueIsEnded = false;

    public void TriggerDialogue()
    {
        if (currentDialogueIndex < dialogues.Length)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogues[currentDialogueIndex], this);
            currentDialogueIndex++; // Переход к следующему диалогу

        }
        else
        {
            currentDialogueIndex = 0;
            dialogueIsEnded = true;
            ActivateNextTrigger();
        }
    }

   
    public void ActivateNextTrigger() // Если предложений не осталось = диалог закончен => активируется триггер следующего указанного в Inspector скрипта.
    {
        GameManager.Instance.ActivateNextTrigger(this.nextTrigger);
    }

 
}