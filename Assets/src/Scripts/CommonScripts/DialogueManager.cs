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

    public AudioSource musicSource; // ������ �� ��������� AudioSource ��� ������
    public AudioClip backgroundMusic; // ��������� ����� �������


    void Start()
    {
        initEnvironmentMusic();
        SaSArr = new Queue<SentenceAndSound>(); // �������������� �������

        StartDialogueTrigger.TriggerDialogue(); // ������ ���� � ������� �� ����� Dialogue1
    }

    public void StartDialogue(Dialogue dialogue, StartDialogueTrigger triggerInstance)
    {
        /*if (isSliderMusic)
        {
            Debug.Log("������ ������� � ���� �������������");
            musicSource.clip = null;
            musicSource.volume = 0.15f;
            isSliderMusic = false;
        }*/


        animator.SetBool("isOpen", false); // ��������� ���� �������

        currentDialogueTrigger = triggerInstance; // � ���������� ����� ������ � ��� �������� ���������. ������������ ����� �������� ��������� � ������� ����� ���������� �����������


        VpadluHeroes currentHero = GameManager.Instance.VpadluHeroes[dialogue.heroID];


        dialogue.speakerName = currentHero.Name;
        nameText.text = currentHero.Name; ;
       

        GameManager.Instance.changeCurrentCharacter(currentHero.Avatar); // ������ ������ ��������� ���������
         
        
      
        SaSArr.Clear();
        dialogueIndex = 0;

        foreach (SentenceAndSound sas in dialogue.sentencesAndSounds)
        {
            sas.sound.AudioSource = gameObject.AddComponent<AudioSource>();
            sas.sound.AudioSource.clip = sas.sound.clip;
            SaSArr.Enqueue(sas); // ��������� � ������(�������) - ������ ���������� ����� � �������.
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
            yield return new WaitForSeconds(0.08f); // �������� ��������������� ����������� ����������.
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
            // ��������� ������
            Debug.Log(musicSource.volume - 0.0005f);
            musicSource.volume = musicSource.volume - 0.0005f;
            Debug.Log(musicSource.volume);

            yield return null;
        }
        musicSource.clip = null;
        musicSource.volume = 0.15f;

        Debug.Log("������ ��������� � ������������� ��������� �������������");

    }



    public void PlaySound()
    {

        Sound s = SaSElement.sound;

        if (s == null)
        {
            Debug.Log($"���� �� ������!");
            return;
        }

        s.AudioSource.Play();
        dialogueIndex++;
    }

    public void EndDialogue()
    {
        
        currentDialogueTrigger.TriggerDialogue(); // ���������� � ������� ��������� �������, ��� ������ �������������� ����� ���� ��� ������� �������� ���������, ����� �������
                                                 // ������� ���������� ��������� � ��� ������ ����.
        if (currentDialogueTrigger.dialogueIsEnded)
        {
            Debug.Log("����� �������");
            animator.SetBool("isOpen", true); // ��������� ���� �������
        }

    }

    


}
