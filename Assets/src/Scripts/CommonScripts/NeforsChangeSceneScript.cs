using UnityEngine;
using UnityEngine.SceneManagement;

public class NeforsChangeSceneScript : MonoBehaviour, IConditionHandler
{
    /*public GameObject conditionHandlerObject;*/

    public string checkValue; // �������� ���������� � ������� ������� �������� �� ��������� ������ ������� (������ ��� ���-�� �� ��������)

    public byte SceneOfCompanyMember; // ID ����� ���� ������ �������� ����� ��������

    public int StartConditionHandle()
    {
        if (!GameManager.Instance.GetSomeThingsListValue(checkValue)) // ���� ������� �������
        {
            SceneManager.LoadScene(SceneOfCompanyMember);
        }
        else // ���� ����������
        {
            int companyRep = GameManager.Instance.GetReputationListValue("Company");
            
            switch (companyRep)
            {
                case 100:
                    SceneManager.LoadScene(7);
                    break;
                case 75:
                    SceneManager.LoadScene(11);
                    break;
                case 50:
                    SceneManager.LoadScene(15);
                    break;
                case 25:
                    SceneManager.LoadScene(21);
                    break;
                default:
                    SceneManager.LoadScene(0);
                    GameManager.Instance.notifyItemHandler(false, "��������� �������� ������", null, true);
                    break;
            }
        }

        // ���������� �������� �� ��������� ��� ��������� ������
        return -1;
    }
}
