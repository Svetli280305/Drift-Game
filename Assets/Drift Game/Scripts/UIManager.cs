using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject touchControls;

    private void Update()
    {
        if (FindObjectOfType<GameManager>().inputType == InputType.touch)
        {
            touchControls.SetActive(true);
        }
        else
        {
            touchControls.SetActive(false);
        }
    }
}
