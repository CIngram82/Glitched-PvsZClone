using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {
    public GameObject projectile, projectileSpawnPoint;
    private GameObject projectileParent;
    private Animator animator;
    private Spawner mySpawner;

    private void Start()
    {
        animator = GetComponent<Animator>();
        projectileParent = GameObject.Find("projectileParent");
        if (!projectileParent)projectileParent = new GameObject("projectileParent");

        SetMyLaneSpawner();
    }
    private void Fire()
    {
        GameObject newProjectile = Instantiate(projectile);
        newProjectile.transform.position = projectileSpawnPoint.transform.position;
        newProjectile.transform.parent = projectileParent.transform;
    }
    private void Update()
    {
        if (IsAttackerAheadInLane())
        {
            animator.SetBool("isAttacking", true);
        } else
        {
            animator.SetBool("isAttacking", false);
        }
        
    }
    private bool IsAttackerAheadInLane()
    {
        if (mySpawner.transform.childCount <= 0)
        {
            return false;
        }
        foreach(Transform thisAttacker in mySpawner.transform)
        {
            if(thisAttacker.transform.position.x >= transform.position.x)
            {
                return true;
            }
        }
        return false;
    }
    void SetMyLaneSpawner()
    {
        Spawner[] spawners = FindObjectsOfType<Spawner>();
        foreach(Spawner thisSpawner in spawners)
        {
            if (thisSpawner.transform.position.y == transform.position.y)
            {
                mySpawner = thisSpawner;
                return;
            }

        }
        Debug.LogError(name + " can't find spawner in lane");
    }
}
