using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ObjectMover : MonoBehaviour
{
    //public Transform leftControllerTransform;
    public float moveSpeed = 1f;

    private GameObject pointedObject;
    private bool isXPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            pointedObject = hit.collider.gameObject;
        } 
        else
        {
            pointedObject = null;
        }

        CheckXPress();

        if(pointedObject == GameObject.Find("Sphere1") && isXPressed)
        {
            MoveObject();
        }
    }

    void CheckXPress()
    {
        InputDevice leftHandDevice = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        leftHandDevice.TryGetFeatureValue(CommonUsages.primaryButton, out isXPressed);
    }
    void MoveObject()
    {
        pointedObject.transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
    }
}
