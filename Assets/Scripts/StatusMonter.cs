using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusMonter: MonoBehaviour
{
    public int HP = 1000;
    public int Attack = 100;
    public GameObject a;
    Animator animator;
    public Status player;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void IsDamge(int damge)
    {
        //animator.Play("Hurt");
        HP -= damge;
    }

    private void Update()
    {
        if (HP < 0)
        {
            //animator.Play("Dying"); 
            StartCoroutine(InitialiseAttack());
            this.gameObject.SetActive(false);
            player.Attack += 5;
            player.HP_Max += 50;
            player.HP += 50;
            player.Defend_Physic += 50;
        }
    }

    IEnumerator InitialiseAttack()
    {
        yield return new WaitForSeconds(0.5f);
    }
}
