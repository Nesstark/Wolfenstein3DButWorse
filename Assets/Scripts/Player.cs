using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 150f;
    public float gravity = -9.81f;
    public Transform cameraTransform;
    private CharacterController controller;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Player movement (forward/backward)
        float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        Vector3 move = transform.forward * moveZ;

        // Apply gravity
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }
        velocity.y += gravity * Time.deltaTime;
        move.y = velocity.y;

        // Move the player
        controller.Move(move);

        // Player rotation (left/right)
        float rotateY = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, rotateY, 0);

        // Shooting with Left Ctrl
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Shoot();
        }

        // Interaction with Spacebar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Interact();
        }
    }

    void Shoot()
    {
        // Placeholder for shooting logic
        Debug.Log("Bang! Shooting action triggered.");
    }

    void Interact()
    {
        // Placeholder for interaction logic
        Debug.Log("Interacted with object.");
    }
}
