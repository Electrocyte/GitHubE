using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] int increaseScore = 15;
    [SerializeField] int hitPoints = 2;
    ScoreBoard scoreBoard;
    GameObject parentGameObj;

    private void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        parentGameObj = GameObject.FindWithTag("Spawn At Runtime");
        AddRB();
    }

    private void AddRB()
    {
        var bridge = gameObject.tag == "GameController";

        if (bridge) {
            Debug.Log(gameObject.tag);
        } else {
            var rb = gameObject.AddComponent<Rigidbody>();
            rb.useGravity = false;
        }
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints < 1) {
            KillEnemy();
        }

    }

    private void KillEnemy()
    {
        scoreBoard.IncreaseScore(increaseScore);
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObj.transform;
        Destroy(gameObject);
    }

    private void ProcessHit()
    {
        GameObject hitVfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        hitVfx.transform.parent = parentGameObj.transform;
        hitPoints--;
    }
}
