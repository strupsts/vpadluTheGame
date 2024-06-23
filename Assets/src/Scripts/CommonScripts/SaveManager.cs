using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    private bool hasSaves;

    public class SaveDataBool
    {
        public string key;
        public bool value;
    }
    public class SaveDataInt
    {
        public string key;
        public int value;
    }

    
    private void Awake()
    {
        instance = this;
    }


    public static void SaveGame()
    {

        PlayerPrefs.SetInt("ContinueScene", SceneManager.GetActiveScene().buildIndex + 1); // Сохраняем индекс следующей сцену от той которую игрок уже прошёл.

        SaveManager.SaveDictionary("someThingsList"); // Сохранения словаря с событиями
        SaveManager.SaveDictionary("reputationList"); // Сохранения словаря с репутацией

        PlayerPrefs.Save();
        Debug.Log("Игра сохранена!");

    }

    public static void LoadGame() 
    {
        SaveManager.LoadDictionary("someThingsList"); // Сохранения словаря с событиями
        SaveManager.LoadDictionary("reputationList"); // Сохранения словаря с репутацией

        SceneManager.LoadScene(PlayerPrefs.GetInt("ContinueScene"));
        Debug.Log("Игра загружена!");
       
    }

    public static bool checkSaves() // Метод для проверки из playButton меню, существуют ли сохранения
    {
        Debug.Log($"CONTINUE SCENE PLAYERS PREFFS::: {PlayerPrefs.GetInt("ContinueScene")}");
        if (PlayerPrefs.GetInt("ContinueScene") > 1) return true;
        else return false;
    }

    public static void SaveDictionary(string nameOfDictionary)
    {
       
        if (nameOfDictionary == "someThingsList")
        {
            string json;
            List<SaveDataBool> saveDataList = new List<SaveDataBool>();
            // Преобразуем каждую пару ключ-значение в объект SaveData
            foreach (var kvp in GameManager.someThingsList)
            {
                saveDataList.Add(new SaveDataBool { key = kvp.Key, value = kvp.Value });
                Debug.Log($" {kvp.Key} = key, {kvp.Value} = value");
            }

            Debug.Log($"SaveDataList: {saveDataList.Count}");


            // Преобразуем список в JSON
            json = JsonUtility.ToJson(saveDataList);
            PlayerPrefs.SetString(nameOfDictionary, json);
        }

        else if(nameOfDictionary == "reputationList")
        {
            string json;
            List<SaveDataInt> saveDataList = new List<SaveDataInt>();
            // Преобразуем каждую пару ключ-значение в объект SaveData
            foreach (var kvp in GameManager.reputationList)
            {
                saveDataList.Add(new SaveDataInt { key = kvp.Key, value = kvp.Value });
            }

            Debug.Log($"SaveDataList: {saveDataList.Count}");


            // Преобразуем список в JSON
            json = JsonUtility.ToJson(saveDataList);
            PlayerPrefs.SetString(nameOfDictionary, json);
        }
        else
        {
            Debug.Log($"Ошибка при сохранении словаря! Неправильно указано имя словаря! {nameOfDictionary}");
            return;
        }  
            Debug.Log($"Словарь {nameOfDictionary} успешно сохранён!");

    }

    public static void LoadDictionary(string nameOfDictionary)
    {
        if(nameOfDictionary == "someThingsList")
        {
            // Получаем JSON из PlayerPrefs или из файла
            string json = PlayerPrefs.GetString(nameOfDictionary);

            // Преобразуем JSON обратно в список объектов SaveData
            List<SaveDataBool> saveDataList = JsonUtility.FromJson<List<SaveDataBool>>(json);

            Debug.Log($"SaveDataList: {saveDataList.Count}");

            // Заполняем словарь на основе данных из списка
            GameManager.someThingsList.Clear();
            foreach (var saveData in saveDataList)
            {
                GameManager.someThingsList[saveData.key] = saveData.value;
                Debug.Log($" {saveData.key} = key, {saveData.value} = value");

            }
        }
        else if(nameOfDictionary == "reputationList")
        {
            // Получаем JSON из PlayerPrefs или из файла
            string json = PlayerPrefs.GetString(nameOfDictionary);

            // Преобразуем JSON обратно в список объектов SaveData
            List<SaveDataInt> saveDataList = JsonUtility.FromJson<List<SaveDataInt>>(json);

            Debug.Log($"SaveDataList Length: {saveDataList.Count}");

            // Заполняем словарь на основе данных из списка
            GameManager.reputationList.Clear();
            foreach (var saveData in saveDataList)
            {
                GameManager.reputationList[saveData.key] = saveData.value;
                Debug.Log($" {saveData.key} = key, {saveData.value} = value");
            }
          
        }
        else
        {
            Debug.Log($"Ошибка загрузки словаря! Неправильно указано имя! {nameOfDictionary}");
            return;
        }
        Debug.Log($"Словарь {nameOfDictionary} успешно загружен!");

    }


}
