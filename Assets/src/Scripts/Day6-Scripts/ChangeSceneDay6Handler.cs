using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneDay6Handler : MonoBehaviour, IConditionHandler
{
    public GameObject conditionHandlerObject;

    public int StartConditionHandle()
    {
        if (!GameManager.Instance.GetSomeThingsListValue("DeclineNeforsFive")) // ���� ������� �������
        {
            SceneManager.LoadScene(20);
        }
        else // ���� ����������
        {
            SceneManager.LoadScene(21);
        }

        // ���������� �������� �� ��������� ��� ��������� ������
        return -1;
    }
}
