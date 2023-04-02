using System.Collections;
using System.Collections.Generic;
/**
using UnityEngine;

//! Uncomment when CharacterStats is implemented
[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactable
{
    PlayerManager playerManager;
    CharacterStats myStats;

    void Start()
    {
        playerManager = PlayerManager.instance;
        myStats = GetComponent<CharacterStats>();
    }

    // Update is called once per frame
    public override void Interact()
    {
        base.Interact();
        Combat combat = playerManager.player.GetComponent<Combat>();
        if(combat != null)
        {
            combat.Attack(myStats);
            Debug.Log("Attacked " + this.name + " for " + myStats.damage.GetValue() + ".");
        }
    }
}

*/