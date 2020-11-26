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
        var inputDirection = new Vector3(input.x, 0, input.y);
        Vector3 cameraFlattenForward = Camera.main.transform.forward;
        cameraFlattenForward.y = 0;
        var cameraRotation = Quaternion.LookRotation(cameraFlattenForward);

        Vector3 cameraRelativeInputDirection = cameraRotation * inputDirection;


        collider.material = inputDirection.magnitude > 0 ? movingPhysicsMaterial : stoppingPhysicsMaterial;

        //if (inputDirection.magnitude > 0)
        //{

        //    collider.material = movingPhysicsMaterial;
        //}

        //else
        //{
        //    collider.material = stoppingPhysicsMaterial;

        //}


        if (rigidbody.velocity.magnitude < maxSpeed)
        {

            rigidbody.AddForce(cameraRelativeInputDirection * accerlationForce, ForceMode.Acceleration);

        }

        if (cameraRelativeInputDirection.magnitude > 0)
        {
            var targetRotation = Quaternion.LookRotation(cameraRelativeInputDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, turnSpeed);


        }




    }

    public void OnMove(InputAction.CallbackContext context)
    {

        input = context.ReadValue<Vector2>();


    }

  
}
