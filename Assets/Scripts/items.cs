using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class items : Interactable
{
    public Transform targetTransform;
    Vector3 throwF = new Vector3(2, 0.5f, 0);
    public Rigidbody rgbody;
    Camera cam;

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
        transform.rotation = Quaternion.Euler(Vector3.zero);
        rgbody.useGravity = false;
        rgbody.isKinematic = true;
        
    }
    public void Detach()
    {
        transform.parent = null;
        rgbody.useGravity = true;
        rgbody.isKinematic = false;
    }
    public void Throw(Vector3 force)
    {
        Detach();
        rgbody.AddForce(force, ForceMode.Impulse);
    }
}
