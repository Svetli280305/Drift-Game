using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] Transform cam;
    [SerializeField] Transform pivot;
    [Range(1, 100)]
    [SerializeField] float rotationSpeedScale;
    float rotationSpeed;
    public float degreesToRotate;
    public float totalRotation;
    public bool rotating = true;

    void Update()
    {
        rotationSpeed = (rotationSpeedScale / degreesToRotate) * 200;
        float rotateAmount = rotationSpeed * Time.deltaTime;
        totalRotation += rotateAmount;

        if (totalRotation >= degreesToRotate) rotating = false;
        else rotating = true;

        if (rotating)
        {
            cam.RotateAround(pivot.position, Vector3.up, rotateAmount);
        }
    }
}
