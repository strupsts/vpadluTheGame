using System.Collections;
using System.Collections.Generic;
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
        GameManager.someThingsList.Clear();
        GameManager.reputationList.Clear();
        GameManager.currentScene = 0;
        Quiz.QuizPointsList.Clear();

        btn.GetComponentInChildren<TextMeshProUGUI>().text = "Новая игра";
    }
}
