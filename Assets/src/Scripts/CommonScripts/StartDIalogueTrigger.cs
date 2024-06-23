using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class StartDialogueTrigger : MonoBehaviour
{
    public Dialogue[] dialogues; // ������ ��������

    [SerializeField]
    public GameObject nextTrigger;

    private int currentDialogueIndex = 0; // ������ �������� �������

    [HideInInspector]
    public bool dialogueIsEnded = false;

    public void TriggerDialogue()
    {
        if (currentDialogueIndex < dialogues.Length)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogues[currentDialogueIndex], this);
            currentDialogueIndex++; // ������� � ���������� �������

        }
        else
        {
            currentDialogueIndex = 0;
            dialogueIsEnded = true;
            ActivateNextTrigger();
        }
    }

   
    public void ActivateNextTrigger() // ���� ����������� �� �������� = ������ �������� => ������������ ������� ���������� ���������� � Inspector �������.
    {
        GameManager.Instance.ActivateNextTrigger(this.nextTrigger);
    }

 
}