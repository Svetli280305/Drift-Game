using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turnaround : MonoBehaviour
{
    [SerializeField] Transform animals;
    List<GameObject> animalObjects;
    [SerializeField] CameraRotate cam;

    private void Start()
    {
        foreach (Transform child in animals)
        {
            child.gameObject.SetActive(false);
            animalObjects.Add(child.gameObject);
            cam.degreesToRotate += 360;
        }
    }

    private void Update()
    {
        animalObjects[(int)Mathf.Floor(cam.totalRotation / 360.0f)].SetActive(true);
    }
}
