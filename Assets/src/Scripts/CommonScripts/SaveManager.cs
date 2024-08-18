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
        PlayerPrefs.SetInt("ContinueScene", SceneManager.GetActiveScene().buildIndex + 1); // ��������� ������ ��������� ����� �� ���, ������� ����� ��� ������.

        SaveManager.SaveDictionary("someThingsList"); // ���������� ������� � ���������
        SaveManager.SaveDictionary("reputationList"); // ���������� ������� � ����������

        PlayerPrefs.Save();
        Debug.Log("���� ���������!");
    }

    public static void LoadGame()
    {
        SaveManager.LoadDictionary("someThingsList"); // �������� ������� � ���������
        SaveManager.LoadDictionary("reputationList"); // �������� ������� � ����������

        SceneManager.LoadScene(PlayerPrefs.GetInt("ContinueScene"));
        Debug.Log("���� ���������!");
    }

    public static bool checkSaves() // ����� ��� �������� �� playButton ����, ���������� �� ����������
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
            Debug.Log($"������ ��� ���������� �������! ����������� ������� ��� �������! {nameOfDictionary}");
            return;
        }
        Debug.Log($"������� {nameOfDictionary} ������� �������!");
    }

    public static void LoadDictionary(string nameOfDictionary)
    {
        if (nameOfDictionary == "someThingsList")
        {
            string json = PlayerPrefs.GetString(nameOfDictionary, null);
            if (string.IsNullOrEmpty(json))
            {
                Debug.LogWarning($"�� ������� ��������� ������� {nameOfDictionary}, ��� ��� ������ �����������.");
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
                Debug.LogWarning($"�� ������� ��������� ������� {nameOfDictionary}, ��� ��� ������ �����������.");
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
            Debug.Log($"������ �������� �������! ����������� ������� ���! {nameOfDictionary}");
            return;
        }
        Debug.Log($"������� {nameOfDictionary} ������� ��������!");
    }
}
