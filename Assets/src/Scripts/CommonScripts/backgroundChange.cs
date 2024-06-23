using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundChange : MonoBehaviour, IConditionHandler
{
    public Image backgroundImage; // ������ �� ��������� Image
    public Sprite newBackgroundImage; // ����� ������ ��� ����

    private float animationDuration = 1; // ����������������� �������� � ��������

    private Color startColor = Color.white; // �������� ���� ����
    private Color targetColor = Color.black; // ����, � ������� �� ����� ��������� ���

    public bool willCloseDialogue;
    public int timerOnDialogueClose;
    public GameObject DialogueBox;

    // Audio
    public AudioClip newBackgroundSound;
   

    public int StartConditionHandle()
    {
        setEnvironmentMusic();
        if (this.newBackgroundImage) StartCoroutine(ChangeBackground());
        if (willCloseDialogue) StartCoroutine(TimerDialogueBoxHandler());
   
        return 0;
    }

    private IEnumerator TimerDialogueBoxHandler()
    {
        this.DialogueBox.SetActive(false);
        float timer = 0f;

        while (timer < timerOnDialogueClose)
        {
            timer += Time.deltaTime;
            
            yield return null;
        }
        this.DialogueBox.SetActive(true);

    }

    // �������� ��� �������� ����� ����
    private IEnumerator ChangeBackground()
    {
        float timer = 0f;

        while (timer < animationDuration)
        {
            // ���������� ����
            backgroundImage.color = Color.Lerp(startColor, targetColor, timer / animationDuration);

            timer += Time.deltaTime;
            yield return null;
        }

        // ����� �����������
        backgroundImage.sprite = newBackgroundImage;

        timer = 0f;
        while (timer < animationDuration)
        {
            // ���������� ����
            backgroundImage.color = Color.Lerp(targetColor, startColor, timer / animationDuration);

            timer += Time.deltaTime;
            yield return null;
        }
    }
    
    private void setEnvironmentMusic()
    {
      
        if (this.newBackgroundSound)
        { 
            GameObject.Find("DialogueManager").GetComponent<DialogueManager>().setEnvironmentMusic(this.newBackgroundSound);
        }
        
    }
}