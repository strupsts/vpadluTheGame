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

    public static Dictionary<string, bool> someThingsList = new Dictionary<string, bool> // Репутация
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

    public bool GetSomeThingsListValue(string key)   // Геттер для шняг
    {
        if (GameManager.someThingsList.ContainsKey(key))
        {
            return GameManager.someThingsList[key];
        }
        else
        {
            Debug.LogError($"[SOME THING LIST ERROR] Нету такого значения в словаре, {key}");
            return false;
        }
    }
 
    public void SetSomeThingsListValue(string key, bool value)  // Сеттер для шняг
    {
        bool result = GetSomeThingsListValue(key);
        someThingsList[key] = value;
        Debug.Log($"Значение: {key} теперь {value}");

    }

    public static Dictionary<string, int> reputationList = new Dictionary<string, int> // Репутация
    {
        { "Parents",  50},
        { "RuslanAndSanya",  70},
        { "Bogdan",  50},
        { "Company",  50},
        { "Neformals",  50},
    };

    public int GetReputationListValue(string key)   // Геттер для репутации
    {
        if (reputationList.ContainsKey(key))
        {
            return reputationList[key];
        }
        else
        {
            Debug.LogError($"[REPUTATION LIST ERROR] Нету такого значения в словаре! {key}");
            return -1;
        }
    }

    public void SetReputationListValue(string key, int value)  // Сеттер для репутации
    {
        int repPoints = GetReputationListValue(key);

        notifyReputationHandler(key, repPoints, value); // Метод отвечающий за логику показа уведомлений об изменении репутации.

        if (repPoints >= 0) {
            repPoints += value;
            if(repPoints > 100) // Репутация не может быть больше сотни
            {
                repPoints = 100;
            }
            else if(repPoints < 0) // ... и меньше нуля
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

    
        string pluralName; // Имя в множественом (Родители, братья)

        if (!notifyContainer)
        {
            Debug.Log("NOTIFY CONTAINER NE NAIDEN!!!");
        }

        switch(hero)
        {
            case "Bogdan":
                pluralName = "Богдану";
                break;
            case "RuslanAndSanya":
                pluralName = "Братьям";
                break;
            case "Company":
                pluralName = "Пацанам";
                break;
            case "Neformals":
                pluralName = "Нефорам";
                break;
            case "Parents":
                pluralName = "Родителям";
                break;
            default:
                pluralName = "Твоему собеседнику";
                break;
        }
        

        if ( (actuallyRepPoints + countOfNewPoints) > actuallyRepPoints )
        {
            notifyRep = Instantiate(prefabNotifyReputation[0]); // Создаем префаб и записываем ссылку на него в переменную.
            switch(countOfNewPoints)
            {
                case 10:
                    notifyRep.GetComponentInChildren<TextMeshProUGUI>().text = $"{pluralName} твой поступок запомнится";
                    break;
                case 20:
                    notifyRep.GetComponentInChildren<TextMeshProUGUI>().text = $"{pluralName} твои действия реально по кайфу!";
                    break;
                case 50:
                    notifyRep.GetComponentInChildren<TextMeshProUGUI>().text = $"Ты настолько угодил {pluralName}, что тебя готовы носить на руках!";
                    break;
                default:
                    notifyRep.GetComponentInChildren<TextMeshProUGUI>().text = $"{pluralName} нравится то, что ты делаешь";
                    break;
            }
            
 
        }
        else
        {
            // Богдану это не понравилось
            notifyRep = Instantiate(prefabNotifyReputation[1]);
            switch (countOfNewPoints)
            {
                case -10:
                    notifyRep.GetComponentInChildren<TextMeshProUGUI>().text = $"{pluralName} твой поступок запомнится. Конечно в плохом смысле!";
                    break;
                case -20:
                    notifyRep.GetComponentInChildren<TextMeshProUGUI>().text = $"{pluralName} не нравится то, что ты делаешь!";
                    break;
                case -50:
                    notifyRep.GetComponentInChildren<TextMeshProUGUI>().text = $"Ты реально насолил {pluralName}, после такого точно жди ужасных последствий!";
                    break;
                default:
                    notifyRep.GetComponentInChildren<TextMeshProUGUI>().text = $"{pluralName} явно кажется, что ты дурачок";
                    break;
            }
        }

        notifyRep.transform.SetParent(notifyContainer.transform); // После создания перемещаем префаб в родительский компонент "notifyContainer"
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

        notifyItem.transform.SetParent(notifyContainer.transform); // После создания перемещаем префаб в родительский компонент "notifyContainer"
        notifyItem.transform.localScale = new Vector2(1, 1);
      

        StartCoroutine(showNotify(notifyItem));
    }

    IEnumerator showNotify(GameObject notify)
            {
                while (hasNotifyShowing)
                {
                    // Ждем краткий промежуток времени перед повторной проверкой
                    yield return null;
                }
                yield return new WaitForSeconds(2f);
                Animator notifyAnimator = notify.GetComponent<Animator>();
                hasNotifyShowing = true;
                notifyAnimator.SetBool("isOpen", true);

                // Ждем 2 секунды
                yield return new WaitForSeconds(4f);
            
                notifyAnimator.SetBool("isOpen", false);
                hasNotifyShowing = false;
                yield return new WaitForSeconds(1f);
                DestroyImmediate(notify);
             }

    public void ActivateNextTrigger(GameObject nextTrigger)   // Универсальная активация следующего триггера.
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
            // Затухание музыки
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
       
        
        Debug.Log("Музыка заглушена и восстановлена громкость проигрывателя");

    }

}
