using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneDay3Handler : MonoBehaviour, IConditionHandler
{
    /*public GameObject conditionHandlerObject;*/

    public int StartConditionHandle()
    {
        if (!GameManager.Instance.GetSomeThingsListValue("DeclineNeforsOne")) // Если отказал нефорам
        {
            SceneManager.LoadScene(6);
        }
        else // Если согласился
        {
            SceneManager.LoadScene(7);
        }

        // Возвращаем значение по умолчанию или обработку ошибки
        return -1;
    }
}
