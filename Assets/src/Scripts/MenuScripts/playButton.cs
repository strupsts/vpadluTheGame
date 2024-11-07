using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playButton : MonoBehaviour
{
    public bool isContinuousButton;
    public GameObject btn;
    void Start()
    {
        if (isContinuousButton)
        {
            if (!SaveManager.checkSaves())
            {
                Debug.Log("Сохранений не найдено!");
                btn.GetComponentInChildren<TextMeshProUGUI>().text = "Новая игра";
               

            }
            else
            {
                btn.GetComponentInChildren<TextMeshProUGUI>().text = "Продолжить";
            }
  
        }
    }

    
    void Update()
    {
        
    }

    public void changeScene(int numOfScene)
    {
        SceneManager.LoadScene(numOfScene);
    }

    public void ContiuousGame()
    {
        if (!SaveManager.checkSaves())
        {
            SceneManager.LoadScene(1);
        }
        else 
        {
            SaveManager.LoadGame();
        }
        
    } 

    public void ClearAllData()
    {
        PlayerPrefs.DeleteAll();
        foreach (var key in GameManager.someThingsList.Keys.ToList())
        {
            GameManager.someThingsList[key] = false;
        }
        Debug.Log("Восстановили значения someThingsList на FALSE");
        foreach (var key in GameManager.reputationList.Keys.ToList())
        {
            if (key != "Company") GameManager.reputationList[key] = 50;
            else
            { 
                GameManager.reputationList[key] = 100;
                Debug.Log("С компанией восстановили репутацицю: 100 теперь.");
            }
        }

        GameManager.currentScene = 0;
        foreach (var key in Quiz.QuizPointsList.Keys.ToList())
        {
            Quiz.QuizPointsList[key] = 0;
        }
        Debug.Log("Восстановили значения QUIZ POINTS на 0 все");
        btn.GetComponentInChildren<TextMeshProUGUI>().text = "Новая игра";
    }
}
