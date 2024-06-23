using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomethingExistCustomScript : MonoBehaviour, ICustomTrigger
{
    public string something;


    public void Trigger()
    {
        GameManager.Instance.SetSomeThingsListValue(something, true);
        Debug.Log($"{something} теперь существует!");
    }
}