using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderJump : MonoBehaviour
{
    public GameObject Camera;
    public GameObject CameraSettings;
    public GameObject CameraDolly;

    public Vector3 CameraPos;
    public Vector3 SettingsPos;
    public Vector3 DollyPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Camera.GetComponent<Transform>().transform.position = CameraPos;
        CameraSettings.GetComponent<Transform>().transform.position = SettingsPos;
        CameraDolly.GetComponent<Transform>().transform.position = DollyPos;
    }
}
