using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f, 5f)] float speed = 1f;

    // Start is called before the first frame update
    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());   
    }

    void Update() {
        ;
    }

    void FindPath() {
        path.Clear();
        
        GameObject parent = GameObject.FindGameObjectWithTag("Path");

        foreach (Transform child in parent.transform) {
            path.Add(child.GetComponent<Waypoint>());
        }
    }

    void ReturnToStart() {
        transform.position = path[0].transform.position;
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

            var currentGameObjTag = gameObject.tag;

            n++;
            while (travelPercent < 1f) {
                travelPercent += Time.deltaTime * speed;
                int tileNumber = path.Count;

                if (currentGameObjTag == "Cake") {  

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

        gameObject.SetActive(false);
    }
}
