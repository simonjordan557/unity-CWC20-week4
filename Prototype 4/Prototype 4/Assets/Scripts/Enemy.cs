using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    
    private Rigidbody enemyRb;
    public float speed = 3.0f;
    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        velocity = (player.transform.position - transform.position).normalized * speed * Time.deltaTime;
        enemyRb.AddForce(velocity);
        
    }
}
