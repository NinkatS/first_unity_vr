using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ObjectMove : MonoBehaviour
{
    public Transform leftTrans;
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
        if (Physics.Raycast(leftTrans.position, leftTrans.forward, out hit))
        {
            pointedObject = hit.collider.gameObject;
        } 
        else
        {
            pointedObject = null;
        }

        CheckXPress();

        if(pointedObject == GameObject.Find("MoveMe") && isXPressed)
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
