using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] GameObject fuse;
    [SerializeField] [Range(0f, 5f)] float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FollowPath());   
    }

    private IEnumerator FollowPath()
    {
        int n = 0;
        foreach (var wp in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = wp.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);

            var currentGameObj = gameObject.tag;
            n++;
            while (travelPercent < 1f) {
                travelPercent += Time.deltaTime * speed;

                if (currentGameObj == "Cake") {   

                    if (path.Count == n) {
                        Debug.Log("Fuse runs out.");
                    }

                    if (Time.frameCount > 60f / speed) {
                        endPosition.y = 3;
                        transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                    }

                } else {
                    transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                }
                yield return new WaitForEndOfFrame();
            }

        }
    }
}
