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
        //Vector3 newPosition = centerPoints + offset;
        Vector3 newPosition = new Vector3(centerPoints.x, this.transform.position.y, this.transform.position.z);
        //transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
        transform.position = newPosition;
    }

    private Vector3 GetCenterPoint()
    {
        var bounds = new Bounds(target1.position, Vector3.zero);
        bounds.Encapsulate(new Vector3(target1.position.x, this.transform.position.y, this.transform.position.z));
        bounds.Encapsulate(new Vector3(target2.position.x, this.transform.position.y, this.transform.position.z));
        //bounds.Encapsulate(target1.position);
        //bounds.Encapsulate(target2.position);
        return bounds.center;
    }
}
