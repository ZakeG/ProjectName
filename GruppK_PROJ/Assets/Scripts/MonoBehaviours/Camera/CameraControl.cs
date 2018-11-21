using System.Collections;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class CameraControl : MonoBehaviour
{
    public bool moveCamera = true;                      
    public float smoothing = 7f;
    public Vector3 offset = new Vector3 (0f, 1.5f, 0f); 
    public Transform playerPosition;
    public Condition CameraOptionCondition;
    private bool cameraOptions;
    private Camera mainCamera;
    private float fov;
    private const int maxFov = 60;
    private const int minFov = 10;

    private float speedH = 2.0f;
    private float speedV = 2.0f;
    private float yaw = 0.0f;
    private float pitch = 0.0f;
    private bool rotating;

    private IEnumerator Start ()
    {
        mainCamera = gameObject.GetComponentInChildren<Camera>();
        if (CameraOptionCondition.satisfied == false)
        {
            mainCamera.GetComponent<ContrastEnhance>().enabled = false;
            cameraOptions = false;
        }
        else
        {
            mainCamera.GetComponent<ContrastEnhance>().enabled = true;
            cameraOptions = true;
        }
        fov = mainCamera.fieldOfView;
        if (!moveCamera)
            yield break;

        yield return null;

        transform.rotation = Quaternion.LookRotation(playerPosition.position - transform.position + offset);
    }


    private void LateUpdate ()
    {
        if (!moveCamera)
            return;
        if (fov >= maxFov) {
            Quaternion newRotation = Quaternion.LookRotation(playerPosition.position - transform.position + offset);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * smoothing);
        }
    }

    void Update()
    {
        if (cameraOptions)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                ZoomIn();
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                ZoomOut();
            }
            if (fov < maxFov)
            {
                if (!rotating)
                {
                    rotating = true;
                }
                yaw += speedH * Input.GetAxis("Mouse X");
                pitch -= speedV * Input.GetAxis("Mouse Y");
                mainCamera.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
            }
        }
    }

    private void ZoomIn()
    {
        if (fov <= minFov)
        {
            return;
        }
        else
        {
            fov += -10f;
            mainCamera.fieldOfView = fov;
        }
    }

    private void ZoomOut()
    {
        if (fov >= maxFov)
        {
            return;
        }
        else
        {
            fov += 10f;
            mainCamera.fieldOfView = fov;
        }
    }

}
