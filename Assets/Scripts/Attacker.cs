using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {

    private GameObject currentTarget;
    private Animator anim;
    private float currentSpeed;
    private float damage;


    void Start ()
    {
        anim = GetComponent<Animator>();
	}
	void Update ()
    {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        if(!currentTarget)
        {
            anim.SetBool("isAttacking", false);
        }
	}
    public void SetCurrentSpeed(float speed)
    {
        currentSpeed = speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(name + "Trigger Enter");
    }

    public void StrikeCurrentTarget (float damage)
    {
        if (currentTarget)
        {
            Health targetHealth = currentTarget.GetComponent<Health>();
            if (targetHealth)
            {
                targetHealth.TakeDamage(damage);
            }
        }
    }
    public void Attack(GameObject obj)
    {
        currentTarget = obj;
    }
}
