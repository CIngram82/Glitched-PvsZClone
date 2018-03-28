﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    public float health;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            DestroyObject();
        }
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
