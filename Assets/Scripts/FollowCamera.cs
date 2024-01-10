using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FollowCamera : MonoBehaviour
{
    public Vector3 origin = Vector3.zero;
    public float pitch;
    public float yaw;
    public float distance;

    void LateUpdate()
    {
        Vector3 direction = Quaternion.Euler(pitch, yaw, 0f) * Vector3.forward;
        Vector3 cameraPosition = origin - direction * distance;
        Camera.main.transform.position = cameraPosition;
        Camera.main.transform.rotation = Quaternion.Euler(pitch, yaw, 0f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(origin, Camera.main.transform.position);
    }
}
