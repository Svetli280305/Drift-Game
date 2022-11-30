using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{

    public GameObject[] wheelsToRotate;
    public TrailRenderer[] trails;
    //public ParticleSystem smoke;

    public float rotationSpeed;
    private Animator anim;

    public AudioSource accelerationSource;
    float accelerationPitch = 0.5f;
    public AudioSource tyreSource;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //accelerationPitch = accelerationSource.pitch;
    }

    // Update is called once per frame
    void Update()
    {
        float verticalAxis = Input.GetAxisRaw("Vertical");
        float horizontalAxis = Input.GetAxisRaw("Horizontal");

        foreach (var wheel in wheelsToRotate)
        {
            wheel.transform.Rotate(Time.deltaTime * verticalAxis * rotationSpeed, 0, 0, Space.Self);
            if (verticalAxis != 0)
            {
                //! play acceleration sound
                if (!accelerationSource.isPlaying)
                {
                    accelerationSource.UnPause();
                }
                else accelerationPitch += Time.deltaTime / 10;
            }
            else
            {
                accelerationSource.Pause();
                accelerationPitch -= Time.deltaTime / 30;
            }
        }

        //accelerationSource.pitch = accelerationPitch;

        if (horizontalAxis > 0)
        {
            //turning right
            anim.SetBool("goingLeft", false);
            anim.SetBool("goingRight", true);
        }
        else if (horizontalAxis < 0)
        {
            //turning left
            anim.SetBool("goingRight", false);
            anim.SetBool("goingLeft", true);
        }
        else
        {
            //must be going straight
            anim.SetBool("goingRight", false);
            anim.SetBool("goingLeft", false);
        }

        if (horizontalAxis != 0)
        {
            foreach (var trail in trails)
            {
                trail.emitting = true;

                //! play tyre sound
                if (!tyreSource.isPlaying) tyreSource.Play();
            }

            //var emission = smoke.emission;
            //emission.rateOverTime = 50f;
        }
        else
        {
            foreach (var trail in trails)
            {
                trail.emitting = false;

                //! stop tyre sound
                tyreSource.Stop();
            }

            //var emission = smoke.emission;
            // emission.rateOverTime = 0f;
        }
    }
}