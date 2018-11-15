using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicCamera : MonoBehaviour {

    public GameObject cameraObject1;
    public GameObject cameraObject2;

    public void MoveCamera()
    {
        if (cameraObject1.activeSelf)
        {
            cameraObject1.SetActive(false);
            cameraObject2.SetActive(true);
        }
        else
        {

            cameraObject1.SetActive(true);
            cameraObject2.SetActive(false);
        }
    } 
}
