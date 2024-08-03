using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject[] prefabNotifyReputation;

    public GameObject prefabNotifyItem;
    public GameObject prefabNotifyAchievment;

    private bool hasNotifyShowing = false;

    public bool sliderStop;

    public static Dictionary<string, bool> someThingsList = new Dictionary<string, bool> // ���������
    {
        { "Tobacco", false},
        { "BogdanAdvice", false },
        { "hasCucumbers", false },
        { "askBurgerMarinad", false },
        { "FreskoCorrect", false },
        { "MedalLGBT", false },
        { "Chocolate", false },
        { "DeclineNeforsOne", false },
        { "DeclineNeforsTwo", false },
        { "DeclineNeforsThree", false },

    };

    public bool GetSomeThingsListValue(string key)   // ������ ��� ����
    {
        if (GameManager.someThingsList.ContainsKey(key))
        {
            return GameManager.someThingsList[key];
        }
        else
        {
            Debug.LogError($"[SOME THING LIST ERROR] ���� ������ �������� � �������, {key}");
            return false;
        }
    }
 
    public void SetSomeThingsListValue(string key, bool value)  // ������ ��� ����
    {
        bool result = GetSomeThingsListValue(key);
        someThingsList[key] = value;
        Debug.Log($"��������: {key} ������ {value}");

    }

    public static Dictionary<string, int> reputationList = new Dictionary<string, int> // ���������
    {
        { "Parents",  50},
        { "RuslanAndSanya",  70},
        { "Bogdan",  50},
        { "Company",  50},
        { "Neformals",  50},
    };

    public int GetReputationListValue(string key)   // ������ ��� ���������
    {
        if (reputationList.ContainsKey(key))
        {
            return reputationList[key];
        }
        else
        {
            Debug.LogError($"[REPUTATION LIST ERROR] ���� ������ �������� � �������! {key}");
            return -1;
        }
    }

    public void SetReputationListValue(string key, int value)  // ������ ��� ���������
    {
        int repPoints = GetReputationListValue(key);

        notifyReputationHandler(key, repPoints, value); // ����� ���������� �� ������ ������ ����������� �� ��������� ���������.

        if (repPoints >= 0) {
            repPoints += value;
            if(repPoints > 100) // ��������� �� ����� ���� ������ �����
            {
                repPoints = 100;
            }
            else if(repPoints < 0) // ... � ������ ����
            {
                repPoints = 0;
            }
            reputationList[key] = repPoints;
            
            
        }
        
        
    }


    public Image currentCharacter;
    
    public VpadluHeroes[] VpadluHeroes;

    private void Awake()
    {
        Instance = this;
    }

    public void changeCurrentCharacter(Sprite Avatar)
    {
        /*if (id == 0)
        {
            this.currentCharacter.color = new Color(this.currentCharacter.color.r, this.currentCharacter.color.g, this.currentCharacter.color.b, 0.5f);
            return;
        }
        else
        {

        }*/
        currentCharacter.sprite = Avatar;

    }

    private void notifyReputationHandler(string hero, int actuallyRepPoints, int countOfNewPoints)
    {
        GameObject notifyRep;
        GameObject notifyContainer = GameObject.Find("notifyContainer");

    
        string pluralName; // ��� � ������������ (��������, ������)

        if (!notifyContainer)
        {
            Debug.Log("NOTIFY CONTAINER NE NAIDEN!!!");
        }

        switch(hero)
        {
            case "Bogdan":
                pluralName = "�������";
                break;
            case "RuslanAndSanya":
                pluralName = "�������";
                break;
            case "Company":
                pluralName = "�������";
                break;
            case "Neformals":
                pluralName = "�������";
                break;
            case "Parents":
                pluralName = "���������";
                break;
            default:
                pluralName = "������ �����������";
                break;
        }
        

        if ( (actuallyRepPoints + countOfNewPoints) > actuallyRepPoints )
        {
            notifyRep = Instantiate(prefabNotifyReputation[0]); // ������� ������ � ���������� ������ �� ���� � ����������.
            switch(countOfNewPoints)
            {
                case 10:
                    notifyRep.GetComponentInChildren<TextMeshProUGUI>().text = $"{pluralName} ���� �������� ����������";
                    break;
                case 20:
                    notifyRep.GetComponentInChildren<TextMeshProUGUI>().text = $"{pluralName} ���� �������� ������� �� �����!";
                    break;
                case 50:
                    notifyRep.GetComponentInChildren<TextMeshProUGUI>().text = $"�� ��������� ������ {pluralName}, ��� ���� ������ ������ �� �����!";
                    break;
                default:
                    notifyRep.GetComponentInChildren<TextMeshProUGUI>().text = $"{pluralName} �������� ��, ��� �� �������";
                    break;
            }
            
 
        }
        else
        {
            // ������� ��� �� �����������
            notifyRep = Instantiate(prefabNotifyReputation[1]);
            switch (countOfNewPoints)
            {
                case -10:
                    notifyRep.GetComponentInChildren<TextMeshProUGUI>().text = $"{pluralName} ���� �������� ����������. ������� � ������ ������!";
                    break;
                case -20:
                    notifyRep.GetComponentInChildren<TextMeshProUGUI>().text = $"{pluralName} �� �������� ��, ��� �� �������!";
                    break;
                case -50:
                    notifyRep.GetComponentInChildren<TextMeshProUGUI>().text = $"�� ������� ������� {pluralName}, ����� ������ ����� ��� ������� �����������!";
                    break;
                default:
                    notifyRep.GetComponentInChildren<TextMeshProUGUI>().text = $"{pluralName} ���� �������, ��� �� �������";
                    break;
            }
        }

        notifyRep.transform.SetParent(notifyContainer.transform); // ����� �������� ���������� ������ � ������������ ��������� "notifyContainer"
        notifyRep.transform.localScale = new Vector2(1, 1);

        StartCoroutine(showNotify(notifyRep));
    }

    public void notifyItemHandler(bool isItem, string itemName, Sprite image = null)
    {
        GameObject notifyItem;
        GameObject notifyContainer = GameObject.Find("notifyContainer");
        if (!notifyContainer)
        {
            Debug.Log("NOTIFY CONTAINER NE NAIDEN!!!");
        }
        
        if (isItem)
        {
            notifyItem = Instantiate(prefabNotifyItem);
        }
        else
        {
            notifyItem = Instantiate(prefabNotifyAchievment);
        }
       
        notifyItem.GetComponentInChildren<TextMeshProUGUI>().text = itemName;
        if (image != null)
        {
           notifyItem.transform.Find("AchievmentImage").GetComponent<Image>().sprite = image;
        }

        notifyItem.transform.SetParent(notifyContainer.transform); // ����� �������� ���������� ������ � ������������ ��������� "notifyContainer"
        notifyItem.transform.localScale = new Vector2(1, 1);
      

        StartCoroutine(showNotify(notifyItem));
    }

    IEnumerator showNotify(GameObject notify)
            {
                while (hasNotifyShowing)
                {
                    // ���� ������� ���������� ������� ����� ��������� ���������
                    yield return null;
                }
                yield return new WaitForSeconds(2f);
                Animator notifyAnimator = notify.GetComponent<Animator>();
                hasNotifyShowing = true;
                notifyAnimator.SetBool("isOpen", true);

                // ���� 2 �������
                yield return new WaitForSeconds(4f);
            
                notifyAnimator.SetBool("isOpen", false);
                hasNotifyShowing = false;
                yield return new WaitForSeconds(1f);
                DestroyImmediate(notify);
             }

    public void ActivateNextTrigger(GameObject nextTrigger)   // ������������� ��������� ���������� ��������.
    {

        if (nextTrigger.GetComponent<StartDialogueTrigger>())
        {
            nextTrigger.GetComponent<StartDialogueTrigger>().TriggerDialogue();
            return;
        }
        else if (nextTrigger.GetComponent<ChoiceTrigger>())
        {
            nextTrigger.GetComponent<ChoiceTrigger>().TriggerChoice();
            return;
        }
        else if (nextTrigger.GetComponent<ConditionTrigger>())
        {
            nextTrigger.GetComponent<ConditionTrigger>().TriggerCondition();
            return;
        }

    }

    public void softTurnOffEnvironmentMusic(AudioSource musicSource)
    {
       
        StartCoroutine(setVolumeToZero(musicSource));

    }

    private IEnumerator setVolumeToZero(AudioSource musicSource)
    {
        AudioClip currentAudioClip = musicSource.clip;

        while (musicSource.volume > 0.00f && !sliderStop)
        {
            Debug.Log(musicSource.volume);
            // ��������� ������
            Debug.Log(musicSource.volume - 0.0005f);
            musicSource.volume = musicSource.volume - 0.0005f;
            Debug.Log(musicSource.volume);

            yield return null;
        }
        if (musicSource.clip == currentAudioClip)
        {
            musicSource.clip = null;
            musicSource.volume = 0.15f;
        }
        else
        {
            musicSource.volume = 0.15f;
        }
        sliderStop = false;
       
        
        Debug.Log("������ ��������� � ������������� ��������� �������������");

    }

}
