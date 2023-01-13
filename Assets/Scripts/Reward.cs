using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Reward : MonoBehaviour
{
    Animator animator;
    public Caterory caterorysword;
    public Caterory cateroryPotion;
    public Caterory cateroryShield;
    public Caterory cateroryBow;
    public Caterory cateroryArmor;
    System.Random rand;

    private Caterory temp;
    bool isOpen;
    bool isDrop;
    private void Start()
    {
        isDrop = false;
        animator = GetComponent<Animator>();
        isOpen = false;
        rand = new System.Random();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isOpen = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isOpen && !isDrop)
        {
            isDrop = true;
            animator.SetBool("IsOpen", true);
            DropItem();
        }
    }

    public void DropItem()
    {
        int i = rand.Next(0, 5);
        if (i == 0)
            temp = caterorysword;
        else if (i == 1)
            temp = cateroryPotion;
        else if (i == 2)
            temp = cateroryShield;
        else if (i == 3)
            temp = cateroryBow;
        else temp = cateroryArmor;
        int index = rand.Next(0, temp.items.Count);
        GameObject newItem = Instantiate(temp.gameItem);
        newItem.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        SpriteRenderer sprite = newItem.GetComponent<SpriteRenderer>();
        sprite.sprite = temp.items[index].sprite;
        PolygonCollider2D polygon = newItem.AddComponent<PolygonCollider2D>();
        PolygonCollider2D polygon1 = newItem.AddComponent<PolygonCollider2D>();
        polygon.isTrigger = true;

    }
}
