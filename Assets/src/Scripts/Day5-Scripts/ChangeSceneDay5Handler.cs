using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneDay5Handler : MonoBehaviour, IConditionHandler
{
    public GameObject conditionHandlerObject;

    public int StartConditionHandle()
    {
        if (!GameManager.Instance.GetSomeThingsListValue("DeclineNeforsThree")) // Если отказал нефорам
        {
            SceneManager.LoadScene(14);
        }
        else // Если согласился
        {
            SceneManager.LoadScene(15);
        }

        // Возвращаем значение по умолчанию или обработку ошибки
        return -1;
    }
}
