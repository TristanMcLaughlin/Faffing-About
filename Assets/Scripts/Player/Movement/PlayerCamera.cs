using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform PlayerBody;
    [SerializeField] private float Sensitivity;

    // Update is called once per frame
    void Update()
    {
        transform.position = PlayerBody.position;

        transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0f));
        float rotationX = Mathf.Clamp(transform.eulerAngles.x, 15F, 50F);
        transform.rotation = Quaternion.Euler(rotationX, transform.eulerAngles.y, 0f);

    }
}
