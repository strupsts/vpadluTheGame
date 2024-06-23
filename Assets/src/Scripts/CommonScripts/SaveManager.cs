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

        PlayerPrefs.SetInt("ContinueScene", SceneManager.GetActiveScene().buildIndex + 1); // ��������� ������ ��������� ����� �� ��� ������� ����� ��� ������.

        SaveManager.SaveDictionary("someThingsList"); // ���������� ������� � ���������
        SaveManager.SaveDictionary("reputationList"); // ���������� ������� � ����������

        PlayerPrefs.Save();
        Debug.Log("���� ���������!");

    }

    public static void LoadGame() 
    {
        SaveManager.LoadDictionary("someThingsList"); // ���������� ������� � ���������
        SaveManager.LoadDictionary("reputationList"); // ���������� ������� � ����������

        SceneManager.LoadScene(PlayerPrefs.GetInt("ContinueScene"));
        Debug.Log("���� ���������!");
       
    }

    public static bool checkSaves() // ����� ��� �������� �� playButton ����, ���������� �� ����������
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
            // ����������� ������ ���� ����-�������� � ������ SaveData
            foreach (var kvp in GameManager.someThingsList)
            {
                saveDataList.Add(new SaveDataBool { key = kvp.Key, value = kvp.Value });
                Debug.Log($" {kvp.Key} = key, {kvp.Value} = value");
            }

            Debug.Log($"SaveDataList: {saveDataList.Count}");


            // ����������� ������ � JSON
            json = JsonUtility.ToJson(saveDataList);
            PlayerPrefs.SetString(nameOfDictionary, json);
        }

        else if(nameOfDictionary == "reputationList")
        {
            string json;
            List<SaveDataInt> saveDataList = new List<SaveDataInt>();
            // ����������� ������ ���� ����-�������� � ������ SaveData
            foreach (var kvp in GameManager.reputationList)
            {
                saveDataList.Add(new SaveDataInt { key = kvp.Key, value = kvp.Value });
            }

            Debug.Log($"SaveDataList: {saveDataList.Count}");


            // ����������� ������ � JSON
            json = JsonUtility.ToJson(saveDataList);
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
        if(nameOfDictionary == "someThingsList")
        {
            // �������� JSON �� PlayerPrefs ��� �� �����
            string json = PlayerPrefs.GetString(nameOfDictionary);

            // ����������� JSON ������� � ������ �������� SaveData
            List<SaveDataBool> saveDataList = JsonUtility.FromJson<List<SaveDataBool>>(json);

            Debug.Log($"SaveDataList: {saveDataList.Count}");

            // ��������� ������� �� ������ ������ �� ������
            GameManager.someThingsList.Clear();
            foreach (var saveData in saveDataList)
            {
                GameManager.someThingsList[saveData.key] = saveData.value;
                Debug.Log($" {saveData.key} = key, {saveData.value} = value");

            }
        }
        else if(nameOfDictionary == "reputationList")
        {
            // �������� JSON �� PlayerPrefs ��� �� �����
            string json = PlayerPrefs.GetString(nameOfDictionary);

            // ����������� JSON ������� � ������ �������� SaveData
            List<SaveDataInt> saveDataList = JsonUtility.FromJson<List<SaveDataInt>>(json);

            Debug.Log($"SaveDataList Length: {saveDataList.Count}");

            // ��������� ������� �� ������ ������ �� ������
            GameManager.reputationList.Clear();
            foreach (var saveData in saveDataList)
            {
                GameManager.reputationList[saveData.key] = saveData.value;
                Debug.Log($" {saveData.key} = key, {saveData.value} = value");
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
