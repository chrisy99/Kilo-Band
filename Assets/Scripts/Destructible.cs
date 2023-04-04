// --------------------------------------
// This script is totally optional. It is an example of how you can use the
// destructible versions of the objects as demonstrated in my tutorial.
// Watch the tutorial over at http://youtube.com/brackeys/.
// --------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : Interactable
{

    public GameObject destroyedVersion; // Reference to the shattered version of the object

    // If the player clicks on the object
    void OnMouseDown()
    {
        // Spawn a shattered object
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        // Remove the current object
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (this.transform.gameObject.tag == "SceneTransitionTag" && collision.transform.gameObject.tag == "Player")
        {
            LevelLoader.Instance.LoadNextLevel();
        }

        if (this.transform.gameObject.tag == "PreviousTag" && collision.transform.gameObject.tag == "Player")
        {
            LevelLoader.Instance.LoadPreviousLevel();
        }
    }
    /*
    public override void Interact()
    {
        base.Interact();
        if (this.transform.gameObject.tag == "Destructible" && interactionTransform.transform.gameObject.tag != "Player")
        {
            Instantiate(destroyedVersion, transform.position, transform.rotation);
            Destroy(gameObject);
            LevelLoader.Instance.LoadPreviousLevel();
        }

        if (this.transform.gameObject.tag == "End" && interactionTransform.transform.gameObject.tag != "Player")
        {
            Instantiate(destroyedVersion, transform.position, transform.rotation);
            Destroy(gameObject);
            LevelLoader.Instance.LoadSpecificLevel("ThankYou");
        }
    }*/

}
