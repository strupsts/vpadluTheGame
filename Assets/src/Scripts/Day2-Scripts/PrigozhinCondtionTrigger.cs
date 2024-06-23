using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrigozhinCondtionTrigger : MonoBehaviour, IConditionHandler
{
   public int timeBeforeMoveToMainMenu;
   public int StartConditionHandle()
    {
        loadMenu();
        return 0;
    }

    private async void loadMenu()
    {
        await Task.Delay(timeBeforeMoveToMainMenu);
        SceneManager.LoadScene(0);
    }
}
