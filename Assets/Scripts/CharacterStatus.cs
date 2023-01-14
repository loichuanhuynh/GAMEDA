using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    public Status status;
    public Animator animator;
    public SpriteRenderer mainsword;
    public InventoryScripTable inv;


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
            status.HP = status.HP_Max;
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }

    IEnumerator InitialiseAttack()
    {
        yield return new WaitForSeconds(0.1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Drop Item")
        {
            ID id = collision.GetComponent<ID>();
            SpriteRenderer sworditem = collision.gameObject.GetComponent<SpriteRenderer>();
            Inventory t = new Inventory();
            Caterory a;
            if (id.id == 0)
                a = inv.sword;
            else if (id.id == 1)
                a = inv.potion;
            else if (id.id == 2)
                a = inv.Shield;
            else if (id.id == 3)
                a = inv.Bow;
            else a = inv.Armor;
            for (int i = 0; i < a.items.Count; i++)
            {
                if (a.items[i].sprite == sworditem.sprite)
                {
                    t.id_id = i;
                    t.sprite = sworditem.sprite;
                    break;
                }
            }
            t.id_caterory = id.id;
            inv.inventory.Add(t);
            Destroy(collision.gameObject);
        }
    }
}
