using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringCollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "lime")
        {
            InputHandler4.numberMultiColourCross += 1;
            Debug.Log("collide");
        }
    }
}
