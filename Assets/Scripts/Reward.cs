using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Reward : MonoBehaviour
{
    public Caterory caterorysword;
    public Caterory cateroryPotion;
    System.Random rand;


    private void Start()
    {
        rand = new System.Random();
    }

    public void DropItem()
    {
        int index = rand.Next(0, caterorysword.items.Count);
        GameObject newItem = Instantiate(caterorysword.gameItem);
        newItem.transform.position = this.transform.position;
        SpriteRenderer sprite = newItem.GetComponent<SpriteRenderer>();
        sprite.sprite = caterorysword.items[index].sprite;
        PolygonCollider2D polygon = newItem.AddComponent<PolygonCollider2D>();
        PolygonCollider2D polygon1 = newItem.AddComponent<PolygonCollider2D>();
        polygon.isTrigger = true;

    }
}
