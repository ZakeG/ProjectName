using System.Collections;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public bool moveCamera = true;                      
    public float smoothing = 7f;
    public Vector3 offset = new Vector3 (0f, 1.5f, 0f); 
    public Transform playerPosition;
    private Camera camera;
    private int fov;
    private const int maxFov = 60;
    private const int minFov = 10;

    void Initialize()
    {
        camera = gameObject.GetComponentInChildren<Camera>();
        fov = maxFov;
    }

    private IEnumerator Start ()
    {
        if(!moveCamera)
            yield break;

        yield return null;

        transform.rotation = Quaternion.LookRotation(playerPosition.position - transform.position + offset);
    }


    private void LateUpdate ()
    {
        if (!moveCamera)
            return;

        Quaternion newRotation = Quaternion.LookRotation (playerPosition.position - transform.position + offset);
        transform.rotation = Quaternion.Slerp (transform.rotation, newRotation, Time.deltaTime * smoothing);
    }

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            ZoomIn();
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            ZoomOut();
        }
    }

    private void ZoomIn()
    {
        if (fov < minFov)
        {
            return;
        }
        else
        {
            camera.fieldOfView--;
            fov--;
        }
    }

    private void ZoomOut()
    {
        if (fov > maxFov)
        {
            return;
        }
        else
        {
            camera.fieldOfView++;
            fov++;

        }
    }

}
