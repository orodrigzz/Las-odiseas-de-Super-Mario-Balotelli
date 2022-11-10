using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class InputManager : MonoBehaviour
{
    private Player_Inputs playerInputs;
    public static InputManager _INPUT_MANAGER;

    private float timeSinceJumpPressed = 0f;
    public Vector2 leftAxisValue = Vector2.zero;

    public float timeSinceThrowCappy;

    private void Awake()
    {
        if (_INPUT_MANAGER != null && _INPUT_MANAGER != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            playerInputs = new Player_Inputs();
            playerInputs.Player.Enable();

            playerInputs.Player.Jump.performed += JumpButtonPressed;
            playerInputs.Player.Move.performed += LeftAxisUpdate;

            playerInputs.Player.ThrowCappy.performed += ThrowButtonPressed;

            _INPUT_MANAGER = this;
            DontDestroyOnLoad(this);
        }
    }

    private void Update()
    {
        timeSinceJumpPressed += Time.deltaTime;
        timeSinceThrowCappy += Time.deltaTime;

        InputSystem.Update();
    }

    private void LeftAxisUpdate(InputAction.CallbackContext context)
    {
        leftAxisValue = context.ReadValue<Vector2>();
    }

    ///

    public void JumpButtonPressed(InputAction.CallbackContext context)
    {
        timeSinceJumpPressed = 0f;
    }

    public bool GetSouthButtonPressed()
    {
        return this.timeSinceJumpPressed == 0f;
    }

    public float TimeSinceSouthButtonPressed()
    {
        return this.timeSinceJumpPressed;
    }

    ///
   
    public void ThrowButtonPressed(InputAction.CallbackContext context)
    {
        timeSinceThrowCappy = 0f;
    }

    public bool GetThrowButtonPressed()
    {
        return this.timeSinceThrowCappy == 0f;
    }

    public float TimeSinceThrowPressed()
    {
        return this.timeSinceThrowCappy;
    }
}