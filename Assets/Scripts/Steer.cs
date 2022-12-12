using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum Directions
{
    left,
    right
}

public class Steer : MonoBehaviour
{
    [SerializeField] Directions steerDirection;

    void Start()
    {
        
    }

    public void OnClick()
    {
        FindObjectOfType<CarController>().Turn(steerDirection == Directions.left ? -1 : 1);
    }
}
