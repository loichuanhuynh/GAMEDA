using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMeleeCreepAttack : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponentInParent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            animator.Play("Attacking");
        }
    }
}
