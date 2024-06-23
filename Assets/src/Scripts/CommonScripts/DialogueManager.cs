using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public StartDialogueTrigger StartDialogueTrigger;

  
    int dialogueIndex = 0;


    

    public Animator animator;

    private bool typingLettersRunning = false;

    private StartDialogueTrigger currentDialogueTrigger;

    



    //Character
     
    // Audio
    private Queue<SentenceAndSound> SaSArr;

    private SentenceAndSound SaSElement;

    public AudioSource musicSource; // Ссылка на компонент AudioSource для музыки
    public AudioClip backgroundMusic; // Аудиоклип вашей мелодии


    void Start()
    {
        initEnvironmentMusic();
        SaSArr = new Queue<SentenceAndSound>(); // Иницциализация очереди

        StartDialogueTrigger.TriggerDialogue(); // Начало игры с объекта на сцене Dialogue1
    }

    public void StartDialogue(Dialogue dialogue, StartDialogueTrigger triggerInstance)
    {
        /*if (isSliderMusic)
        {
            Debug.Log("Музыка багнула и была восстановлена");
            musicSource.clip = null;
            musicSource.volume = 0.15f;
            isSliderMusic = false;
        }*/


        animator.SetBool("isOpen", false); // Открываем окно диалога

        currentDialogueTrigger = triggerInstance; // В переменной лежит скрипт с его областью видимости. Используется когда персонаж договорит и очередь будет следующего собеседника


        VpadluHeroes currentHero = GameManager.Instance.VpadluHeroes[dialogue.heroID];


        dialogue.speakerName = currentHero.Name;
        nameText.text = currentHero.Name; ;
       

        GameManager.Instance.changeCurrentCharacter(currentHero.Avatar); // Меняем спрайт активного персонажа
         
        
      
        SaSArr.Clear();
        dialogueIndex = 0;

        foreach (SentenceAndSound sas in dialogue.sentencesAndSounds)
        {
            sas.sound.AudioSource = gameObject.AddComponent<AudioSource>();
            sas.sound.AudioSource.clip = sas.sound.clip;
            SaSArr.Enqueue(sas); // Добавляем в массив(очередь) - объект содержащий текст и озвучку.
        }



        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (typingLettersRunning)
        {
            StopAllCoroutines();
            typingLettersRunning = false;
            dialogueText.text = SaSElement.sentence;  
            dialogueIndex++;  
            return;
        }

        if (SaSArr.Count == 0)
        {
            EndDialogue();
            return;
        }

        SaSElement = SaSArr.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(SaSElement.sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        PlaySound();
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            typingLettersRunning = true;
            yield return new WaitForSeconds(0.08f); // Скорость воспроизведения предложения побуквенно.
            typingLettersRunning = false;
           

        }
    }

    private void initEnvironmentMusic()
    {
        
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.volume = 0.15f;
        musicSource.loop = true;
        if (backgroundMusic)
        {
            musicSource.clip = backgroundMusic;
            musicSource.Play();
        }
       
    }

    public void setEnvironmentMusic(AudioClip newEnvSound)
    {
        if (musicSource.volume != 0.15f)
        {
            GameManager.Instance.sliderStop = true; 
           /* musicSource.clip = null;
            musicSource.volume = 0.15f;*/
            musicSource.clip = newEnvSound;
            musicSource.Play();

        }
        else
        {
            musicSource.clip = newEnvSound;
            musicSource.Play();
        }

    }

    public void softTurnOffEnvironmentMusic()
    {
        
        /*StartCoroutine(setVolumeToZero());*/
        GameManager.Instance.softTurnOffEnvironmentMusic(musicSource);

    }

    private IEnumerator setVolumeToZero()
    {


        while (musicSource.volume > 0.00f)
        {
            Debug.Log(musicSource.volume);
            // Затухание музыки
            Debug.Log(musicSource.volume - 0.0005f);
            musicSource.volume = musicSource.volume - 0.0005f;
            Debug.Log(musicSource.volume);

            yield return null;
        }
        musicSource.clip = null;
        musicSource.volume = 0.15f;

        Debug.Log("Музыка заглушена и восстановлена громкость проигрывателя");

    }



    public void PlaySound()
    {

        Sound s = SaSElement.sound;

        if (s == null)
        {
            Debug.Log($"Звук не найден!");
            return;
        }

        s.AudioSource.Play();
        dialogueIndex++;
    }

    public void EndDialogue()
    {
        
        currentDialogueTrigger.TriggerDialogue(); // Обращаемся к области видимости скрипта, что вызвал ДиалогМенеджер после того как текущий персонаж договорит, чтобы вызвать
                                                 // очередь следующего персонажа и его набора фраз.
        if (currentDialogueTrigger.dialogueIsEnded)
        {
            Debug.Log("Конец Диалога");
            animator.SetBool("isOpen", true); // Закрываем окно диалога
        }

    }

    


}
