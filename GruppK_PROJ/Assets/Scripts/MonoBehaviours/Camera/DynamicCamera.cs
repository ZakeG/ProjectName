using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicCamera : MonoBehaviour {

    public GameObject cameraRigObject;
    public int rorationSpeed;
    public float smoothing;

    private Quaternion originalPosition;
    private Quaternion newPosition;
    private int direction;
    private bool cameraRotateRight = false;
    private bool cameraRotateLeft = false;
    private bool cameraRotationSwitch = false;

    void Start()
    {
        originalPosition = cameraRigObject.transform.rotation;
        newPosition = cameraRigObject.transform.rotation;

    }

    void LateUpdate()
    {
        if (cameraRotateRight) {
            cameraRigObject.transform.rotation = Quaternion.Slerp(cameraRigObject.transform.rotation, newPosition, Time.deltaTime * smoothing);
        }
        else if(cameraRotateLeft)
        {
            cameraRigObject.transform.rotation = Quaternion.Slerp(cameraRigObject.transform.rotation, originalPosition, Time.deltaTime * smoothing);
        }

        
    }

    public void OnTriggerEnter(Collider other)
    {
        RotateCamera();
    }
    public void OnTriggerExit(Collider other)
    {
        RotateCamera();
    }
    private void SwitchDirection()
    {
        direction *= -1;
    }

    private void RotateCamera()
    {

    }

 
}
