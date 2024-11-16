using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target1, target2;
    public Vector3 offset;

    public float smoothTime = .5f;
    private Vector3 velocity;
    private void LateUpdate()
    {
        Vector3 centerPoints = GetCenterPoint();
        Vector3 newPosition = centerPoints + offset;
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    private Vector3 GetCenterPoint()
    {
        var bounds = new Bounds(target1.position, Vector3.zero);
        //bounds.Encapsulate(new Vector3(target1.position.x, 0, 0));
        //bounds.Encapsulate(new Vector3(target2.position.x, 0, 0));
        bounds.Encapsulate(target1.position);
        bounds.Encapsulate(target2.position);
        return bounds.center;
    }
}
