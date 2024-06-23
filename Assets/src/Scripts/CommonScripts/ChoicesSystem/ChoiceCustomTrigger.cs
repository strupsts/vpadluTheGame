using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceCustomTrigger : MonoBehaviour, ICustomTrigger
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ICustomTrigger.Trigger()
    {
        Debug.Log("Работает");
    }
}
