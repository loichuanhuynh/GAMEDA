using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AIMeleeCreep : MonoBehaviour
{
    public GameObject monster;
    private Rigidbody2D r2d;

    Vector2 dir;
    public bool isPause;
    public bool isTrigger;
    public bool isRight;
    private float positionX;


    public float limitRadis = 2f;

    private void Start()
    {
        isRight = true;
        isPause = false;
        dir = Vector2.zero;
        positionX = monster.transform.position.x;
        r2d = GetComponentInParent<Rigidbody2D>();
        r2d.freezeRotation = true;
    }

    private void Update()
    {
        
        if ((Math.Abs(positionX - monster.transform.position.x) > limitRadis) && isTrigger)
        {
            isPause = true;
        }
        else isPause = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isTrigger = true;
            dir.x = 1;
            if (collision.transform.position.x < monster.transform.position.x)
            {
                monster.transform.localScale = new Vector3(-monster.transform.localScale.y, monster.transform.localScale.y, monster.transform.localScale.z);
                dir.x = -1;
            }
            else
                monster.transform.localScale = new Vector3(monster.transform.localScale.y, monster.transform.localScale.y, monster.transform.localScale.z);
            
        }
        else isTrigger = false;
    }

    private void FixedUpdate()
    {
        if (!isPause)
        {
            if (isTrigger)
            {
                r2d.velocity = dir;
                dir.x = 0;
            }
            else moveFreely();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            isTrigger = false;

    }

    private void moveFreely()
    {
        if (positionX - limitRadis > monster.transform.position.x) 
        {
            isRight = true;
            
        }
        else if (positionX + limitRadis < monster.transform.position.x)
        {

            isRight = false;
            
        }
        
        if (isRight)
        {
            dir.x = 1;
            monster.transform.localScale = new Vector3(monster.transform.localScale.y, monster.transform.localScale.y, monster.transform.localScale.z);
            r2d.velocity = dir; 
        }
        else
        {
            dir.x = -1;
            r2d.velocity = dir;
            monster.transform.localScale = new Vector3(-monster.transform.localScale.y, monster.transform.localScale.y, monster.transform.localScale.z);
        }

    }    
}
