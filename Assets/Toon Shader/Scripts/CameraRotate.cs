using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] Transform cam;
    [SerializeField] Transform pivot;
    [SerializeField] float rotationSpeedScale;
    float rotationSpeed;
    public float degreesToRotate;
    public float totalRotation;
    public bool rotating = true;

    void Update()
    {
        if (rotating)
        {
            rotationSpeed = (rotationSpeedScale / degreesToRotate) * 10000;
            float rotateAmount = rotationSpeed * Time.deltaTime;
            totalRotation += rotateAmount;

            if (totalRotation >= degreesToRotate) rotating = false;
            else rotating = true;

            cam.RotateAround(pivot.position, Vector3.up, rotateAmount);
        }
    }
}
