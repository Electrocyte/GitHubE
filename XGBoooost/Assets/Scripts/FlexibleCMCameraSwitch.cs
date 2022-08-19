using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlexibleCMCameraSwitch : MonoBehaviour
{
    public GameObject[] cameraList;
    private int currentCamera;
    void Awake () {
        currentCamera = 0;
    
        if (cameraList.Length > 0){
            cameraList[0].gameObject.SetActive (true);
        } else {
            cameraList[0].gameObject.SetActive (true);
        }
    }
    
    void Update () {
        if (Input.GetKeyDown(KeyCode.Q)) {
            changeCamera();
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            Debug.Log("Player hit trigger");
            changeCamera();
        }
    }

    private void changeCamera()
    {
        currentCamera++;

        if (currentCamera < cameraList.Length)
        {
            Debug.Log(cameraList);
            cameraList[currentCamera - 1].gameObject.SetActive(false);
            cameraList[currentCamera].gameObject.SetActive(true);
        }
        else
        {
            currentCamera = 0;
            cameraList[currentCamera].gameObject.SetActive(true);
        }
    }
}
