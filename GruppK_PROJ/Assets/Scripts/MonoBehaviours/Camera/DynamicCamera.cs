using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicCamera : MonoBehaviour {

    public GameObject cameraRigObject1;
    public GameObject cameraRigObject2;

    public void OnTriggerEnter(Collider other)
    {
        MoveCamera();
    }
    public void OnTriggerExit(Collider other)
    {
        MoveCamera();
    }

    private void MoveCamera()
    {
        if (cameraRigObject1.activeSelf)
        {
            cameraRigObject1.transform.GetChild(0).gameObject.SetActive(false);
            cameraRigObject1.SetActive(false);
            cameraRigObject2.transform.GetChild(0).gameObject.SetActive(true);
            cameraRigObject2.SetActive(true);
        }
        else
        {
            cameraRigObject1.SetActive(true);
            cameraRigObject1.transform.GetChild(0).gameObject.SetActive(true);
            cameraRigObject2.SetActive(false);
            cameraRigObject2.transform.GetChild(0).gameObject.SetActive(false);

        }
    } 
}
