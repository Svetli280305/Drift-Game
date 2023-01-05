using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] Transform cam;
    [SerializeField] Transform pivot;
    [Range(0,100)]
    [SerializeField] float rotationSpeed;


    // Update is called once per frame
    void Update()
    {
        cam.RotateAround(pivot.position, Vector3.up, rotationSpeed*Time.deltaTime);
    }
}
