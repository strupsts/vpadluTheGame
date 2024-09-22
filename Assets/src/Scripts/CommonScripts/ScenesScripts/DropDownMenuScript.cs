using System.Collections.Generic; // Для использования списков
using UnityEngine;
using UnityEngine.SceneManagement; // Для работы с загрузкой сцен
using TMPro; // Для работы с TMP

public class DropDownMenuScript : MonoBehaviour
{
 
    public TMP_Dropdown dropdown; // Ссылка на TMP_Dropdown UI элемент

    // Список названий сцен, соответствующий ID сцен из Build Settings
    private List<string> sceneNames = new List<string>();

    void Start()
    {
        // Инициализация списка сцен из Build Settings
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            // Получаем путь к сцене
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            // Получаем имя сцены (удаляем путь и расширение)
            string sceneName = System.IO.Path.GetFileNameWithoutExtension(scenePath);
            sceneNames.Add(sceneName); // Добавляем в список сцен
        }

        // Очищаем старые опции и добавляем новые
        dropdown.ClearOptions();
        dropdown.AddOptions(sceneNames); // Добавляем имена сцен в TMP_Dropdown

        // Назначаем обработчик изменения значения TMP_Dropdown
        dropdown.onValueChanged.AddListener(delegate { LoadSelectedScene(dropdown.value); });
    }

    // Метод для загрузки сцены по её индексу
    void LoadSelectedScene(int sceneIndex)
    {
        Debug.Log("Loading scene: " + sceneNames[sceneIndex] + " with ID: " + sceneIndex);
        SceneManager.LoadScene(sceneIndex); // Загружаем сцену по её ID
    }
}
