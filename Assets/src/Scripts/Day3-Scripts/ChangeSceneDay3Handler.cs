using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneDay3Handler : MonoBehaviour, IConditionHandler
{
    /*public GameObject conditionHandlerObject;*/

    public int StartConditionHandle()
    {
        if (!GameManager.Instance.GetSomeThingsListValue("DeclineNeforsOne")) // ���� ������� �������
        {
            SceneManager.LoadScene(6);
        }
        else // ���� ����������
        {
            SceneManager.LoadScene(7);
        }

        // ���������� �������� �� ��������� ��� ��������� ������
        return -1;
    }
}
