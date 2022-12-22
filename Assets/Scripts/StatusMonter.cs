using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusMonter: MonoBehaviour
{
    public int HP = 1000;
    public int Attack = 100;
    public GameObject a;
    public Reward reward;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        reward = GetComponent<Reward>();
    }

    public void IsDamge(int damge)
    {
        animator.Play("Hurt");
        HP -= damge;
    }

    private void Update()
    {
        if (HP < 0)
        {
            animator.Play("Dying");
            StartCoroutine(InitialiseAttack());
            this.gameObject.SetActive(false);
            reward.DropItem();
            
        }
    }

    IEnumerator InitialiseAttack()
    {
        yield return new WaitForSeconds(0.1f);
    }
}
