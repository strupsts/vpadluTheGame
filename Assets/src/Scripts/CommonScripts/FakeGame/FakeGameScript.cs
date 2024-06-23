using System;
using System.Collections;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class FakeGameScript: MonoBehaviour, IConditionHandler
{
    public bool willShadowWithChange;

    public UnityEngine.UI.Image backgroundImage; // Ссылка на компонент Image

    public GameObject prefabStick;

    public GameObject prefabCars;

    public GameObject prefabDaninaTachka;

    private GameObject daninaTachka;


    public GameObject prefabStremo;

    private GameObject Stremo;

    public Sprite[] arrayNewBGImages;

    public Sprite newImage;
    public bool endMusicOnEnd;

    GameObject Cars;

    private Scrollbar PressProgressBar;

    private GameObject pressStickButton;

    private bool isGameEnded = false;

    public float animationDuration = 1.0f; // Продолжительность анимации в секундах

    
    private Color startColor = Color.white; // Исходный цвет фона
    private Color targetColor = Color.black; // Цвет, в который мы хотим затемнить фон


    public float timerBeforeNextSlide;
    public GameObject DialogueBox;

    // Audio
    public AudioClip newBackgroundSound;



    public int StartConditionHandle()
    {

        


        if (newImage)
        {
            arrayNewBGImages = arrayNewBGImages.Concat(new[] { newImage }).ToArray();
        }
        else
        {
            arrayNewBGImages = arrayNewBGImages.Concat(new[] { backgroundImage.sprite }).ToArray();
        }

        pressStickButton = Instantiate(prefabStick);
        
        pressStickButton.transform.SetParent(GameObject.Find("Canvas").transform);
        pressStickButton.transform.localScale = new Vector2(1, 1);
        pressStickButton.transform.position= new Vector2(1.1f, 0.7f);

        PressProgressBar = pressStickButton.transform.Find("rightStick").GetComponentInChildren<Scrollbar>(); // Ищем компонент Полоски которая заполняется по мере нажатия
        ProgressBarBehaviorHandler();
        StickButtonHandler();


        Cars = Instantiate(prefabCars);

        Cars.transform.SetParent(GameObject.Find("Canvas").transform);
        Cars.transform.localScale = new Vector2(5.025f , 1);
        Cars.transform.position = new Vector3(1,1,35);


        Stremo = Instantiate(prefabStremo);

        Stremo.transform.SetParent(GameObject.Find("Canvas").transform);
        Stremo.transform.localScale = new Vector2(50, 50);
        Stremo.transform.position = new Vector3(5, -1, 35);

        daninaTachka = Instantiate(prefabDaninaTachka);

        daninaTachka.transform.SetParent(GameObject.Find("Canvas").transform);
        daninaTachka.transform.localScale = new Vector2(100, 100);
        daninaTachka.transform.position = new Vector3(-5, -3, -1);

        CarsAnimationHandler();

        setEnvironmentMusic();
        this.DialogueBox.SetActive(false);
        StartCoroutine(TimerDialogueBoxHandler());

        untilEnd(); 

        
        return 0;
    }

    private async void untilEnd()
    {
        await Task.Delay(Convert.ToInt32(timerBeforeNextSlide) * 1000);
        DestroyImmediate(pressStickButton);
    }

    private float timerHandler()
    {
        if (!isGameEnded)
        {
            isGameEnded = true;
            return timerBeforeNextSlide;
        }
        
        else
        {
            return 3f;
        }
    }

    private IEnumerator TimerDialogueBoxHandler()
    {
        int imgIndex = 0;

        while (imgIndex < arrayNewBGImages.Length)
        {

            if (willShadowWithChange) StartCoroutine(ShadowChangeBackground(imgIndex));

            else changeBackground(imgIndex);
            
            imgIndex++;

            yield return new WaitForSeconds(timerHandler());
        }

       
   
        this.DialogueBox.SetActive(true);
        StopAllCoroutines();
        DestroyImmediate(daninaTachka);
        
        DestroyImmediate(Stremo);
        DestroyImmediate(Cars);
        if (endMusicOnEnd)
        {
            
            GameObject.Find("DialogueManager").GetComponent<DialogueManager>().softTurnOffEnvironmentMusic();
        }

    }


    // Корутина для анимация стика игры (Жми)
    private void StickButtonHandler()
    {
        float originSize = 100f;

         if(pressStickButton)
        {
  
            Transform innerCircle = pressStickButton.transform.Find("rightStick").Find("Inner");

           


            StartCoroutine(stickButtonAnimation(innerCircle, originSize));

            Debug.Log("ПРИЕХАЛИ!!!");

        }
           
    }

    private IEnumerator stickButtonAnimation(Transform innerCircle, float originSize)
    {
        while (innerCircle.localScale.x < 150f)
        {
            innerCircle.localScale = new Vector3(innerCircle.localScale.x + 0.5f, innerCircle.localScale.y + 0.5f, 1);
     
            yield return new WaitForSeconds(0.001f);
        }

        innerCircle.localScale = new Vector3(originSize, originSize, 1);
        StartCoroutine(stickButtonAnimation(innerCircle, originSize));


    }

    async void CarsAnimationHandler()
    {
        Cars.transform.position = new Vector2(Cars.transform.position.x + 0.3f, Cars.transform.position.y);
        await Task.Delay(50);
        CarsAnimationHandler();
    }

   async private void ProgressBarBehaviorHandler()
    {
        if (PressProgressBar)
        {
            if (PressProgressBar.size >= 0.1f)
            {
                if (PressProgressBar.size >= 0.4)
                {
                    ChangeProgressBarColor(Color.yellow);
                    PressProgressBar.size -= 0.2f;

                }
                else if(PressProgressBar.size >= 0.5)
                {
                    ChangeProgressBarColor(Color.green);
                    PressProgressBar.size -= 0.4f;

                }
                else if(PressProgressBar.size >= 0.6)
                {
                    ChangeProgressBarColor(Color.green);
                    PressProgressBar.size -= 0.6f;

                }
                else
                {
                    Debug.Log("ELSE EBANA");
                    ChangeProgressBarColor(Color.red);
                    PressProgressBar.size -= 0.05f;
                    

                }
            }
            Debug.Log($"CHE?? { PressProgressBar.size } ");
            await Task.Delay(700);
            ProgressBarBehaviorHandler();
        }
        
    }

    private void ChangeProgressBarColor(Color color)
    {
        ColorBlock cb = PressProgressBar.colors;
        cb.normalColor = color;
        PressProgressBar.colors = cb;
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

    private void setEnvironmentMusic()
    {

        if (this.newBackgroundSound)
        {
            GameObject.Find("DialogueManager").GetComponent<DialogueManager>().setEnvironmentMusic(this.newBackgroundSound);
        }

    }

    private void changeBackground(int imgIndex)
    {

    }

    public void clickButton()
    {
        if(PressProgressBar != null)
        {
            PressProgressBar.size += 0.03f;
      
        }
    }
}