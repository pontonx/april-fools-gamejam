using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform playerCamera;
    [SerializeField] private Rigidbody playerBody;

    [SerializeField] private float speed;
    [SerializeField] private float sensitivity;

    [SerializeField] private float stepInterval = 0.5f;
    private float stepTimer = 0f;

    private Vector3 playerMovementInput;
    private Vector2 mouseInput;
    private float xRot;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if(DialogueSystem.instance.isDialogueActive)
        {
            playerMovementInput = Vector3.zero;
            playerBody.velocity = Vector3.zero;
            return;
        }

        playerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        if (playerMovementInput.magnitude > 1)
        {
            playerMovementInput.Normalize();
        }

        if(playerBody.velocity.magnitude > 0.1f)
        {
            stepTimer += Time.deltaTime;
            if (stepTimer >= stepInterval)
            {
                AudioManager.instance.Play("step", Random.Range(0.8f, 1.2f));
                stepTimer = 0f;
            }
            else if (playerBody.velocity.magnitude < 0.1f) 
            {
                stepTimer = 0f;
            }
        }

        mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        MovePlayer();
        MoveCamera();
    }
    private void MovePlayer()
    {
        Vector3 MoveVector = transform.TransformDirection(playerMovementInput) * speed;
        playerBody.velocity = new Vector3(MoveVector.x, playerBody.velocity.y, MoveVector.z);
    }

    private void MoveCamera()
    {
        xRot -= mouseInput.y * sensitivity;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        transform.Rotate(0f, mouseInput.x * sensitivity, 0f);
        playerCamera.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);

    }
}
