using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private CharacterStatus characterStatus;


    private void Start()
    {
        characterStatus = GetComponentInParent<CharacterStatus>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Monster")
        {
            StatusMonter monster = collision.gameObject.GetComponentInParent<StatusMonter>();
            monster.IsDamge(characterStatus.status.Attack);
        }
    }
}
