using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Player player; 
    private Animator animator; 

    private void Awake()
    {
        player = GetComponent<Player>();
        animator = GetComponent<Animator>(); 
    }

    private void Update() 
    { 
       animator.SetFloat("speed", player.GetCurrentSpeed());

       animator.SetBool("isJumping", player.Jumping());
       
       animator.SetBool("isCrouching", player.GetCrouch());

        //animator.SetFloat("HasJumped", InputManager._INPUT_MANAGER.TimeSinceSouthButtonPressed());

        //animator.SetFloat("Crouch", _player.GetCrouch());
    }
}          