using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour {
    private Animator animator;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        animator.SetBool("isHover", true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
