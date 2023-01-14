using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRangeCreepAttack : MonoBehaviour
{
    float ra;
    public GameObject fire;
    bool isAttack;
    // Start is called before the first frame update
    private void Awake()
    {
        isAttack = false;
        ra = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ra += 0.1f;
        if (ra > 30 && isAttack)
        {
            ra = 0;
            attack();
        }
    }

    void attack()
    {
        GameObject ar = Instantiate(fire);
        GFly a = ar.GetComponent<GFly>();
        a.Create(this.gameObject, 10);

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
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
