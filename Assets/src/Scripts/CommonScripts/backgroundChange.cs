using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundChange : MonoBehaviour, IConditionHandler
{
    public Image backgroundImage; // Ссылка на компонент Image
    public Sprite newBackgroundImage; // Новый спрайт для фона

    private float animationDuration = 1; // Продолжительность анимации в секундах

    private Color startColor = Color.white; // Исходный цвет фона
    private Color targetColor = Color.black; // Цвет, в который мы хотим затемнить фон

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

    // Корутина для анимации смены фона
    private IEnumerator ChangeBackground()
    {
        float timer = 0f;

        while (timer < animationDuration)
        {
            // Затемнение фона
            backgroundImage.color = Color.Lerp(startColor, targetColor, timer / animationDuration);

            timer += Time.deltaTime;
            yield return null;
        }

        // Смена изображения
        backgroundImage.sprite = newBackgroundImage;

        timer = 0f;
        while (timer < animationDuration)
        {
            // Осветление фона
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