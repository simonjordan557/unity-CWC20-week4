﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    public SpawnManager spawnManager;
    
    private Rigidbody enemyRb;
    public float speed = 3.0f;
    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>(); ;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        velocity = (player.transform.position - transform.position).normalized * speed * Time.deltaTime;
        enemyRb.AddForce(velocity);
        
        if (transform.position.y < -10)
        {
            spawnManager.enemyCounter--;
            Destroy(gameObject);
        }
        
    }
}
