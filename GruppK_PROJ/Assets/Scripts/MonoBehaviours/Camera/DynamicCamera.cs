using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicCamera : MonoBehaviour {

    public GameObject cameraRigObject;
    public GameObject cameraObject;
    public int rorationSpeed;
    public float rotationDegrees;

    private int direction = 1;
    private bool cameraRotate = false;

    void Start()
    {

    }

    void Update()
    {
        if (cameraRotate)
        {
            cameraRigObject.transform.Rotate(Vector3.up * direction * (rorationSpeed * Time.deltaTime));
            if (cameraRigObject.transform.eulerAngles.y >= rotationDegrees)
            {
                SwitchDirection();
                cameraRotate = false;
            }
            if (cameraRigObject.transform.eulerAngles.y <= 0)
            {
                SwitchDirection();
                cameraRotate = false;
            }
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

        if (cameraRotate)
        {
            direction *= -1;
        }
        cameraRotate = true;
    }

 
}
