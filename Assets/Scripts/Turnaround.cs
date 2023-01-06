using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turnaround : MonoBehaviour
{
    [SerializeField] Transform animals;
    public List<GameObject> animalObjects;
    [SerializeField] GameObject cam;

    private void Start()
    {
        cam.GetComponent<CameraRotate>().degreesToRotate = 0;
        foreach (Transform child in animals)
        {
            child.gameObject.SetActive(false);
            animalObjects.Add(child.gameObject);
            cam.GetComponent<CameraRotate>().degreesToRotate += 360;
        }
    }

    private void Update()
    {
        int currentIndex = (int)Mathf.Floor(cam.GetComponent<CameraRotate>().totalRotation / 360.0f);
        Debug.Log(currentIndex);
        if (currentIndex - 1 >= 0 && animalObjects.Count > currentIndex)
        {
            animalObjects[currentIndex - 1].SetActive(false);
        }
        if (currentIndex < animalObjects.Count)
        {
            animalObjects[currentIndex].SetActive(true);
        }
    }
}
