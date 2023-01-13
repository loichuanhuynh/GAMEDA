using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangeAttack : MonoBehaviour
{
    private CharacterStatus characterStatus;
    private Animator animator;
    public GameObject arrow;

    bool attack;


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


    private void LateUpdate()
    {
        if (attack)
        {
            animator.SetBool("Slash", true);
            GameObject ar = Instantiate(arrow);
            AGFly a = ar.GetComponent<AGFly>();
            BoxCollider2D b = GetComponentInParent<BoxCollider2D>();
            a.Create(b.gameObject, characterStatus.status.Attack);
            
        }
        else animator.SetBool("Slash", false);
    }
}
