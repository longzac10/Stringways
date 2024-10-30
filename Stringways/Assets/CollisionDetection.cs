using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "pink")
        {
            InputHandler4.numberMultiColourCross += 1;
        }
    }
}
