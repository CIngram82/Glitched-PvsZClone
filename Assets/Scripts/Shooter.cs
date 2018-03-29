using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {
    public GameObject projectile, projectileParent, projectileSpawnPoint;

    private void Fire()
    {
        GameObject newProjectile = Instantiate(projectile);
        newProjectile.transform.position = projectileSpawnPoint.transform.position;
        newProjectile.transform.parent = projectileParent.transform;
      

    }


}
