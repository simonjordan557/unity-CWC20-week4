using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Vector3 velocity;
    public string verticalInputMethod;
    private float verticalInput;
    private Rigidbody playerRb;
    private GameObject focalPoint;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        verticalInputMethod = "Vertical";
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis(verticalInputMethod);
        velocity = focalPoint.transform.forward * verticalInput * speed * Time.deltaTime;
        playerRb.AddForce(velocity);
    }
}
