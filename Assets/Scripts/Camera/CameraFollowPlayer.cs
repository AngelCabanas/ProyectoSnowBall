using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform target;
    public float sensitivity = 1f;
    public float distance = 5.0f;
    public float yOffset = 0.5f;

    public LayerMask backgroundLayer;

    private float currentDistance;
    private Vector3 origin = Vector3.zero;

    private void Start()
    {
        currentDistance = distance;
    }

    void Update()
    {
        float mouseXInput = Input.GetAxisRaw("Mouse X");
        float mouseYInput = Input.GetAxisRaw("Mouse Y");

        origin = target.position + new Vector3(0, yOffset, 0);
        transform.position = origin;


        Vector3 currentRotation = transform.rotation.eulerAngles;

        currentRotation.y += mouseXInput * sensitivity;
        currentRotation.x -= mouseYInput * sensitivity;

        if (currentRotation.x > 180f)
        {
            currentRotation.x -= 360f;
        }

        currentRotation.x = Mathf.Clamp(currentRotation.x, -89.9f, 89.9f);


        transform.rotation = Quaternion.Euler(currentRotation);


        transform.position += -currentDistance * transform.forward;

        CheckForObstacles();
    }

    private void CheckForObstacles()
    {
        RaycastHit hit;
        float newDistance = distance;

        if (Physics.Raycast(origin, (transform.position - origin).normalized, out hit, distance, backgroundLayer))
        {
            float hitDistance = Vector3.Distance(origin, hit.point);
            newDistance = Mathf.Lerp(currentDistance, hitDistance -0.2f, Time.deltaTime * 100f);
        }

        currentDistance = newDistance;
    }
}

