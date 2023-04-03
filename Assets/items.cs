using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class items : Interactable
{
    public Transform targetTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {}
    public override void Interact()
    {
        base.Interact();
        transform.SetParent(targetTransform);
        transform.localPosition = Vector3.zero;
    }
    public void Detach()
    {
        transform.parent = null;
    }
}
