/*	
using System.Diagnostics;

using UnityEngine;
using UnityEngine.AI;

 *	Coded by Brackeys.
 *	Borrowed 21/2/2023
	This component is for all objects that the player can
	interact with such as enemies, items etc. It is meant
	to be used as a base class.


public class Interactable : MonoBehaviour
{
    public float dectect_radius = 2f; // radius for picking up player sound 
    public Transform interactionTransform;  // The transform from where we interact in case you want to offset it
    Transform player;       // Reference to the player transform

    bool hasInteracted = false; // Have we already interacted with the object?
    public float noise_radius; // player interaction radius (TODO: update to get in start())
    private float _timer;
    public NavMeshAgent agent;
    public virtual void Interact()
    {
        // This method is meant to be overwritten
        UnityEngine.Debug.Log("Interacting with " + transform.name);
        agent.SetDestination(player.position);
    }

    public void Start()
    {
        // TODO: get player transform
        // TODO: get player interaction radius

    }
    void Update()
    {
        // If we are close enough
        float distance = Vector3.Distance(player.position, interactionTransform.position);
        float hear_distance = noise_radius + dectect_radius;
        if (distance <= hear_distance)
        {
            // Interact with the object
            Interact();
            hasInteracted = true;
        }
        

        // interaction cool down timer
        if (hasInteracted)
        {
            _timer += Time.deltaTime;
            if (_timer >= 5f)
            {
                hasInteracted = false;
            }
        }
    }

    /* 
    // Called when player has aggro
    public void OnAggro(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    // Called when the object is no longer focused
    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }
    
}
*/