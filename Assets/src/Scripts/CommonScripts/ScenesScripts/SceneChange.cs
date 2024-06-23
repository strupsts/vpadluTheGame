using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour, IConditionHandler
{
  
    public int numOfScene;

  
   

    public int StartConditionHandle()
    {
        SaveManager.SaveGame();

        SceneManager.LoadScene(numOfScene);
        return 0;
    }

   
}
    
   
