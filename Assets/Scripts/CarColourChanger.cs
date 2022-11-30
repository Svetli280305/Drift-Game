using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarColourChanger : MonoBehaviour
{
    public GameObject carModel;
    public Light underglow;

    void Start()
    {

    }

    void Update()
    {

    }

    public void ChangeColour(Material newMaterial, Color newColour)
    {
        carModel.GetComponent<Renderer>().material = newMaterial;
        underglow.color = newColour;
    }
}
