using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarColours : MonoBehaviour
{
    public List<Material> materials;
    public List<Color> underglowColours;

    int index = 2;

    void Start()
    {
        
    }

    public void OnClick()
    {
        index++;
        if (index >= materials.Count) index = 0;
        FindObjectOfType<CarColourChanger>().ChangeColour(materials[index], underglowColours[index]);
    }
}
