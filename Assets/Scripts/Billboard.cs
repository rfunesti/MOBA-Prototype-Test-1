using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    void Update()
    {
        Vector3 direction = Camera.main.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(-direction);
        transform.rotation = rotation;
    }
}