using UnityEngine;
using UnityEngine.SceneManagement;

public class NeforsChangeSceneScript : MonoBehaviour, IConditionHandler
{
    /*public GameObject conditionHandlerObject;*/

    public string checkValue; // Название переменной в словаре которая отвечает за результат выбора Данчика (Нефоры или Кто-то из компании)

    public byte SceneOfCompanyMember; // ID сцены если данчик выбирает члена компании

    public int StartConditionHandle()
    {
        if (!GameManager.Instance.GetSomeThingsListValue(checkValue)) // Если отказал нефорам
        {
            SceneManager.LoadScene(SceneOfCompanyMember);
        }
        else // Если согласился
        {
        
            int companyRep = GameManager.Instance.GetReputationListValue("Company");
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            GameManager.currentScene = currentScene;
            Debug.Log($"Текущая сцена: {currentScene}");

            switch (companyRep)
            {
                case 75:
                    SceneManager.LoadScene(7);
                    break;
                case 50:
                    SceneManager.LoadScene(11);
                    break;
                case 25:
                    SceneManager.LoadScene(15);
                    break;
                case 0:
                    SceneManager.LoadScene(21);
                    break;
                default:
                    SceneManager.LoadScene(0);
                    Debug.Log("Ошибка Nefors Change Scene Script");
                    GameManager.Instance.notifyItemHandler(false, "Фатальная анальная ошибка", null, true);
                    break;
            }
        }

        // Возвращаем значение по умолчанию или обработку ошибки
        return -1;
    }
}
