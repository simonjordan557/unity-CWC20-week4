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
    public GameObject powerUpIndicator;
    private GameObject focalPoint;
    private bool hasPowerUp = false;
    private float powerUpStrength = 25.0f;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis(verticalInputMethod);
        velocity = focalPoint.transform.forward * verticalInput * speed * Time.deltaTime;
        playerRb.AddForce(velocity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            powerUpIndicator.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountdownRoutine());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp == true)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            enemyRb.AddForce((collision.gameObject.transform.position - transform.position).normalized * powerUpStrength, ForceMode.Impulse);
        }
    }

    IEnumerator PowerUpCountdownRoutine()
    {
        
        yield return new WaitForSeconds(5);
        hasPowerUp = false;
        powerUpIndicator.SetActive(false);

    }
}
