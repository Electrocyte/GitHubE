using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 10f;
    [SerializeField] AudioClip pewPewSFX;
    [SerializeField] AudioClip wallHitSFX;
    [SerializeField] AudioClip enemyDieSFX;
    [SerializeField] AudioClip enemyDieSFX2;

    Rigidbody2D rb;
    PlayerMovement playerMovement;
    float xSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        xSpeed = playerMovement.transform.localScale.x * bulletSpeed;
        AudioSource.PlayClipAtPoint(pewPewSFX, Camera.main.transform.position, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(xSpeed, 0f);
    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.tag == "Enemy") {
            AudioSource.PlayClipAtPoint(enemyDieSFX, Camera.main.transform.position);
            Destroy(other.gameObject);
        }

        if (other.tag == "EnemyOrange") {
            AudioSource.PlayClipAtPoint(enemyDieSFX2, Camera.main.transform.position);
            Destroy(other.gameObject);
        }

        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        AudioSource.PlayClipAtPoint(wallHitSFX, Camera.main.transform.position, 0.05f);
        Destroy(gameObject);
    }
}
