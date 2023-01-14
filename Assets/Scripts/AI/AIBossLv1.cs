using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBossLv1 : MonoBehaviour
{
    Animator animator;
    float rt;
    float ra;
    bool ModFly;
    PolygonCollider2D polygon;
    CircleCollider2D circle;
    public GameObject fire;
    Vector3 atDir = Vector3.zero;
    GameObject player;
    bool isAttack;
    // Start is called before the first frame update
    private void Awake()
    {
        isAttack = false;
        circle = GetComponent<CircleCollider2D>();
        polygon = GetComponent<PolygonCollider2D>();
        ModFly = false;
        rt = 0;
        ra = 0;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rt += 0.1f;
        ra += 0.1f;
        if (rt > 100)
        {
            rt = 0;
            ModFly = !ModFly;
        }
        if (ra > 30 && isAttack)
        {
            ra = 0;
            attack();
        }

        if (ModFly)
        {
            animator.SetBool("ModFly", true);

        }
        else if (!ModFly)
        {
            animator.SetBool("ModFly", false);
        }
    }

    void attack()
    {
        animator.Play("Attack");
        GameObject ar = Instantiate(fire);
        FGFly a = ar.GetComponent<FGFly>();
        a.Create(this.gameObject, player);
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player = collision.GetComponentInParent<BoxCollider2D>().gameObject;
            isAttack = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isAttack = false;
        }
    }
}
