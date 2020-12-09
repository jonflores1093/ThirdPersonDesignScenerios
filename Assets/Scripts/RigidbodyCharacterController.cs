using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RigidbodyCharacterController : MonoBehaviour
{
    [SerializeField]
    private float accerlationForce = 10;

    [SerializeField]
    private float maxSpeed = 2;

    [SerializeField]
    [Range(0,1)]
    [Tooltip("Speed at which the player turns. 0 = no turning, 1 = instant snap turning")]
    private float turnSpeed = 0.1f;

    [SerializeField]
    private PhysicMaterial stoppingPhysicsMaterial, movingPhysicsMaterial;


    private new Rigidbody rigidbody;
    private Vector2 input;
    private new Collider collider;
    

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
    }

    private void FixedUpdate()
    {
        Vector3 cameraRelativeInputDirection = GetCameraRelativeInputDirection();
        UpdatePhysicsMaterial();
        Move(cameraRelativeInputDirection);
        RotateToFaceMoveInputDirection(cameraRelativeInputDirection);

    }



    /// <summary>
    /// Turn the character too face the direction it wants to move in
    /// </summary>
    /// <param name="cameraRelativeInputDirection">The direction is trying to move in.</param>
    private void RotateToFaceMoveInputDirection(Vector3 cameraRelativeInputDirection)
    {
        if (cameraRelativeInputDirection.magnitude > 0)
        {
            var targetRotation = Quaternion.LookRotation(cameraRelativeInputDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, turnSpeed);


        }
    }

    /// <summary>
    /// Moves the player in a direction based on its max speed and acceleration
    /// </summary>
    /// <param name="moveDirection">The direction to move in</param>
    private void Move(Vector3 moveDirection)
    {
        if (rigidbody.velocity.magnitude < maxSpeed)
        {

            rigidbody.AddForce(moveDirection * accerlationForce, ForceMode.Acceleration);

        }
    }

    /// <summary>
    /// Update physics material to a low friction option if the player is trying to move,
    /// or higher friction option if they are trying to stop.
    /// </summary>
    private void UpdatePhysicsMaterial()
    {
        collider.material = input.magnitude > 0 ? movingPhysicsMaterial : stoppingPhysicsMaterial;
    }

    /// <summary>
    /// Uses the input vector to create a camera relative version
    /// so the player can move based on the camera's forward.
    /// </summary>
    /// <returns>Returns the camera relative input direction</returns>
    private Vector3 GetCameraRelativeInputDirection()
    {
        var inputDirection = new Vector3(input.x, 0, input.y);

        Vector3 cameraFlattenForward = Camera.main.transform.forward;
        cameraFlattenForward.y = 0;
        var cameraRotation = Quaternion.LookRotation(cameraFlattenForward);

        Vector3 cameraRelativeInputDirection = cameraRotation * inputDirection;
        return cameraRelativeInputDirection;
    }

    /// <summary>
    /// This event handler is called fromo the PlayerInput component
    /// using the new Input system.
    /// </summary>
    /// <param name="context">Vector 2 representing move input.</param>
    public void OnMove(InputAction.CallbackContext context)
    {

        input = context.ReadValue<Vector2>();


    }

  
}
