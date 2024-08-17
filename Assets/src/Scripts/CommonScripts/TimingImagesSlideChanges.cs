using System;
using System.Collections;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;



public class TimingImagesSlideChanges: MonoBehaviour, IConditionHandler
{
    public bool willShadow;

    public UnityEngine.UI.Image backgroundImage; // Ссылка на компонент Image

    public float timingOfFiniteSlide = 1.0f;


    public sliderElement[] arrayNewBGImages;

    public Sprite newImage;
    public bool endMusicOnEnd;   // Продолжительность анимации в секундах


    private float animationDuration = 1.0f;

    
    private Color startColor = Color.white; // Исходный цвет фона
    private Color targetColor = Color.black; // Цвет, в который мы хотим затемнить фон


    public GameObject DialogueBox;

    // Audio
    public AudioClip newBackgroundSound;


    public int StartConditionHandle()
    {
        if (newImage)
        {
            arrayNewBGImages = arrayNewBGImages.Concat(new [] { new sliderElement(newImage, timingOfFiniteSlide)  }).ToArray();
        }
        else
        {
            arrayNewBGImages = arrayNewBGImages.Concat(new[] { new sliderElement(backgroundImage.sprite, timingOfFiniteSlide) }).ToArray();
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
            /* if (imgIndex == arrayNewBGImages.Length - 1)
             {
                 ShadowChangeBackground(imgIndex);

                 imgIndex++;

                 yield return new WaitForSeconds(timingOfFiniteSlide);
             }*/

         

            if(willShadow)
            {
                StartCoroutine(ShadowChangeBackground(imgIndex));
            }

            else
            {
                StartCoroutine(ChangeBackground(imgIndex));
            }

           

            imgIndex++;

            yield return new WaitForSeconds(arrayNewBGImages[imgIndex - 1].sliderTiming);
              
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
     
        backgroundImage.sprite = arrayNewBGImages[imgIndex].sliderImage;


        timer = 0f;
        while (timer < animationDuration)
        {
            // Осветление фона
            backgroundImage.color = Color.Lerp(targetColor, startColor, timer / animationDuration);

            timer += Time.deltaTime;
            yield return null;
        }
    }

    // Без затемнения фона с каждой сменой слайдов
    private IEnumerator ChangeBackground(int imgIndex)
    {
      
        backgroundImage.sprite = arrayNewBGImages[imgIndex].sliderImage;
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