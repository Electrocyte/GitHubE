using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb2d;
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float boostSpeed = 50f;
    [SerializeField] float XGBoostSpeed = 150f;
    [SerializeField] float baseSpeed = 10f;
    SurfaceEffector2D surfaceEffector2D;
    SurfaceEffector2D[] surfaceEffector2Darray;
    bool canMove = true;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        // surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
        surfaceEffector2Darray = FindObjectsOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            RespondToBoost();
        }
    }

    public void DisableControls()
    {
        canMove = false;
    }

    void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // surfaceEffector2D.speed = boostSpeed;
            // Debug.Log($"Boosting {surfaceEffector2D.speed}");
            surfaceEffector2Darray
                .Where(x => x.tag == "Ground") 
                .ToList()
                .ForEach(x => x.speed = boostSpeed);
            // var filtered = surfaceEffector2Darray.Where(x => x.tag == "Player");
            // foreach( var x in filtered) Debug.Log( x.ToString());

        }
        else if (Input.GetKey(KeyCode.PageDown))
        {
            // surfaceEffector2D.speed = boostSpeed;
            // Debug.Log($"Boosting {surfaceEffector2D.speed}");
            surfaceEffector2Darray
                .Where(x => x.tag == "Ground") 
                .ToList()
                .ForEach(x => x.speed = XGBoostSpeed);
            // var filtered = surfaceEffector2Darray.Where(x => x.tag == "Player");
            // foreach( var x in filtered) Debug.Log( x.ToString());

        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            surfaceEffector2Darray
                .Where(x => x.tag == "Ground") 
                .ToList()
                .ForEach(x => x.speed = baseSpeed);
            // surfaceEffector2D.speed = baseSpeed;
        }        
    }


    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount * 2);
        }
    }
}
