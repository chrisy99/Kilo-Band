using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footsteps : MonoBehaviour
{

    public AudioSource footstepSound, sprintSound;

    private void Update()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            footstepSound.enabled = true;

            if(Input.GetKey(KeyCode.LeftShift))
            {
                footstepSound.enabled = false;
                sprintSound.enabled = true;
            }
        }
        else
        {
            footstepSound.enabled = false;
        }
    }
}
