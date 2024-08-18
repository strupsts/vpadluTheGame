using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    private bool hasSaves;

    [System.Serializable]
    public class SaveDataBool
    {
        public string key;
        public bool value;
    }

    [System.Serializable]
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
        PlayerPrefs.SetInt("ContinueScene", SceneManager.GetActiveScene().buildIndex + 1); // Сохраняем индекс следующей сцены от той, которую игрок уже прошёл.

        SaveManager.SaveDictionary("someThingsList"); // Сохранение словаря с событиями
        SaveManager.SaveDictionary("reputationList"); // Сохранение словаря с репутацией

        PlayerPrefs.Save();
        Debug.Log("Игра сохранена!");
    }

    public static void LoadGame()
    {
        SaveManager.LoadDictionary("someThingsList"); // Загрузка словаря с событиями
        SaveManager.LoadDictionary("reputationList"); // Загрузка словаря с репутацией

        SceneManager.LoadScene(PlayerPrefs.GetInt("ContinueScene"));
        Debug.Log("Игра загружена!");
    }

    public static bool checkSaves() // Метод для проверки из playButton меню, существуют ли сохранения
    {
        Debug.Log($"CONTINUE SCENE PLAYERS PREFS: {PlayerPrefs.GetInt("ContinueScene")}");
        return PlayerPrefs.GetInt("ContinueScene") > 1;
    }

    public static void SaveDictionary(string nameOfDictionary)
    {
        if (nameOfDictionary == "someThingsList")
        {
            List<SaveDataBool> saveDataList = new List<SaveDataBool>();
            foreach (var kvp in GameManager.someThingsList)
            {
                saveDataList.Add(new SaveDataBool { key = kvp.Key, value = kvp.Value });
            }

            string json = JsonHelper.ToJson(saveDataList.ToArray());
            PlayerPrefs.SetString(nameOfDictionary, json);
        }
        else if (nameOfDictionary == "reputationList")
        {
            List<SaveDataInt> saveDataList = new List<SaveDataInt>();
            foreach (var kvp in GameManager.reputationList)
            {
                saveDataList.Add(new SaveDataInt { key = kvp.Key, value = kvp.Value });
            }

            string json = JsonHelper.ToJson(saveDataList.ToArray());
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
        if (nameOfDictionary == "someThingsList")
        {
            string json = PlayerPrefs.GetString(nameOfDictionary, null);
            if (string.IsNullOrEmpty(json))
            {
                Debug.LogWarning($"Не удалось загрузить словарь {nameOfDictionary}, так как данные отсутствуют.");
                return;
            }

            SaveDataBool[] saveDataArray = JsonHelper.FromJson<SaveDataBool>(json);
            GameManager.someThingsList.Clear();
            foreach (var saveData in saveDataArray)
            {
                GameManager.someThingsList[saveData.key] = saveData.value;
                Debug.Log($"KEY: {GameManager.someThingsList[saveData.key]}, VALUE: {saveData.value}");
            }
        }
        else if (nameOfDictionary == "reputationList")
        {
            string json = PlayerPrefs.GetString(nameOfDictionary, null);
            if (string.IsNullOrEmpty(json))
            {
                Debug.LogWarning($"Не удалось загрузить словарь {nameOfDictionary}, так как данные отсутствуют.");
                return;
            }

            SaveDataInt[] saveDataArray = JsonHelper.FromJson<SaveDataInt>(json);
            GameManager.reputationList.Clear();
            foreach (var saveData in saveDataArray)
            {
                GameManager.reputationList[saveData.key] = saveData.value;
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
