using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
full charge [x]
tourch off [x] 
send stop moving []
press R/ key to recharge [x]
tourch on [x]
animation finish []
enable moving []
reset charge value [x]
*/


public class Torch_recharge : MonoBehaviour{

    public float timeMax = 20;
    public float timeValue = time;
    public float timeSincePress;
    public float current;
    public float since;


    public bool timeRunning = false;
    public bool light = true;
    public bool pressed = false;
    public bool movement = true;

    public float maxCharge = 100f;   // Maximum charge level for the flashlight
    public float chargeRate = 5f;    // Rate at which the flashlight charges per button press
    public KeyCode chargeButton = KeyCode.R;   // Button to mash to charge the flashlight

    private Light flashlight;
    private float currentCharge;

    public AudioSource windUp;
    public Animator animator;
    byte recharge=0;

    void Start() {
       // timeRunning = true; // starts timer for torch battery
        flashlight = GetComponent<Light>(); // gets light component attached to torch
        movement = true;
        currentCharge = maxCharge;   // Start with a fully charged flashlight
    }

    // Update is called once per frame
    void Update(){
        if (flashlight.enabled && currentCharge > 0f){
            currentCharge = currentCharge - (chargeRate*Time.deltaTime);
            if (currentCharge <= 0f){
                // If the charge level has reached zero, turn off the flashlight
                currentCharge = 0f;
                flashlight.enabled = false;
            }
        }
<<<<<<< Updated upstream
=======
        if (currentCharge <= 0 && Input.GetKeyDown(chargeButton)){
                //animator.SetInteger ("name", recharge);
                //currentCharge = Mathf.Min(currentCharge + 20, maxCharge);
                windUp.Play();
                currentCharge = maxCharge;
                flashlight.enabled = true;

        }
>>>>>>> Stashed changes

        // If the charge button is pressed, add to the charge level up to the maximum
        if (Input.GetKeyDown(chargeButton)){
            animator.SetInteger ("name", recharge);
            currentCharge = Mathf.Min(currentCharge + chargeRate, maxCharge);
        }
        
    }

}


