using UnityEngine;

public class ConditionHandlerWrapper : MonoBehaviour, IConditionHandler
{
    public GameObject conditionHandlerObject;

    public int StartConditionHandle()
    {
        // �������� �� ������� ���������� �� ������� � ����� ������
        if (conditionHandlerObject != null)
        {
            var handler = conditionHandlerObject.GetComponent<IConditionHandler>();
            if (handler != null)
            {
                return handler.StartConditionHandle();
            }
        }

        // ���������� �������� �� ��������� ��� ��������� ������
        return -1;
    }
}
