using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuse : MonoBehaviour
{
    [SerializeField] Transform fuse;

    GameObject fuseObj; 
    ParticleSystem fuseParticles;

    void Start()
    {
        fuse = FindObjectOfType<Fuse>().transform;
        var fuseObj = GameObject.Find("Fuse particles");
        var fuseParticles = fuseObj.GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        ReduceFuse();
    }

    private void ReduceFuse()
    {
        fuse.Translate(0f, -0.003f, 0f);
    }
}
