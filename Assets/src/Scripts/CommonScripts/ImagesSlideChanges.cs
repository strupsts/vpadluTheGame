using System;
using System.Collections;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ImagesSlideChanges: MonoBehaviour, IConditionHandler
{
    public bool willShadowWithChange;

    public UnityEngine.UI.Image backgroundImage; // Ссылка на компонент Image
    

    public Sprite[] arrayNewBGImages;

    public Sprite newImage;
    public bool endMusicOnEnd;


    private float animationDuration = 1.0f; // Продолжительность анимации в секундах

    
    private Color startColor = Color.white; // Исходный цвет фона
    private Color targetColor = Color.black; // Цвет, в который мы хотим затемнить фон


    public float timerBeforeNextSlide;
    public GameObject DialogueBox;

    // Audio
    public AudioClip newBackgroundSound;


    public int StartConditionHandle()
    {
        if(newImage)
        {
            arrayNewBGImages = arrayNewBGImages.Concat(new[] { newImage }).ToArray();
        }
        else
        {
            arrayNewBGImages = arrayNewBGImages.Concat(new[] { backgroundImage.sprite }).ToArray();
        }

        setEnvironmentMusic();
        this.DialogueBox.SetActive(false);
        StartCoroutine(TimerDialogueBoxHandler());

        
        return 0;
    }

    private IEnumerator TimerDialogueBoxHandler()
    {
        int imgIndex = 0;

        while (imgIndex < arrayNewBGImages.Length)
        {

            if (willShadowWithChange) StartCoroutine(ShadowChangeBackground(imgIndex));
            else StartCoroutine(changeBackground(imgIndex));
            
            imgIndex++;

            yield return new WaitForSeconds(timerBeforeNextSlide);
        }
   
        this.DialogueBox.SetActive(true);
        if (endMusicOnEnd)
        {
            
            GameObject.Find("DialogueManager").GetComponent<DialogueManager>().softTurnOffEnvironmentMusic();
        }

    }

    // Корутина для анимации смены фона
    private IEnumerator ShadowChangeBackground(int imgIndex)
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
     
        backgroundImage.sprite = arrayNewBGImages[imgIndex];

        timer = 0f;
        while (timer < animationDuration)
        {
            // Осветление фона
            backgroundImage.color = Color.Lerp(targetColor, startColor, timer / animationDuration);

            timer += Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator changeBackground(int imgIndex)
    {
        backgroundImage.sprite = arrayNewBGImages[imgIndex];
        yield return null;
    }


    private void setEnvironmentMusic()
    {

        if (this.newBackgroundSound)
        {
            GameObject.Find("DialogueManager").GetComponent<DialogueManager>().setEnvironmentMusic(this.newBackgroundSound);
        }

    }

   
}