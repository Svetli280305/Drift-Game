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


    public bool isPressed;

    void Turn()
    {
        CarController cc = FindObjectOfType<CarController>();

        if (steerDirection == Directions.left)
        {
            cc.turnInput = -1.0f;
        }
        else
        {
            cc.turnInput = 1.0f;
        }
    }

    public void OnUpdateSelected(BaseEventData data)
    {
        if (isPressed)
        {
            Turn();
        }
    }
    public void OnPointerDown(PointerEventData data)
    {
        isPressed = true;
    }
    public void OnPointerUp(PointerEventData data)
    {
        isPressed = false;
    }
}
