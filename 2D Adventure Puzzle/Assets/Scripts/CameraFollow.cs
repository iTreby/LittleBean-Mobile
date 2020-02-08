using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] float addDistanceCamera = 2.0f;
    public float cameraSpeedMove = 5.0f;
    private Vector3 targetPosition;
    [SerializeField] float minClam = -3.0f;
    [SerializeField] float maxClam = 5.0f;
    [SerializeField] bool followTarget;


    // Use this for initialization
    void Start()
    {
        followTarget = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (followTarget)
        {

            //refer to the camera , set the value of the camera
            //x first follow player x , rest coordi is from the camera
            targetPosition = new Vector2(target.transform.position.x, Mathf.Clamp(target.transform.position.y, minClam, maxClam));

            if (target.transform.localScale.x > 0f)
            {
                targetPosition = new Vector3(targetPosition.x + addDistanceCamera, targetPosition.y, transform.position.z);
            }
            else
            {
                targetPosition = new Vector3(targetPosition.x - addDistanceCamera, targetPosition.y, transform.position.z);
            }

            //transform.position = targetPosition;
            //Make a smooth transition of the camera
            transform.position = Vector3.Lerp(transform.position, targetPosition, cameraSpeedMove * Time.deltaTime);
        }
    }
}
