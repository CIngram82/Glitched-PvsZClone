﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class Lizard : MonoBehaviour
{
    private Attacker attackerCS;
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        attackerCS = gameObject.GetComponent<Attacker>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;

        if (!obj.GetComponent<Defender>())
        {
            return;
        }

        if (obj.GetComponent<Defender>())
        {
            anim.SetBool("isAttacking", true);
            attackerCS.Attack(obj);
        }


    }
}
