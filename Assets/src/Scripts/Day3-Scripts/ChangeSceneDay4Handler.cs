using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneDay4Handler : MonoBehaviour, IConditionHandler
{
    public GameObject conditionHandlerObject;

    public int StartConditionHandle()
    {
        if (!GameManager.Instance.GetSomeThingsListValue("DeclineNeforsTwo")) // Если отказал нефорам
        {
            SceneManager.LoadScene(10);
        }
        else // Если согласился
        {
            SceneManager.LoadScene(11);
        }

        // Возвращаем значение по умолчанию или обработку ошибки
        return -1;
    }
}
