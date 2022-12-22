using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    public Status status;
    Animator animator;
    public SpriteRenderer mainsword;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void IsDamge(int damge)
    {
        animator.Play("Hurt");
        status.HP -= damge;
    }


    private void Update()
    {
        if (status.HP < 0)
        {
            animator.Play("Dying");
            StartCoroutine(InitialiseAttack());
            this.gameObject.SetActive(false);
        }
    }

    IEnumerator InitialiseAttack()
    {
        yield return new WaitForSeconds(0.1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "WeaponItem")
        {
            
            SpriteRenderer sworditem = collision.gameObject.GetComponent<SpriteRenderer>();
            mainsword.sprite = sworditem.sprite;
            status.Attack += 10;
            collision.gameObject.SetActive(false);
        }
    }
}
