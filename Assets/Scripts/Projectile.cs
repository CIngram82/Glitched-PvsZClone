using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;
    public float damage;
	
	void Update () {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;

        if (!obj.GetComponent<Attacker>())
        {
            return;
        }

        if (obj.GetComponent<Attacker>())
        {
            Health targetHealth =  collision.GetComponent<Health>();
            targetHealth.TakeDamage(damage);
            DestroySelf();
        }
    }
    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
