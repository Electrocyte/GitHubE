using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float enemySpeed = 1f;
    Rigidbody2D enemyRigidbody2D;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyRigidbody2D.velocity = new Vector2(enemySpeed, 0f);
    }

    void OnTriggerExit2D(Collider2D other) {
        enemySpeed = -enemySpeed;
        FlipEnemyFacing();
    }

    private void FlipEnemyFacing()
    {
        transform.localScale = new Vector2 (-(Mathf.Sign(enemyRigidbody2D.velocity.x)), 1f);
    }
}
