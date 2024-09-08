using UnityEngine;
using UnityEngine.SceneManagement;

public class NeforsSceneChangeSceneScript : MonoBehaviour, IConditionHandler
{
    /*public GameObject conditionHandlerObject;*/

    public int StartConditionHandle()
    {


        int currentScene = GameManager.currentScene;   

        switch (currentScene)
        {
            case 5:
                SceneManager.LoadScene(8);
                break;
            case 9:
                SceneManager.LoadScene(12);
                break;
            case 13:
                SceneManager.LoadScene(16);
                break;
            case 19:
                SceneManager.LoadScene(22);
                break;
            default:
                Debug.Log($"������!! {currentScene}");
                GameManager.Instance.notifyItemHandler(false, "������ ����� �������", null, true);
                SceneManager.LoadScene(0);
                break;

        }

        // ���������� �������� �� ��������� ��� ��������� ������
        return -1;
    }
}
