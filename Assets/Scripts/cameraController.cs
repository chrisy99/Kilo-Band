using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 *  Referenced entirely from brackeys tutorial
 */
public class cameraController : MonoBehaviour
{
    public float sensistivity = 600f;
    public Camera cam;
    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensistivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensistivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
        
    }
}
