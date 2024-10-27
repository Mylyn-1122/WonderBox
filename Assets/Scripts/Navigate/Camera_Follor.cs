using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follor : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target;
    [SerializeField] private Camera mainCamera;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        Vector2 targetPos = target.position;
        Vector2 cameraPos = new Vector2(mainCamera.GetComponent<Transform>().position.x, mainCamera.GetComponent<Transform>().position.y);

        if ((Mathf.Abs(cameraPos.x - targetPos.x) < 0.01) &&  (Mathf.Abs(cameraPos.x - targetPos.x) < 0.01)) {
            mainCamera.GetComponent<Camera_Follor>().enabled = false;
        }
    }
}
