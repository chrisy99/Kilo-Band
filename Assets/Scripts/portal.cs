// --------------------------------------
// This script is totally optional. It is an example of how you can use the
// destructible versions of the objects as demonstrated in my tutorial.
// Watch the tutorial over at http://youtube.com/brackeys/.
// --------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour
{
	
	void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.gameObject.tag == "Player")
		{
			Debug.Log("Collision with player!!!!");
			LevelLoader.Instance.LoadNextLevel();
		}
	}
}
