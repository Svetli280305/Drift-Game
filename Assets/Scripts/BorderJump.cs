using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderJump : MonoBehaviour
{
    public GameObject carModel;

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
        carModel.GetComponent<CarController>().modifiedDrag = 0;
    }
}
