using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    private StatusMonter statusMonter;


    private void Start()
    {
        statusMonter = GetComponentInParent<StatusMonter>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
           CharacterStatus player = collision.gameObject.GetComponentInParent<CharacterStatus>();
           player.IsDamge(statusMonter.Attack);
        }
    }
}
