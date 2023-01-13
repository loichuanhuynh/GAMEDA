using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class FGFly : MonoBehaviour
{
    Vector3 dir;
    Rigidbody2D r2d;
    // Start is called before the first frame update

    private void Awake()
    {
        r2d = GetComponent<Rigidbody2D>();
        dir = Vector3.zero;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = (transform.position + dir);
    }

    public void Create(GameObject g, GameObject pl)
    {
        transform.position = new Vector3(g.transform.position.x + 0.5f * 5f * g.transform.localScale.x, g.transform.position.y, g.transform.position.z);
        dir = new Vector3(check(g.transform.position.x - pl.transform.position.x), check(g.transform.position.y - pl.transform.position.y), pl.transform.position.z) * 0.01f;
        transform.localScale = g.transform.localScale;
    }

    float check( float a)
    {
        int t = (int)Math.Abs(a);
        float te = Math.Abs(a) - t;
        if (a > 0)
            return -1f * te;
        else return +1f* te;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CharacterStatus player = collision.gameObject.GetComponentInParent<CharacterStatus>();
            player.IsDamge(100);
            Destroy(this.gameObject);
        }
        else if (collision.tag == "Ground")
            Destroy(this.gameObject);

    }
}
