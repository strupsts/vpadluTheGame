using UnityEngine;

public class ConditionHandlerWrapper : MonoBehaviour, IConditionHandler
{
    public GameObject conditionHandlerObject;

    public int StartConditionHandle()
    {
        // Проверка на наличие компонента на объекте и вызов метода
        if (conditionHandlerObject != null)
        {
            var handler = conditionHandlerObject.GetComponent<IConditionHandler>();
            if (handler != null)
            {
                return handler.StartConditionHandle();
            }
        }

        // Возвращаем значение по умолчанию или обработку ошибки
        return -1;
    }
}
