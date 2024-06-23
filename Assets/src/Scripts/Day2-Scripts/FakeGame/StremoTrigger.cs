using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StremoTrigger : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.tag == "stremo")
        {
            Debug.Log("¡Àﬂ œ»«ƒ¿!!!!");
        }
    }
}
