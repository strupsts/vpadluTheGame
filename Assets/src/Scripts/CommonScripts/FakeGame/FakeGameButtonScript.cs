using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FakeGameButtonScript: MonoBehaviour
{
    FakeGameScript GAME;

    void Start()
    {
        GAME = GameObject.Find("[FakeGame]").GetComponent<FakeGameScript>();
        
    }

    public void Click()
    {
        GAME.clickButton();
    }


   
}
   
