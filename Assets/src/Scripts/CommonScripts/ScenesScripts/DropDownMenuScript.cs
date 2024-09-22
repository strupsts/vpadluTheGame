using System.Collections.Generic; // ��� ������������� �������
using UnityEngine;
using UnityEngine.SceneManagement; // ��� ������ � ��������� ����
using TMPro; // ��� ������ � TMP

public class DropDownMenuScript : MonoBehaviour
{
 
    public TMP_Dropdown dropdown; // ������ �� TMP_Dropdown UI �������

    // ������ �������� ����, ��������������� ID ���� �� Build Settings
    private List<string> sceneNames = new List<string>();

    void Start()
    {
        // ������������� ������ ���� �� Build Settings
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            // �������� ���� � �����
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            // �������� ��� ����� (������� ���� � ����������)
            string sceneName = System.IO.Path.GetFileNameWithoutExtension(scenePath);
            sceneNames.Add(sceneName); // ��������� � ������ ����
        }

        // ������� ������ ����� � ��������� �����
        dropdown.ClearOptions();
        dropdown.AddOptions(sceneNames); // ��������� ����� ���� � TMP_Dropdown

        // ��������� ���������� ��������� �������� TMP_Dropdown
        dropdown.onValueChanged.AddListener(delegate { LoadSelectedScene(dropdown.value); });
    }

    // ����� ��� �������� ����� �� � �������
    void LoadSelectedScene(int sceneIndex)
    {
        Debug.Log("Loading scene: " + sceneNames[sceneIndex] + " with ID: " + sceneIndex);
        SceneManager.LoadScene(sceneIndex); // ��������� ����� �� � ID
    }
}
