using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody PlayerBody;
    [SerializeField] private Transform CameraTransform;

    [SerializeField] private float Speed;
    [SerializeField] private float Sensitivity;
    [SerializeField] private float JumpForce;

    // Update is called once per frame
    void Update()
    {
        ProcessControllerMovement();
    }

    //private void Lateupdate()
    //{
    //    Vector3 RelativeRotation = Vector3.Lerp();
    //}

    private void ProcessControllerMovement() 
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 CameraForward = CameraTransform.forward;
        Vector3 CameraRight = CameraTransform.right;

        CameraForward.y = 0f;
        CameraRight.y = 0f;

        Vector3 ForwardRelative = v * CameraForward;
        Vector3 RightRelative = h * CameraRight;

        Vector3 RelativeMoveDirection = ForwardRelative + RightRelative;

        Vector3 MoveVector = new Vector3(RelativeMoveDirection.x, 0f, RelativeMoveDirection.z) * Speed;
        PlayerBody.velocity = new Vector3(MoveVector.x, PlayerBody.velocity.y, MoveVector.z);

        //// Rotate player over time according to speed until we are in the required rotation
        if (MoveVector != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(RelativeMoveDirection), Time.deltaTime * 5f);
        }

        if (Input.GetButtonDown("Jump"))
        {
            PlayerBody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
    }
}
