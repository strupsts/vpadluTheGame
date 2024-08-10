using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneDay6Handler : MonoBehaviour, IConditionHandler
{
    public GameObject conditionHandlerObject;

    public int StartConditionHandle()
    {
        if (!GameManager.Instance.GetSomeThingsListValue("DeclineNeforsFive")) // Если отказал нефорам
        {
            SceneManager.LoadScene(20);
        }
        else // Если согласился
        {
            SceneManager.LoadScene(21);
        }

        // Возвращаем значение по умолчанию или обработку ошибки
        return -1;
    }
}
