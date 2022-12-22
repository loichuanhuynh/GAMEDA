using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsDamgePlayer : MonoBehaviour
{
    public bool damge;

    private void Start()
    {
        damge = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MonsterWeapon")
            damge = true;
    }
}
