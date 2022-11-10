using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private CharacterController controller;

    private Vector3 finalVelocity = Vector3.zero;
    private float velocityXZ = 5f;
    public float currentspeed = 0f;
    private Vector3 jump;

    [SerializeField]
    Camera camera;

    private float gravity = 20f;

    private float jumpForce = 10f;

    private bool isJumping;
    private bool isCrouching;

    [SerializeField]
    private int estrellas = 0;

    public GameObject cappy;
    public Transform spawnCappy;
    public float cappyForce;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();

        jump = new Vector3(0, 2.0f, 0);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Quaternion.Euler(0f, camera.transform.eulerAngles.y, 0f) * new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        direction.Normalize();

        transform.rotation = Quaternion.Euler(0f, camera.transform.eulerAngles.y, 0f);
        finalVelocity.x = direction.x * velocityXZ;
        finalVelocity.z = direction.z * velocityXZ;

        direction.y = -1f;

        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                finalVelocity.y = jumpForce;
                isJumping = true;
            }
            else
            {
                isJumping = false;
                finalVelocity.y = direction.y * gravity * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.C))
            {
                isCrouching = true;
            }

            if (Input.GetKey(KeyCode.X))
            {
                isCrouching = false;
            }
        }
        else
        {
            finalVelocity.y += direction.y * gravity * Time.deltaTime;
        }

        currentspeed = new Vector3(finalVelocity.x, 0.0f, finalVelocity.z).magnitude;

        controller.Move(finalVelocity * Time.deltaTime);

        if (estrellas == 5)
        {
            SceneManager.LoadScene("Win");
        }

        if (InputManager._INPUT_MANAGER.GetThrowButtonPressed())
        {
            Instantiate(cappy, spawnCappy.position, spawnCappy.rotation);
        }
    }

    public float GetCurrentSpeed() { return currentspeed; }

    public bool GetCrouch() { return isCrouching; }

    public bool Jumping() { return isJumping; }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "MatarPlayer")
        {
            SceneManager.LoadScene("GameScene");
        }

        if (collision.gameObject.tag == "Estrella")
        {
            Destroy(collision.gameObject);
            estrellas++;
        }

        if (collision.gameObject.tag == "Frontera")
        {
            SceneManager.LoadScene("Dead");
        }

        if (collision.gameObject.tag == "Cappy")
        {

            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Rebote")
        {

        }

        if (collision.gameObject.tag == "Ground")
        {
            isJumping = false;
        }

        if (collision.gameObject.tag != "Ground")
        {
            isJumping = true;
        }
    }
}