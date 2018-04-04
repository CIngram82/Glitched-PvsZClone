using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {
    public GameObject projectile, projectileSpawnPoint;
    private GameObject projectileParent;

    private void Start()
    {
        projectileParent = GameObject.Find("projectileParent");

        if (!projectileParent)
        {
            projectileParent = new GameObject("projectileParent");
        }
    }
    private void Fire()
    {
        GameObject newProjectile = Instantiate(projectile);
        newProjectile.transform.position = projectileSpawnPoint.transform.position;
        newProjectile.transform.parent = projectileParent.transform;
    }
    private void Update()
    {
        if (isAttackerAheadInLane())
        {
            animator.SetBool("isAttacking", true);
        } else
        {
            animator.SetBool("isAttacking", false);
        }
    }
}
