using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public string horizontalInputMethod;
    private float horizontalInput;
    public float rotationSpeed;
    private Vector3 rotationVelocity;

    // Start is called before the first frame update
    void Start()
    {
        horizontalInputMethod = "Horizontal";
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis(horizontalInputMethod);
        rotationVelocity = Vector3.up * rotationSpeed * horizontalInput * Time.deltaTime;

        transform.Rotate(rotationVelocity);
    }
}
