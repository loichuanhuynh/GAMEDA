using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AIMeleeCreep : MonoBehaviour
{
    public GameObject monster;
    private Rigidbody2D r2d;
    private bool is_jump;

    private void Start()
    {
        r2d = GetComponentInParent<Rigidbody2D>();
        r2d.freezeRotation = true;
        is_jump = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Vector2 dir = new Vector2(1, 5);
            if (collision.transform.position.x < monster.transform.position.x)
            {
                monster.transform.localScale = new Vector3(-monster.transform.localScale.y, monster.transform.localScale.y, monster.transform.localScale.z);
                dir.x = -1;
            }
            else
                monster.transform.localScale = new Vector3(monster.transform.localScale.y, monster.transform.localScale.y, monster.transform.localScale.z);
            if (collision.transform.position.y < monster.transform.position.y)
                dir.y = -5;
            if (is_jump)
                dir.y = -1;
            r2d.velocity = dir;
        }
        if (collision.tag == "Ground")
            is_jump = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ground")
            is_jump = true;
    }
}
