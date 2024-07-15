using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneDay5Handler : MonoBehaviour, IConditionHandler
{
    public GameObject conditionHandlerObject;

    public int StartConditionHandle()
    {
        if (!GameManager.Instance.GetSomeThingsListValue("DeclineNeforsThree")) // ���� ������� �������
        {
            SceneManager.LoadScene(14);
        }
        else // ���� ����������
        {
            SceneManager.LoadScene(15);
        }

        // ���������� �������� �� ��������� ��� ��������� ������
        return -1;
    }
}
