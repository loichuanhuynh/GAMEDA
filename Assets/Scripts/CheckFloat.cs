using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFloat : MonoBehaviour
{
    public Check check;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
            check.isGround = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
            check.isGround = true;
    }
}
