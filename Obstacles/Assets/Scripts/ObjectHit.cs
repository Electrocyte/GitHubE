using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision) {

        if (collision.gameObject.tag == "Player")
        {
            GetComponent<MeshRenderer>().material.color = Color.yellow;
            if (gameObject.tag == "Ball") {
                gameObject.tag = "Ball";
                Debug.Log("Hit the ball");
            }
        }
    }
}
