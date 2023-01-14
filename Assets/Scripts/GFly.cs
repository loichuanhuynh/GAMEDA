using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GFly : MonoBehaviour
{
    Vector3 dir;
    Rigidbody2D r2d;
    StatusMonter monster;
    int damge;
    // Start is called before the first frame update

    private void Awake()
    {
        damge = 0;
        dir = Vector3.zero;
        dir.x = 0.01f;
        r2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = (transform.position + dir);
    }

    public void Create(GameObject g, int d)
    {
        transform.position = new Vector3(g.transform.position.x + g.transform.localScale.x, g.transform.position.y + 0.35f, g.transform.position.z);
        damge = d;
        dir.x = 0.12f * g.transform.localScale.x;

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CharacterStatus player = collision.gameObject.GetComponentInParent<CharacterStatus>();
            player.IsDamge(damge);
            Destroy(this.gameObject);
        }
        else if (collision.tag == "Ground")
            Destroy(this.gameObject);
    }
}
