using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class camera_controller : MonoBehaviour
{


    public GameObject followTarget;
    public float camSpeed;

    private Vector3 targetPosition;
    private static bool camExists;

    //public Transform target;
    //public Vector3 offset;

    void Start()
    {
        if (!camExists)
        {
            camExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void LateUpdate()
    {
        //Vector3 desiredPosition = target.position + offset;
        //Vector3 smoothedPosition = Vector3.SmoothDamp (transform.position, desiredPosition, camSpeed * Time.deltaTime);
        //Vector2.MoveToward;
        //transform.LookAt(target);

        targetPosition = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, followTarget.transform.position.z - 10.0f);
        transform.position = Vector3.Lerp(transform.position, targetPosition, camSpeed * Time.deltaTime);

    }
}