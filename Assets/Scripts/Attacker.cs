using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {

    private GameObject currentTarget;
    private Animator anim;
    private float currentSpeed, damage;
    [Tooltip ("Average number of seconds between appearances")]
    public float seenEverySeconds;


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
