using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Movement movement; 
    private Animator animator; 
    private void Awake()
    {
        movement = GetComponent<Movement>();
        animator = GetComponent<Animator>(); 
    }

    private void Update() { 
       animator.SetFloat("speed", movement.GetCurrentSpeed());

       //animator.SetBool("isJumping", movement.isJumping());
    }

}          