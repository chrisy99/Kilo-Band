using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
timer [x]
tourch off [x] 
send stop moving []
mash R/ key to recharge [x]
tourch on [x]
enable moving []
reset timer value [x]
*/
public float timeMax = 20;
public float timeValue = time;
public float timeSincePress;
public float current;
public float since;


public bool timeRunning = false;
public bool light = true;
public bool pressed = false;
public bool movement = true;

public Animator animator;
byte recharge=0;


public class Torch_recharge : MonoBehaviour
{
    void Start() {
        timeRunning = true;
        light = true;
        movement = true;
    }
    // Update is called once per frame
    void Update(){
        if (timeRunning){
            if (timeValue > 0) {
                timeValue -= Time.deltaTime;
            }
            else {
                light = false;
                ButtonMash();
                timeValue = timeMax; 
                movement = true;

            }
        } 
    }
    void ButtonMash(){
        movement = false;
        if(Input.GetKeyDown (KeyCode.R)){
            animator.SetInteger ("name", recharge);
            pressed = true;
            current = Time.time;
            since = current - timeOfLastPress;
            timeOfLastPress = current;

           if (since > 0){
                light = true;

            }

            
        }

    }
}
