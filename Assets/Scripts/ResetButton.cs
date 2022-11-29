using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetButton : MonoBehaviour
{
    public void ResetCar()
    {
        GameObject.Find("Car").transform.SetPositionAndRotation(new Vector3(0, 0, 0), Quaternion.Euler(new Vector3(0, 0, 0)));


        Debug.Log("pressed");
    }
}
