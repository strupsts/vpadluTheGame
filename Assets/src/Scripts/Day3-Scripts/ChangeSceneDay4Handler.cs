using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneDay4Handler : MonoBehaviour, IConditionHandler
{
    public GameObject conditionHandlerObject;

    public int StartConditionHandle()
    {
        if (!GameManager.Instance.GetSomeThingsListValue("DeclineNeforsTwo")) // ���� ������� �������
        {
            SceneManager.LoadScene(10);
        }
        else // ���� ����������
        {
            SceneManager.LoadScene(11);
        }

        // ���������� �������� �� ��������� ��� ��������� ������
        return -1;
    }
}
