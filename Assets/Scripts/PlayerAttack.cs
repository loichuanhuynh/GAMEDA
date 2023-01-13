using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private CharacterStatus characterStatus;
    private Animator animator;

    bool attack;
    StatusMonter monster;

    private void Start()
    {
        attack = false;
        animator = GetComponentInParent<Animator>();
        characterStatus = GetComponentInParent<CharacterStatus>();
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            attack = true;
            
        }
        else
        {
            attack = false;
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Monster")
        {
            attack = false;
            monster = collision.gameObject.GetComponentInParent<StatusMonter>();
            
        }
    }


    private void LateUpdate()
    {
        if (attack)
        {
            animator.SetBool("Slash", true);
            if (monster)
            {
                monster.IsDamge(characterStatus.status.Attack);
                monster = null;
            }
        }
        else animator.SetBool("Slash", false);
    }
}
