using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] float waitTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FollowPath());   
    }

    private IEnumerator FollowPath()
    {
        foreach (var wp in path)
        {
            transform.position = wp.transform.position;
            yield return new WaitForSeconds(waitTime);
        }
    }
}
