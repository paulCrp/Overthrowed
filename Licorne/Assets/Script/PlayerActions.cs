using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script moves the character controller forward and backward
/// </summary>
public class PlayerActions : MonoBehaviour
{
    CharacterController characterController;

    public float distance = 0.7f;
    public GameObject MyCamera;
    public float gravity = 20.0f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 moveDirection = new Vector3();
        if (characterController.isGrounded)
            moveDirection = MyCamera.transform.forward * distance;
        moveDirection.y -= gravity * Time.deltaTime;
        //Forward
        if (Input.GetKey("up")) characterController.Move(moveDirection * Time.deltaTime);
        //Backward
        if (Input.GetKey("down")) characterController.Move(moveDirection * Time.deltaTime);
    }
}
