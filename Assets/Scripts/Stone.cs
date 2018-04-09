using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.GetComponent<Attacker>() != null)
        {
            animator.SetTrigger("underAttack");
        }
    }
}
